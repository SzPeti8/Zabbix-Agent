/// <summary>
/// Entry point for the Zabbix Agent Sender example application.
/// Initializes logging, loads configuration, creates and starts the agent, and handles incoming Zabbix requests.
/// </summary>
using log4net.Config;
using Microsoft.Extensions.Configuration;
using Zabbix_Agent_Sender;
using Zabbix_Agent_Sender.Agent;
using Zabbix_Agent_Sender.Device;
using static Zabbix_Serializables;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
XmlConfigurator.Configure(new FileInfo("log4net.config"));

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


IAgent agent1 = new Agent();
string devname = configuration["ConnectionSettings:HostName"]; ;
Random rnd = new Random();

ManualResetEvent manualResetEvent = new ManualResetEvent(false);

log.Debug("Creating AgentConfig");
try
{
    /// <summary>
    /// Creates and initializes the agent configuration using values from the application settings.
    /// </summary>
    AgentConfig config = new AgentConfig
    (
    zabbixServer: configuration["ConnectionSettings:ServerAddress"], // Zabbix Server címe
    zabbixPort: int.Parse(configuration["ConnectionSettings:ServerPort"]),  // Alapértelmezett port
    host: configuration["ConnectionSettings:HostName"], // A Zabbix Agentben beállított hostname
    version: configuration["ConnectionSettings:ProtocolVersion"], //Zabbix verzió
    heartbeat_freq_InMiliSecs: int.Parse(configuration["AgentSettings:HeartbeatInterval_InMilisecs"]), //Heartbeat frekvencia
    data_sending_freq_InMiliSecs: int.Parse(configuration["AgentSettings:DataSendInterval_InMilisecs"]),
    config_data_req_freq_InMiliSecs: int.Parse(configuration["AgentSettings:ConfigDataInterval_InMilisecs"]),
    timeout_freq_ForGettingData_inSeconds: int.Parse(configuration["AgentSettings:TimeoutIntervalForGettingData_inSeconds"]),
    maxThreads: int.Parse(configuration["AgentSettings:NumberOfThreads"])
    );
    agent1.Init(config);
    agent1.RequestReceived += Agent_RequestReceivedAsync;
}
catch (Exception e)
{
    log.Error($"Couldnt create config. Error: {e.Message}");
    manualResetEvent.Set();
}

try
{
    /// <summary>
    /// Starts the agent and handles device name mismatch exceptions.
    /// </summary>
    agent1.Start();

}
catch (DevNameDoesntMatchException e)
{
    log.Error(e.Message + "\n" + $"Example Devname: {devname}");
    manualResetEvent.Set();
}

Console.CancelKeyPress += (sender, e) => { e.Cancel = true; manualResetEvent.Set(); };

manualResetEvent.WaitOne();

agent1.Stop();

/// <summary>
/// Handles the RequestReceived event from the agent.
/// Processes incoming Zabbix requests, retrieves device data, and sets the response.
/// </summary>
/// <param name="sender">The event sender.</param>
/// <param name="zabbixRR">The Zabbix request/response object.</param>
async Task Agent_RequestReceivedAsync(object? sender, ZabbixRR zabbixRR)
{
    if (zabbixRR.Request.hostName == devname)
    {
        await Task.Delay(rnd.Next(5000), zabbixRR.CancellationToken);
        zabbixRR.CancellationToken.ThrowIfCancellationRequested();

        Zabbix_Send_Item item = zabbixRR.Request.data;

        try
        {
            log.Debug("Getting data.");
            DeviceGetData.GettingData(item);
        }
        catch (Exception e) { log.Error($"Couldnt get data for: hostname: {devname}, itemid: {item.itemid}, key: {item.key}. Error: {e.Message}"); }

        zabbixRR.Response = new Zabbix_Dev_Response();
        zabbixRR.Response.data = item;
        zabbixRR.Response.hostName = devname;
    }
}

/// <summary>
/// Gets the device name from the configuration.
/// </summary>
/// <returns>The device name as a string.</returns>
string GetDevName()
{
    return devname;
}