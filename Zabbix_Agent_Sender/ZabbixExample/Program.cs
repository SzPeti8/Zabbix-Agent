using log4net.Config;
using log4net;
using Zabbix_Agent_Sender;
using static Zabbix_Agent_Sender.ZabbixRR;
using static Zabbix_Serializables;
using static Zabbix_Agent_Sender.Device.DevNameDoesntMatchException;
using System.Globalization;
using Zabbix_Agent_Sender.Agent;
using Zabbix_Agent_Sender.Device;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
XmlConfigurator.Configure(new FileInfo("log4net.config"));


IAgent agent1 = new Agent();
string devname = "gyszp_pc2";
Random rnd = new Random();

ManualResetEvent manualResetEvent = new ManualResetEvent(false);

log.Debug("Creating AgentConfig");
AgentConfig config = new AgentConfig
    (
    zabbixServer: "zabbix2.beks.hu", // Zabbix Server címe
    zabbixPort: 10051,  // Alapértelmezett port
    host: "gyszp_pc2", // A Zabbix Agentben beállított hostname
    version: "6.2", //Zabbix verzió
    heartbeat_freq: 60 //Heartbeat frekvencia
    );

agent1.Init(config);
agent1.RequestReceived += Agent_RequestReceived;

try
{
    agent1.Start();

}
catch (DevNameDoesntMatchException e)
{
    log.Error(e.Message +"\n" + $"Example Devname: {devname}");
    manualResetEvent.Set();
}
//log.Debug("Creating Config Payload");
//string configPayload = CreateConfigPayload(host, version);

//string conf_Items_String = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, configPayload);
//Console.WriteLine(conf_Items_String);


Console.CancelKeyPress += (sender, e) => { e.Cancel = true; manualResetEvent.Set(); };

manualResetEvent.WaitOne();

agent1.Stop();


void Agent_RequestReceived(object? sender, ZabbixRR zabbixRR)
{
    

    if (zabbixRR.Request.hostName == devname)
    {
        //await Task.Delay(rnd.Next(2000),zabbixRR.CancellationToken);
        zabbixRR.CancellationToken.ThrowIfCancellationRequested();
        Thread.Sleep(rnd.Next(2000));

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