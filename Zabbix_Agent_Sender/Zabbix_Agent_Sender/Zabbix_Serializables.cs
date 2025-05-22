using System.Globalization;
using System.Text.Json.Serialization;

public partial class Zabbix_Serializables
{
    public class ZabbixResponse
    {
        public string response { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? configRevision { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Zabbix_Config_Item>? data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? info { get; set; }


    }



    public class Zabbix_Config_Item
    {
        public string key { get; set; }
        public int itemId { get; set; }
        public string delay { get; set; }
        public int lastlogsize { get; set; }
        public int mtime { get; set; }
    }

    public class Zabbix_Send_Item
    {
        public Zabbix_Send_Item(string key, int itemId)
        {
            this.key = key;
            this.itemid = itemId;

        }
        public Zabbix_Send_Item()
        {
        }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? host { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? key { get; set; }
        public int itemid { get; set; }
        public string value { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? lastlogsize { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? state { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? source { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? eventid { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? severity { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? timestamp { get; set; }
        public long clock { get; set; }
        public long ns { get; set; }


        public void SetValue(object newValue)
        {
            value = Convert.ToString(newValue, CultureInfo.InvariantCulture);
        }

    }



    public class Zabbix_Send_Request
    {
        public string request { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Zabbix_Send_Item>? data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? session { get; set; }
        public string host { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? version { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? heartbeat_freq { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? config_revision { get; set; }
    }

    //TODO: örökoltessem a request responsoet legyen kulon response, és requests-
    public class Zabbix_Dev_Request_Response
    {
        public string hostName { get; set; }
        public Zabbix_Send_Item data { get; set; }
    }

    public class Zabbix_Dev_Request : Zabbix_Dev_Request_Response { }

    public class Zabbix_Dev_Response : Zabbix_Dev_Request_Response { }


    #region proxy

    public class Zabbix_Proxy_Config_Response
    {
        public int full_sync { get; set; }
        public Zabbix_Proxy_Config_Data data { get; set; }
        public int config_revision { get; set; }
    }

    public class Zabbix_Proxy_Config_Data
    {
        public Proxy_Data_Hosts hosts { get; set; }
        [JsonPropertyName("interface")]
        public Proxy_Data_interface @interface { get; set; }
        public Proxy_Data_interface_snmp interface_snmp { get; set; }
        public Proxy_Data_host_inventory host_inventory { get; set; }
        public Proxy_Data_items items { get; set; }
        public Proxy_Data_item_rtdata item_rtdata { get; set; }
        public Proxy_Data_item_preproc item_preproc { get; set; }
        public Proxy_Data_item_parameter item_parameter { get; set; }
        public Proxy_Data_globalmacro globalmacro { get; set; }
        public Proxy_Data_hosts_templates hosts_templates { get; set; }
        public Proxy_Data_hostmacro hostmacro { get; set; }
        public Proxy_Data_drules drules { get; set; }
        public Proxy_Data_dchecks dchecks { get; set; }
        public Proxy_Data_regexps regexps { get; set; }
        public Proxy_Data_expressions expressions { get; set; }
        public Proxy_Data_config config { get; set; }
        public Proxy_Data_httptest httptest { get; set; }
        public Proxy_Data_httptestitem httptestitem { get; set; }
        public Proxy_Data_httptest_field httptest_field { get; set; }
        public Proxy_Data_httpstep httpstep { get; set; }
        public Proxy_Data_httpstepitem httpstepitem { get; set; }
        public Proxy_Data_httpstep_field httpstep_field { get; set; }
        public Proxy_Data_config_autoreg_tls config_autoreg_tls { get; set; }


    }

    public class Zabbix_Proxy_Data_Request
    {
        public string request { get; set; }
        public string host { get; set; }
        public string session { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("interface availability")]
        public List<interfaceAvailability>? interfaceAvailability { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("history data")]
        public List<historyData>? historyData { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("discovery data")]
        public List<discoveryData>? discoveryData { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<autoRegistration>? autoRegistration { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("host data")]
        public List<hostData>? hostDatas { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<tasks>? tasks { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? more { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? clock { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? ns { get; set; }
        public string version { get; set; }

    }

    #endregion





}
