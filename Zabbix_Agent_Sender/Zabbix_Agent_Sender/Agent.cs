using log4net;
using System;
using static Zabbix_Serializables;
using static Zabbix_Active_Sender_Utils;
using static Zabbix_Active_Sender;
using log4net.Config;
using  System.Timers;
using static Zabbix_Agent_Sender.Example_Utils;


namespace Zabbix_Agent_Sender
{
    

    public partial class Agent : IAgent
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        string zabbixServer = null;
        int zabbixPort = 0;
        string host = null;
        string version = null;
        int heartbeat_freq = 0;

        string session = null;
        string heartbeatPayload = null;
        string configPayload = null;

        static System.Timers.Timer configTimer;
        static System.Timers.Timer HBtimer;
        static System.Timers.Timer DATAtimer;

        int id = 1;


        public void Init(AgentConfig config)
        {
            test();
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            //konfig beállítások
            zabbixServer = config.zabbixServer;
            zabbixPort = config.zabbixPort;
            host = config.host;
            version = config.version;
            heartbeat_freq = config.heartbeat_freq;

            log.Debug("Generating Session ID ");
            session = GenerateSessionID();
            log.Debug("Creating Heartbeat Payload");
            heartbeatPayload = CreateHeartbeatPayload(host, version, heartbeat_freq);
            log.Debug("Creating Config Payload");
            configPayload = CreateConfigPayload(host, version);
        }
    

        

        public void Start()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            //Checking config settings
            if (IsConfigDone())
            {
                log.Error("Wrong Config Setup for Agent in: " + this.GetType().Name);
                return;
            }

            //Getting the config list
            log.Info($"Getting The config file from server: {zabbixServer}, Port: {zabbixPort}, Host: {host}");
            //Console.WriteLine($"Getting The config file from server: {zabbixServer}, Port: {zabbixPort}, Host: {host}");
            string conf_Items_String = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, configPayload);
            //Deserializeing
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

            configTimer = new System.Timers.Timer(10000);
            configTimer.Elapsed += (sender, e) =>
            {
                log.Info($"Getting The config file again from server: {zabbixServer}, Port: {zabbixPort}, Host: {host}");
                string conf_Items_String = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, configPayload);
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
            configTimer.AutoReset = true; // újra és újra lefut
            configTimer.Enabled = true;

            //Sending heartbeat
            SendingHeartbeat();
            HBtimer = new System.Timers.Timer(heartbeat_freq * 1000);
            HBtimer.Elapsed += (sender, e) =>
            {
                SendingHeartbeat();
            };
            HBtimer.AutoReset = true; // újra és újra lefut
            HBtimer.Enabled = true;

            try
            {
                Process(conf_Items);
                DATAtimer = new System.Timers.Timer(20000);
                DATAtimer.Elapsed += (sender, e) =>
                {
                    //TODO: Config lekérdezése időnként, csak itt
                    Process(conf_Items);
                };
                DATAtimer.AutoReset = true; // újra és újra lefut
                DATAtimer.Enabled = true;

            }
            catch (DevNameDoesntMatchException e)
            {
                DATAtimer = new System.Timers.Timer(20000);
                DATAtimer.Elapsed += (sender, e) =>
                {
                    
                };
                DATAtimer.AutoReset = true; // újra és újra lefut
                DATAtimer.Enabled = true;
                //log.Error(e.Message);
                throw e;
                
            }

        }


        public void Process(List<Zabbix_Config_Item> conf_Items)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            //XXXXXXXXXXXXXXXXXX CHANGED FOR TESTING ZABBIXEXAMPLE PROJECT XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            //zabbixRR = obj.Dev_Process(zabbixRR);


            //Getting new Data
            List<Zabbix_Send_Item> send_tems = null;

            try
            {
                send_tems = GettingNewData(conf_Items, host);

            }
            catch(DevNameDoesntMatchException e)
            {
                //log.Error(e.Message);
                throw e;
            }
            if (send_tems == null)
            {
                log.Error("List of items you want to send is null");
                return;
            }
            //Sending Data

            SendingData(send_tems, host, session, version, zabbixServer, zabbixPort, id);
            id += send_tems.Count + 1;
            
        }



        public List<Zabbix_Send_Item> GettingNewData(List<Zabbix_Config_Item>  conf_Items,string host)
        {
            log.Debug("Generating ZabbixRR From Config items");

            ZabbixRR zabbixRR = new ZabbixRR();

            zabbixRR.Request = CreateZabbixRRRequest(conf_Items, host);

            
            log.Debug("Dev_Process Invoke");
            RequestReceived?.Invoke(this, zabbixRR);
            if (zabbixRR.Response == null)
            {
                log.Error($"Response is null, Example did not send data back hostname you tried to get: {host}");
                throw new DevNameDoesntMatchException($"Response is null, Example did not send data back hostname you tried to get: {host}");
            }
            log.Debug("Convert FromZabbixRR To ZabbixSendItem List");

            List<Zabbix_Send_Item> send_tems = ConvertFromZabbixRRToZabbixSendItemList(zabbixRR, host);
            return send_tems;
        }

        public void SendingData(List<Zabbix_Send_Item> send_tems,string host,string session, string version,string zabbixServer,int zabbixPort,int id)
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
                    string dataRespond = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, agentDataPayload);
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
                        string dataRespond = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, agentDataPayload);
                        log.Info($"Data response: {dataRespond}");
                        break;
                    }
                }
            }
        }


        
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

        public void Stop()
        {
            HBtimer.AutoReset = false;
            HBtimer.Enabled = false;
            DATAtimer.AutoReset = false;
            DATAtimer.Enabled = false;
            configTimer.AutoReset = false;
            configTimer.Enabled = false;

            log.Info("AGENT SHUT DOWN Name: "+this.GetType().Name);
        }

        public event EventHandler<ZabbixRR> RequestReceived;

        bool IsConfigDone()
        {
            return !(zabbixServer == null | zabbixPort ==0 | host == null| version != null | heartbeat_freq ==0);
        }

        public void SendingHeartbeat()
        {
            log.Info("Sending Heartbeat to server");
            string response = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, heartbeatPayload);
            log.Debug("Heartbeat response:" + response);
        }
    }
}
