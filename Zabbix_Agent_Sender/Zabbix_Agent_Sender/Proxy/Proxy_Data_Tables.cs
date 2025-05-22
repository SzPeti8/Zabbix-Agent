using System.Globalization;
using System.Text.Json.Serialization;



public partial class Zabbix_Serializables
{
    #region config
    public class Proxy_Data_Item
    {

        public List<string> fields { get; set; }
        public List<List<object>> data { get; set; }
    }

    public class Proxy_Data_Hosts : Proxy_Data_Item { }

    public class Proxy_Data_interface : Proxy_Data_Item { }

    public class Proxy_Data_interface_snmp : Proxy_Data_Item { }

    public class Proxy_Data_host_inventory : Proxy_Data_Item { }

    public class Proxy_Data_items : Proxy_Data_Item { }

    public class Proxy_Data_item_rtdata : Proxy_Data_Item { }

    public class Proxy_Data_item_preproc : Proxy_Data_Item { }

    public class Proxy_Data_item_parameter : Proxy_Data_Item { }

    public class Proxy_Data_globalmacro : Proxy_Data_Item { }

    public class Proxy_Data_hosts_templates : Proxy_Data_Item { }

    public class Proxy_Data_hostmacro : Proxy_Data_Item { }

    public class Proxy_Data_drules : Proxy_Data_Item { }

    public class Proxy_Data_dchecks : Proxy_Data_Item { }

    public class Proxy_Data_regexps : Proxy_Data_Item { }

    public class Proxy_Data_expressions : Proxy_Data_Item { }

    public class Proxy_Data_config : Proxy_Data_Item { }

    public class Proxy_Data_httptest : Proxy_Data_Item { }

    public class Proxy_Data_httptestitem : Proxy_Data_Item { }

    public class Proxy_Data_httptest_field : Proxy_Data_Item { }

    public class Proxy_Data_httpstep : Proxy_Data_Item { }

    public class Proxy_Data_httpstepitem : Proxy_Data_Item { }

    public class Proxy_Data_httpstep_field : Proxy_Data_Item { }

    public class Proxy_Data_config_autoreg_tls : Proxy_Data_Item { }

    public class Proxy_Data_items_Item
    {
        public long itemid { get; set; }
        public long type { get; set; }
        public string snmp_oid { get; set; }
        public long hostid { get; set; }
        public string key_ { get; set; }
        public string delay { get; set; }
        public string history { get; set; }
        public long status { get; set; }
        public long value_type { get; set; }
        public string trapper_hosts { get; set; }
        public string logtimefmt { get; set; }
        [JsonPropertyName("params")]
        public string @params { get; set; }
        public string ipmi_sensor { get; set; }
        public long authtype { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string publickey { get; set; }

        public string privatekey { get; set; }
        public long flags { get; set; }
        public string? interfaceid { get; set; }
        public long inventory_link { get; set; }
        public string jmx_endpoint { get; set; }
        public long? master_itemid { get; set; }
        public string timeout { get; set; }
        public string url { get; set; }
        public string query_fields { get; set; }
        public string posts { get; set; }
        public string status_codes { get; set; }
        public long follow_redirects { get; set; }
        public long post_type { get; set; }
        public string http_proxy { get; set; }
        public string headers { get; set; }
        public long retrieve_mode { get; set; }
        public long request_method { get; set; }
        public long output_format { get; set; }
        public string ssl_cert_file { get; set; }
        public string ssl_key_file { get; set; }
        public string ssl_key_password { get; set; }
        public long verify_peer { get; set; }
        public long verify_host { get; set; }
        public long allow_traps { get; set; }

        public Proxy_Data_items_Item(List<object> list)
        {
            if (list.Count == 41)
            {
                this.itemid = (long)list[0];
                this.type = (long)list[1];
                this.snmp_oid = (string)list[2];
                this.hostid = (long)list[3];
                this.key_ = (string)list[4];
                this.delay = (string)list[5];
                this.history = (string)list[6];
                this.status = (long)list[7];
                this.value_type = (long)list[8];
                this.trapper_hosts = (string)list[9];
                this.logtimefmt = (string)list[10];
                this.@params = (string)list[11];
                this.ipmi_sensor = (string)list[12];
                this.authtype = (long)list[13];
                this.username = (string)list[14];
                this.password = (string)list[15];
                this.publickey = (string)list[16];
                this.privatekey = (string)list[17];
                this.flags = (long)list[18];
                this.interfaceid = (string?)list[19];
                this.inventory_link = (long)list[20];
                this.jmx_endpoint = (string)list[21];
                this.master_itemid = (long?)list[22];
                this.timeout = (string)list[23];
                this.url = (string)list[24];
                this.query_fields = (string)list[25];
                this.posts = (string)list[26];
                this.status_codes = (string)list[27];
                this.follow_redirects = (long)list[28];
                this.post_type = (long)list[29];
                this.http_proxy = (string)list[30];
                this.headers = (string)list[31];
                this.retrieve_mode = (long)list[32];
                this.request_method = (long)list[33];
                this.output_format = (long)list[34];
                this.ssl_cert_file = (string)list[35];
                this.ssl_key_file = (string)list[36];
                this.ssl_key_password = (string)list[37];
                this.verify_peer = (long)list[38];
                this.verify_host = (long)list[39];
                this.allow_traps = (long)list[40];
            }
            else
            {

            }

        }
        public Proxy_Data_items_Item()
        {
        }

    }

    public class Proxy_Data_interface_Item
    {
        public long interfaceid { get; set; }
        public long hostid { get; set; }
        public long main { get; set; }
        public long type { get; set; }
        public long useip { get; set; }
        public string ip { get; set; }
        public string dns { get; set; }
        public string port { get; set; }
        public long available { get; set; }

        public Proxy_Data_interface_Item(List<object> list)
        {
            if (list.Count == 9)
            {
                this.interfaceid = (long)list[0];
                this.hostid = (long)list[1];
                this.main = (long)list[2];
                this.type = (long)list[3];
                this.useip = (long)list[4];
                this.ip = (string)list[5];
                this.dns = (string)list[6];
                this.port = (string)list[7];
                this.available = (long)list[8];
            }

        }


        public Proxy_Data_interface_Item() { }
    }

    public class Proxy_Data_Hosts_Item
    {
        public long hostid { get; set; }
        public string host { get; set; }
        public long status { get; set; }
        public long ipmi_authtype { get; set; }
        public long ipmi_privilege { get; set; }
        public string ipmi_username { get; set; }
        public string ipmi_password { get; set; }
        public string name { get; set; }
        public long tls_connect { get; set; }
        public long tls_accept { get; set; }
        public string tls_issuer { get; set; }
        public string tls_subject { get; set; }
        public string tls_psk_identity { get; set; }
        public string tls_psk { get; set; }

        public Proxy_Data_Hosts_Item(List<object> list)
        {
            if (list.Count == 14)
            {
                this.hostid = (long)list[0];
                this.host = (string)list[1];
                this.status = (long)list[2];
                this.ipmi_authtype = (long)list[3];
                this.ipmi_privilege = (long)list[4];
                this.ipmi_username = (string)list[5];
                this.ipmi_password = (string)list[6];
                this.name = (string)list[7];
                this.tls_connect = (long)list[8];
                this.tls_accept = (long)list[9];
                this.tls_issuer = (string)list[10];
                this.tls_subject = (string)list[11];
                this.tls_psk_identity = (string)list[12];
                this.tls_psk = (string)list[13];
            }

        }

        public Proxy_Data_Hosts_Item() { }

    }
    #endregion


    #region dataRequest

    public class interfaceAvailability
    {
        public long interfaceid { get; set; }
        public long available { get; set; }
        public string error { get; set; }
    }

    public class historyData
    {

        public int id { get; set; }
        public long itemid { get; set; }
        public long clock { get; set; }
        public long ns { get; set; }
        public string value { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? timestamp { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? source { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? severity { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? eventid { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? state { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? lastlogsize { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? mtime { get; set; }


        public historyData(object value, long itemid)
        {
            this.value = Convert.ToString(value, CultureInfo.InvariantCulture);
            this.itemid = itemid;
            this.clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            this.ns = 0;
        }

        public void SetValue(object newValue)
        {
            value = Convert.ToString(newValue, CultureInfo.InvariantCulture);
        }
    }

    public class discoveryData
    {
        public long clock { get; set; }
        public long druleid { get; set; }
        public long dcheckid { get; set; }
        public long type { get; set; }
        public string ip { get; set; }
        public string dns { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? port { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? key_ { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? value { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? status { get; set; }

    }

    public class autoRegistration
    {
        public long clock { get; set; }
        public string host { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ip { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? dns { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? port { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? host_metadata { get; set; }
    }

    public class hostData
    {
        public long hostid { get; set; }
        public long active_status { get; set; }
    }

    public class tasks
    {
        public long type { get; set; }
        public long status { get; set; }
        public string? error { get; set; }
        public long parent_taskid { get; set; }
    }


    #endregion
}

