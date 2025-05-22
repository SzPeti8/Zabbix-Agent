using log4net;
using log4net.Config;
using Zabbix_Agent_Sender.Agent_F;
using Zabbix_Agent_Sender.Device;
using static Zabbix_Active_Sender;
using static Zabbix_Active_Sender_Utils;
using static Zabbix_Agent_Sender.Device.Example_Utils;
using static Zabbix_Serializables;


namespace Zabbix_Agent_Sender.Agent
{


    /// <summary>
    /// Represents a Zabbix agent responsible for communicating with the Zabbix server,
    /// sending heartbeats, retrieving configuration, and sending collected data.
    /// </summary>
    public class Agent : IAgent
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string zabbixServer = null;
        private int zabbixPort = 0;
        string host = null;
        string version = null;
        int heartbeat_freq_inMiliSecs = 20000;
        int data_sending_interval_inMiliSecs = 30000;
        int config_data_interval_inMiliSecs = 10000;
        int timeout_freq_ForGettingData_inSeconds = 10;
        int number_ofThreads = 10;

        string session = null;
        string heartbeatPayload = null;
        string configPayload = null;

        static System.Timers.Timer configTimer;
        static System.Timers.Timer HBtimer;
        static System.Timers.Timer DATAtimer;

        int id = 1;

        /// <summary>
        /// Initializes the agent with the specified configuration.
        /// </summary>
        /// <param name="config">The agent configuration settings.</param>
        public void Init(AgentConfig config)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            // Configuration settings
            zabbixServer = config.zabbixServer;
            zabbixPort = config.zabbixPort;
            host = config.host;
            version = config.version;
            heartbeat_freq_inMiliSecs = config.heartbeat_freq_InMiliSecs;
            data_sending_interval_inMiliSecs = config.data_sending_freq_InMiliSecs;
            config_data_interval_inMiliSecs = config.config_data_req_freq_InMiliSecs;
            timeout_freq_ForGettingData_inSeconds = config.timeout_freq_ForGettingData_inSeconds;
            number_ofThreads = config.maxThreads;

            log.Debug("Generating Session ID ");
            session = GenerateSessionID();
            log.Debug("Creating Heartbeat Payload");
            heartbeatPayload = CreateHeartbeatPayload(host, version, heartbeat_freq_inMiliSecs);
            log.Debug("Creating Config Payload");
            configPayload = CreateConfigPayload(host, version);
        }

        /// <summary>
        /// Starts the agent's operation, including configuration polling, heartbeat, and data sending.
        /// </summary>
        public void Start()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            // Checking config settings
            if (IsConfigDone())
            {
                log.Error("Wrong Config Setup for Agent in: " + GetType().Name);
                return;
            }

            // Getting the config list
            log.Info($"Getting The config file from server: {zabbixServer}, Port: {zabbixPort}, Host: {host}");

            string conf_Items_String = null;
            try
            {
                conf_Items_String = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, configPayload);
            }
            catch (System.Net.Sockets.SocketException exSocket)
            {
                log.Error($"Hibatörtént a szerver megszólításánál. A szerver nem válaszolt. {exSocket.Message} \n {exSocket}");
                return;
            }
            catch (Exception ex)
            {
                log.Error("Hiba történt a Zabbix_Active_Sender_Normal-ban: " + ex.Message + "\n" + ex);
                return;
            }

            // Deserializing
            List<Zabbix_Config_Item> conf_Items = new List<Zabbix_Config_Item>();
            try
            {
                conf_Items = DeserializeResponseConfig(conf_Items_String).data;
            }
            catch (Exception e)
            {
                log.Debug($"Response to Agent Config Request: {conf_Items_String}");
                log.Error("Couldnt Deserialize Config Response. Message: " + e.Message);
                return;
            }

            // Set up configuration polling timer
            configTimer = new System.Timers.Timer(config_data_interval_inMiliSecs);
            configTimer.Elapsed += (sender, e) =>
            {
                log.Info($"Getting The config file again from server: {zabbixServer}, Port: {zabbixPort}, Host: {host}");

                string conf_Items_String = null;
                try
                {
                    conf_Items_String = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, configPayload);
                }
                catch (System.Net.Sockets.SocketException exSocket)
                {
                    log.Error($"Hibatörtént a szerver megszólításánál. A szerver nem válaszolt. {exSocket.Message} \n {exSocket}");
                    return;
                }
                catch (Exception ex)
                {
                    log.Error("Hiba történt a Zabbix_Active_Sender_Normal-ban: " + ex.Message + "\n" + ex);
                    return;
                }

                try
                {
                    conf_Items = DeserializeResponseConfig(conf_Items_String).data;
                }
                catch (Exception ex)
                {
                    log.Debug($"Response to Agent Config Request: {conf_Items_String}");
                    log.Error("Couldnt Deserialize Config Response. Message: " + ex.Message);
                    return;
                }
            };
            configTimer.AutoReset = true;
            configTimer.Enabled = true;

            // Sending heartbeat
            SendingHeartbeat();
            HBtimer = new System.Timers.Timer(heartbeat_freq_inMiliSecs);
            HBtimer.Elapsed += (sender, e) =>
            {
                SendingHeartbeat();
            };
            HBtimer.AutoReset = true;
            HBtimer.Enabled = true;

            try
            {
                Process(conf_Items);
                DATAtimer = new System.Timers.Timer(data_sending_interval_inMiliSecs);
                DATAtimer.Elapsed += (sender, e) =>
                {
                    Process(conf_Items);
                };
                DATAtimer.AutoReset = true;
                DATAtimer.Enabled = true;
            }
            catch (DevNameDoesntMatchException e)
            {
                DATAtimer = new System.Timers.Timer(20000);
                DATAtimer.Elapsed += (sender, e) =>
                {
                };
                DATAtimer.AutoReset = true;
                DATAtimer.Enabled = true;
                throw e;
            }
        }

        /// <summary>
        /// Processes the provided list of Zabbix configuration items asynchronously.
        /// Collects data for each item and sends the results to the Zabbix server.
        /// </summary>
        /// <param name="conf_Items">The list of configuration items to process.</param>
        public async void Process(List<Zabbix_Config_Item> conf_Items)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            // Getting new Data
            List<Zabbix_Send_Item> send_tems = new List<Zabbix_Send_Item>();

            try
            {
                var cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;

                // Creating tasks
                var semaphore = new SemaphoreSlim(number_ofThreads); 
                var tasks = conf_Items.Select(async item =>
                {
                    await semaphore.WaitAsync().ConfigureAwait(false);
                    try
                    {
                        return await GettingNewDataAsync(item, host, token);
                    }
                    catch (OperationCanceledException)
                    {
                        return null;
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }).ToList();

                log.Debug("Timer INDUL#########################");
                await Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(timeout_freq_ForGettingData_inSeconds)).ConfigureAwait(false);
                    cts.Cancel();
                    log.Debug("LEJART AZ IDO");
                });

                // Getting the finished task results to a list
                var results = tasks
                    .Where(t => t.IsCompletedSuccessfully).Where(t => t.Result != null)
                    .Select(t => t.Result)
                    .ToList();

                log.Info($"After TimeOut {results.Count} task finished.");

                // Adding the results to a list
                for (int i = 0; i < results.Count; i++)
                {
                    log.Debug($"Task result: {results[i].key}. => value: {results[i].value}");
                    if (results[i].value != null)
                    {
                        send_tems.Add(results[i]);
                    }
                }
            }
            catch (DevNameDoesntMatchException e)
            {
                throw e;
            }
            if (send_tems == null)
            {
                log.Error("List of items you want to send is null");
                return;
            }
            // Sending Data
            SendingData(send_tems, host, session, version, zabbixServer, zabbixPort, id);
            id += send_tems.Count + 1;
        }

        /// <summary>
        /// Asynchronously gets new data for a configuration item from the host.
        /// </summary>
        /// <param name="conf_Items">The configuration item to process.</param>
        /// <param name="host">The host name.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A <see cref="Zabbix_Send_Item"/> containing the collected data.</returns>
        /// <exception cref="DevNameDoesntMatchException">Thrown if the device name does not match or no response is received.</exception>
        public async Task<Zabbix_Send_Item> GettingNewDataAsync(Zabbix_Config_Item conf_Items, string host, CancellationToken token)
        {
            log.Debug("Generating ZabbixRR From Config items");

            ZabbixRR zabbixRR = new ZabbixRR();

            zabbixRR.Request = CreateZabbixRRRequest(conf_Items, host);

            zabbixRR.CancellationToken = token;

            log.Debug("Dev_Process Invoke");
            try
            {
                await RequestReceived?.Invoke(this, zabbixRR);
            }
            catch (OperationCanceledException)
            {
                log.Warn("Task Canccelled");
                throw new OperationCanceledException();
            }

            if (zabbixRR.Response == null)
            {
                log.Error($"Response is null, Example did not send data back hostname you tried to get: {host}");
                throw new DevNameDoesntMatchException($"Response is null, Example did not send data back hostname you tried to get: {host}");
            }
            log.Debug("Convert FromZabbixRR To ZabbixSendItem List");

            Zabbix_Send_Item send_tem = ConvertFromZabbixRRToZabbixSendItem(zabbixRR, host);
            return send_tem;
        }

        /// <summary>
        /// Sends the collected data items to the Zabbix server in batches.
        /// </summary>
        /// <param name="send_tems">The list of items to send.</param>
        /// <param name="host">The host name.</param>
        /// <param name="session">The session identifier.</param>
        /// <param name="version">The agent version.</param>
        /// <param name="zabbixServer">The Zabbix server address.</param>
        /// <param name="zabbixPort">The Zabbix server port.</param>
        /// <param name="id">The starting ID for the items.</param>
        public void SendingData(List<Zabbix_Send_Item> send_tems, string host, string session, string version, string zabbixServer, int zabbixPort, int id)
        {
            log.Debug("Prepare SendItems");
            send_tems = PrepareSendItems(send_tems, id);
            for (int i = 0; i < send_tems.Count; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    log.Debug("Creating Data Payload");
                    string agentDataPayload = CreateAgentDataPayload(host,
                    [
                        send_tems[i-2],
                            send_tems[i-1],
                            send_tems[i]
                    ], session, version);
                    log.Debug($"Payload: {agentDataPayload}");
                    log.Info("Sending Data to server");

                    string dataRespond = null;
                    try
                    {
                        dataRespond = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, agentDataPayload);
                    }
                    catch (System.Net.Sockets.SocketException exSocket)
                    {
                        log.Error($"Hibatörtént a szerver megszólításánál. A szerver nem válaszolt. {exSocket.Message} \n {exSocket}");
                        return;
                    }
                    catch (Exception ex)
                    {
                        log.Error("Hiba történt a Zabbix_Active_Sender_Normal-ban: " + ex.Message + "\n" + ex);
                        return;
                    }

                    log.Info($"Data response: {dataRespond}");
                }
                else
                {
                    if (send_tems.Count - i + 1 < 3)
                    {
                        List<Zabbix_Send_Item> leftovers = new List<Zabbix_Send_Item>();
                        for (int j = i; j < send_tems.Count; j++)
                        {
                            leftovers.Add(send_tems[j]);
                        }
                        log.Debug("Creating Data Payload");
                        string agentDataPayload = CreateAgentDataPayload(host, leftovers, session, version);
                        log.Debug($"Payload: {agentDataPayload}");
                        log.Info("Sending Data to server");

                        string dataRespond = null;
                        try
                        {
                            dataRespond = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, agentDataPayload);
                        }
                        catch (System.Net.Sockets.SocketException exSocket)
                        {
                            log.Error($"Hibatörtént a szerver megszólításánál. A szerver nem válaszolt. {exSocket.Message} \n {exSocket}");
                            return;
                        }
                        catch (Exception ex)
                        {
                            log.Error("Hiba történt a Zabbix_Active_Sender_Normal-ban: " + ex.Message + "\n" + ex);
                            return;
                        }

                        log.Info($"Data response: {dataRespond}");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Prepares the list of items to be sent by assigning IDs and timestamps.
        /// </summary>
        /// <param name="items">The list of items to prepare.</param>
        /// <param name="idCount">The starting ID value.</param>
        /// <returns>The prepared list of items.</returns>
        public List<Zabbix_Send_Item> PrepareSendItems(List<Zabbix_Send_Item> items, int idCount)
        {
            for (int i = 0; items.Count > i; i++)
            {
                items[i].id = idCount;
                items[i].clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                items[i].ns = 0;
                idCount++;
            }
            return items;
        }

        /// <summary>
        /// Stops the agent's operation and logs shutdown information.
        /// </summary>
        public void Stop()
        {
            log.Info("AGENT SHUT DOWN Name: " + GetType().Name);
        }

        /// <summary>
        /// Occurs when a request for data is received.
        /// </summary>
        public event AsyncRequestHandler? RequestReceived;

        /// <summary>
        /// Checks if the agent configuration is valid and complete.
        /// </summary>
        /// <returns><c>true</c> if the configuration is invalid; otherwise, <c>false</c>.</returns>
        private bool IsConfigDone()
        {
            return !(zabbixServer == null | zabbixPort == 0 | host == null | version != null | heartbeat_freq_inMiliSecs == 0);
        }

        /// <summary>
        /// Sends a heartbeat message to the Zabbix server.
        /// </summary>
        public void SendingHeartbeat()
        {
            log.Info("Sending Heartbeat to server");
            string response = null;
            try
            {
                response = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, heartbeatPayload);
            }
            catch (System.Net.Sockets.SocketException exSocket)
            {
                log.Error($"Hibatörtént a szerver megszólításánál. A szerver nem válaszolt. {exSocket.Message} \n {exSocket}");
                return;
            }
            catch (Exception ex)
            {
                log.Error("Hiba történt a Zabbix_Active_Sender_Normal-ban: " + ex.Message + "\n" + ex);
                return;
            }

            log.Debug("Heartbeat response:" + response);
        }
    }
}
