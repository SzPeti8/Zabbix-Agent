using log4net.Config;
using log4net;
using Zabbix_Agent_Sender;
using static Zabbix_Agent_Sender.ZabbixRR;
using static Zabbix_Serializables;
using static Zabbix_Agent_Sender.DevNameDoesntMatchException;
using System.Globalization;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

 log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
XmlConfigurator.Configure(new FileInfo("log4net.config"));
// A tizedes értékek javítása
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

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
        Thread.Sleep(rnd.Next(1000));

        List<Zabbix_Send_Item> items = zabbixRR.Request.data;
        

        for (int i = 0; items.Count > i; i++)
        {
            try
            {
                items[i] = GettingData(items[i]);
            }
            catch (Exception e) { log.Error($"Couldnt get data for: hostname: {devname}, itemid: {items[i].itemid}, key: {items[i].key}. Error: {e.Message}"); }



        }
        zabbixRR.Response = new Zabbix_Dev_Response();
        zabbixRR.Response.data = items;
        zabbixRR.Response.hostName = devname;

    }
    
}

Zabbix_Send_Item GettingData(Zabbix_Send_Item item)
{
    
    switch (item.key)
    {
        case "perf_counter_en[\"\\Memory\\Cache Bytes\"]":
            item.value = rnd.Next(300645000, 491655168).ToString(); break;

        case "perf_counter_en[\"\\Memory\\Free System Page Table Entries\"]":
            item.value = rnd.Next(1000, 12471498).ToString(); break;


        case "perf_counter_en[\"\\Memory\\Page Faults/sec\"]":
            //TODO: Culture info csere
            //TODO: egyszerűsítés
            item.SetValue(1);
            item.value = (rnd.NextDouble() * 1000).ToString(); break;

        case "perf_counter_en[\"\\Memory\\Pages/sec\"]":
            item.value = (rnd.NextDouble() + 8).ToString(); break;

        case "perf_counter_en[\"\\Memory\\Pool Nonpaged Bytes\"]":
            item.value = rnd.Next(300645000, 491655168).ToString(); break;

        case "perf_counter_en[\"\\Paging file(_Total)\\% Usage\"]":
            item.value = (rnd.NextDouble() * 100).ToString(); break;

        case "perf_counter_en[\"\\Processor Information(_total)\\% DPC Time\"]":
            item.value = (rnd.NextDouble()).ToString(); break;

        case "perf_counter_en[\"\\Processor Information(_total)\\% Interrupt Time\"]":
            item.value = (rnd.NextDouble()).ToString(); break;

        case "perf_counter_en[\"\\Processor Information(_total)\\% Privileged Time\"]":
            item.value = (rnd.NextDouble() + 5).ToString(); break;

        case "perf_counter_en[\"\\Processor Information(_total)\\% User Time\"]":
            item.value = (rnd.NextDouble() + 5).ToString(); break;

        case "perf_counter_en[\"\\System\\Context Switches/sec\"]":
            item.value = (rnd.NextDouble() + 18000).ToString(); break;


        case "perf_counter_en[\"\\System\\Threads\"]":
            item.value = rnd.Next(1000, 5000).ToString(); break;

        case "proc.num[]":
            item.value = rnd.Next(10, 500).ToString(); break;

        case "system.cpu.util":
            item.value = (rnd.NextDouble() * 100).ToString(); break;

        case "system.swap.size[,total]":
            item.value = rnd.Next(19514624, 2095514624).ToString(); break;

        case "system.uptime":
            item.value = rnd.Next(6555, 603482).ToString(); break;

        case "vm.memory.size[total]":
            item.value = rnd.Next(12713088, 1702713088).ToString(); break;

        case "vm.memory.size[used]":
            item.value = rnd.Next(127113088, 170271388).ToString(); break;

        case "wmi.get[root/cimv2,\"Select NumberOfLogicalProcessors from Win32_ComputerSystem\"]":
            item.value = rnd.Next(2, 16).ToString(); break;

    }

    throw new Exception($"Unknown key: {item.key}");
}

string GetDevName()
{
    return devname;
}