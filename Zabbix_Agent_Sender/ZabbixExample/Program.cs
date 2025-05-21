using log4net.Config;
using log4net;
using Zabbix_Agent_Sender;
using static Zabbix_Agent_Sender.ZabbixRR;
using static Zabbix_Serializables;
using static Zabbix_Agent_Sender.Device.DevNameDoesntMatchException;
using System.Globalization;
using Zabbix_Agent_Sender.Agent;
using Zabbix_Agent_Sender.Device;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
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

//TODO: Iconfiguration használata a confighoz
log.Debug("Creating AgentConfig");
try
    {
        AgentConfig config = new AgentConfig
        (
        zabbixServer: configuration["ConnectionSettings:ServerAddress"], // Zabbix Server címe
        zabbixPort: int.Parse(configuration["ConnectionSettings:ServerPort"]),  // Alapértelmezett port
        host: configuration["ConnectionSettings:HostName"], // A Zabbix Agentben beállított hostname
        version: configuration["ConnectionSettings:ProtocolVersion"], //Zabbix verzió
        heartbeat_freq_InMiliSecs: int.Parse(configuration["AgentSettings:HeartbeatInterval_InMilisecs"]), //Heartbeat frekvencia
        data_sending_freq_InMiliSecs: int.Parse(configuration["AgentSettings:DataSendInterval_InMilisecs"]),
        config_data_req_freq_InMiliSecs: int.Parse(configuration["AgentSettings:ConfigDataInterval_InMilisecs"])
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
    agent1.Start();

}
catch (DevNameDoesntMatchException e)
{
    log.Error(e.Message +"\n" + $"Example Devname: {devname}");
    manualResetEvent.Set();
}



Console.CancelKeyPress += (sender, e) => { e.Cancel = true; manualResetEvent.Set(); };

manualResetEvent.WaitOne();

agent1.Stop();


async Task Agent_RequestReceivedAsync(object? sender, ZabbixRR zabbixRR)
{
    

    if (zabbixRR.Request.hostName == devname)
    {
        await Task.Delay(rnd.Next(5000),zabbixRR.CancellationToken);
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


string GetDevName()
{
    return devname;
}