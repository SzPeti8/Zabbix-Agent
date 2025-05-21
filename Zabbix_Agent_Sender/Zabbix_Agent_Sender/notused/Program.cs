using System;
using System.Net.Sockets;
using System.Text;
using static Zabbix_Active_Sender;
using static Zabbix_Serializables;
using static Zabbix_Active_Sender_Utils;
using log4net.Config;
using Zabbix_Agent_Sender.Agent;



[assembly: log4net.Config.XmlConfigurator(Watch = true)]


log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
IAgent agent = new Agent();

ManualResetEvent manualResetEvent = new ManualResetEvent(false);

XmlConfigurator.Configure(new FileInfo("log4net.config"));
log.Debug("Creating AgentConfig");
//AgentConfig config = new AgentConfig
//    (
//    zabbixServer: "zabbix2.beks.hu", // Zabbix Server címe
//    zabbixPort: 10051,  // Alapértelmezett port
//    host: "gyszp_pc2", // A Zabbix Agentben beállított hostname
//    version: "6.2", //Zabbix verzió
//    heartbeat_freq_InMiliSecs: 60 //Heartbeat frekvencia
//    );

//agent.Init(config);

agent.Start();
//log.Debug("Creating Config Payload");
//string configPayload = CreateConfigPayload(host, version);

//string conf_Items_String = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, configPayload);
//Console.WriteLine(conf_Items_String);


Console.CancelKeyPress += (sender, e) => { e.Cancel = true; manualResetEvent.Set(); };

manualResetEvent.WaitOne();

agent.Stop();
