using log4net.Config;
using Zabbix_Agent_Sender;
using static Zabbix_Active_Sender_Utils;
using static Zabbix_Active_Sender;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
XmlConfigurator.Configure(new FileInfo("log4net.config"));

IAgent Proxy = new Agent();
string devname = "gyszp_proxy";
string version = "6.4";
string zabbixServer = "zabbix2.beks.hu"; // Zabbix Server címe
int zabbixPort = 10051;
Random rnd = new Random();
string session = GenerateSessionID();

log.Debug("Creating Config Payload");
string configPayload = CreateProxyConfigPayload(devname, version,session);

//converting response to stringnél hibát dob, mert a kezdő buffer nem elég nagy
string conf_Items_String = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, configPayload);
Console.WriteLine(conf_Items_String);