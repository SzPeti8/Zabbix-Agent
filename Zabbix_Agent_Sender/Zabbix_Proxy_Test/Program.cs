using log4net.Config;
using static Zabbix_Active_Sender_Utils;
using static Zabbix_Active_Sender;
using Zabbix_Agent_Sender.Agent;
using Newtonsoft.Json;
using static Zabbix_Serializables;
using Zabbix_Agent_Sender.Proxy;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

log4net.ILog logProxy = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
XmlConfigurator.Configure(new FileInfo("log4net.config"));

IAgent Proxy = new Agent();
string devname = "gyszp_proxy";
string version = "6.4";
string zabbixServer = "zabbix2.beks.hu"; // Zabbix Server címe
int zabbixPort = 10051;
Random rnd = new Random();
string session = GenerateSessionID();

logProxy.Debug("Creating Config Payload");
string configPayload = CreateProxyConfigPayload(devname, version,session);

//converting response to stringnél hibát dob, mert a kezdő buffer nem elég nagy
string conf_Items_String = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, configPayload);
logProxy.Debug("Config request response: \n"+conf_Items_String);

Zabbix_Proxy_Config_Response CONFIG_Response = JsonConvert.DeserializeObject<Zabbix_Proxy_Config_Response>(conf_Items_String);

//Console.WriteLine(CONFIG_Response);

List<Proxy_Data_items_Item> Conf_items = new List<Proxy_Data_items_Item>();

List<Proxy_Data_Hosts_Item> hosts = new List<Proxy_Data_Hosts_Item>();
List<Proxy_Data_interface_Item> intefaces = new List<Proxy_Data_interface_Item>();

try
{
    logProxy.Debug("Getting the Conf_items from the ZabbixData");
    for (int i = 0; CONFIG_Response.data.items.data.Count > i; i++)
    {
        Conf_items.Add(new Proxy_Data_items_Item(CONFIG_Response.data.items.data[i]));
    }

    logProxy.Debug("Getting the Hosts from the ZabbixData");
    for (int i = 0; i < CONFIG_Response.data.hosts.data.Count; i++)
    {
        hosts.Add(new Proxy_Data_Hosts_Item(CONFIG_Response.data.hosts.data[i]));
    }

    logProxy.Debug("Getting the Interfaces from the ZabbixData");
    for (int i = 0; i < CONFIG_Response.data.@interface.data.Count; i++)
    {
        intefaces.Add(new Proxy_Data_interface_Item(CONFIG_Response.data.@interface.data[i]));
    }
}
catch (Exception ex)
{
    logProxy.Error("There was an error processing the config response. \n"+ex);
}
Zabbix_Proxy_Data_Request data_Request = new Zabbix_Proxy_Data_Request();

data_Request = await Proxy_Getting_Data.gettingDataFromHosts(Conf_items, hosts, intefaces);



data_Request.request = "proxy data";
data_Request.host = devname;
data_Request.session = session;
data_Request.version = version;
data_Request.clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
data_Request.ns = 0;

string data_Payload = SerializeProxySendRequest(data_Request);

string server_response_to_data_request = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, data_Payload);

logProxy.Debug(server_response_to_data_request);