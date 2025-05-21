using log4net.Config;
using static Zabbix_Active_Sender_Utils;
using static Zabbix_Active_Sender;
using Zabbix_Agent_Sender.Agent;
using Newtonsoft.Json;
using static Zabbix_Serializables;
using Zabbix_Agent_Sender.Proxy;
using log4net;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

log4net.ILog logProxy = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
XmlConfigurator.Configure(new FileInfo("log4net.config"));

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


ManualResetEvent manualResetEvent = new ManualResetEvent(false);


string devname = configuration["ConnectionSettings:HostName"];
string version = configuration["ConnectionSettings:ProtocolVersion"];
string zabbixServer = configuration["ConnectionSettings:ServerAddress"]; 
int zabbixPort = int.Parse( configuration["ConnectionSettings:ServerPort"]);
int data_sending_interval_inMiliSeconds = int.Parse(configuration["AgentSettings:DataSendInterval_InMilisecs"]);
string session = GenerateSessionID();

System.Timers.Timer DATAtimer;

logProxy.Debug("Creating Config Payload");
string configPayload = CreateProxyConfigPayload(devname, version,session);


string conf_Items_String = Zabbix_Active_Request_Sender_Normal(zabbixServer, zabbixPort, configPayload);
logProxy.Debug("Config request response: \n"+conf_Items_String);

Zabbix_Proxy_Config_Response CONFIG_Response = JsonConvert.DeserializeObject<Zabbix_Proxy_Config_Response>(conf_Items_String);


List<Proxy_Data_items_Item> Conf_items = new List<Proxy_Data_items_Item>();

List<Proxy_Data_Hosts_Item> hosts = new List<Proxy_Data_Hosts_Item>();
List<Proxy_Data_interface_Item> intefaces = new List<Proxy_Data_interface_Item>();

try
{
    List<long> downHosts = new List<long>();
    logProxy.Debug("Getting the Conf_items from the ZabbixData");
    for (int i = 0; CONFIG_Response.data.items.data.Count > i; i++)
    {
        Proxy_Data_items_Item item = new Proxy_Data_items_Item(CONFIG_Response.data.items.data[i]);
        if(item.status == 0)
        {
            Conf_items.Add(item);
        }
        else
        {
            downHosts.Add(item.hostid);
        }
        
    }

    logProxy.Debug("Getting the Hosts from the ZabbixData");
    for (int i = 0; i < CONFIG_Response.data.hosts.data.Count; i++)
    {
        Proxy_Data_Hosts_Item item = new Proxy_Data_Hosts_Item(CONFIG_Response.data.hosts.data[i]);
        if(!downHosts.Contains(item.hostid))
        {
            hosts.Add(item);
        }
        
    }

    logProxy.Debug("Getting the Interfaces from the ZabbixData");
    for (int i = 0; i < CONFIG_Response.data.@interface.data.Count; i++)
    {
        Proxy_Data_interface_Item item = new Proxy_Data_interface_Item(CONFIG_Response.data.@interface.data[i]);
        if (!downHosts.Contains(item.hostid))
        {
            intefaces.Add(item);
        }
        
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

logProxy.Info(server_response_to_data_request);

DATAtimer = new System.Timers.Timer(data_sending_interval_inMiliSeconds);
DATAtimer.Elapsed += async (sender, e) =>
{

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
    
    logProxy.Info(server_response_to_data_request);
};
DATAtimer.AutoReset = true; 
DATAtimer.Enabled = true;

Console.CancelKeyPress += (sender, e) => { e.Cancel = true; manualResetEvent.Set();logProxy.Info($"PROXY SHOT DOWN Name: {devname}"); };

manualResetEvent.WaitOne();
