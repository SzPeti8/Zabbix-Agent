using System.Globalization;
using System.Text.Json.Serialization;



/// <summary>
/// Contains serializable data structures for Zabbix proxy data tables and requests.
/// </summary>
public partial class Zabbix_Serializables
{
    #region config

    /// <summary>
    /// Represents a generic proxy data item with fields and data.
    /// </summary>
    public class Proxy_Data_Item
    {
        /// <summary>
        /// Gets or sets the list of field names.
        /// </summary>
        public List<string> fields { get; set; }

        /// <summary>
        /// Gets or sets the data rows, each as a list of objects.
        /// </summary>
        public List<List<object>> data { get; set; }
    }

    /// <summary>Represents proxy data for hosts.</summary>
    public class Proxy_Data_Hosts : Proxy_Data_Item { }

    /// <summary>Represents proxy data for interfaces.</summary>
    public class Proxy_Data_interface : Proxy_Data_Item { }

    /// <summary>Represents proxy data for SNMP interfaces.</summary>
    public class Proxy_Data_interface_snmp : Proxy_Data_Item { }

    /// <summary>Represents proxy data for host inventory.</summary>
    public class Proxy_Data_host_inventory : Proxy_Data_Item { }

    /// <summary>Represents proxy data for items.</summary>
    public class Proxy_Data_items : Proxy_Data_Item { }

    /// <summary>Represents proxy data for item real-time data.</summary>
    public class Proxy_Data_item_rtdata : Proxy_Data_Item { }

    /// <summary>Represents proxy data for item preprocessing.</summary>
    public class Proxy_Data_item_preproc : Proxy_Data_Item { }

    /// <summary>Represents proxy data for item parameters.</summary>
    public class Proxy_Data_item_parameter : Proxy_Data_Item { }

    /// <summary>Represents proxy data for global macros.</summary>
    public class Proxy_Data_globalmacro : Proxy_Data_Item { }

    /// <summary>Represents proxy data for host templates.</summary>
    public class Proxy_Data_hosts_templates : Proxy_Data_Item { }

    /// <summary>Represents proxy data for host macros.</summary>
    public class Proxy_Data_hostmacro : Proxy_Data_Item { }

    /// <summary>Represents proxy data for discovery rules.</summary>
    public class Proxy_Data_drules : Proxy_Data_Item { }

    /// <summary>Represents proxy data for discovery checks.</summary>
    public class Proxy_Data_dchecks : Proxy_Data_Item { }

    /// <summary>Represents proxy data for regular expressions.</summary>
    public class Proxy_Data_regexps : Proxy_Data_Item { }

    /// <summary>Represents proxy data for expressions.</summary>
    public class Proxy_Data_expressions : Proxy_Data_Item { }

    /// <summary>Represents proxy data for configuration.</summary>
    public class Proxy_Data_config : Proxy_Data_Item { }

    /// <summary>Represents proxy data for HTTP tests.</summary>
    public class Proxy_Data_httptest : Proxy_Data_Item { }

    /// <summary>Represents proxy data for HTTP test items.</summary>
    public class Proxy_Data_httptestitem : Proxy_Data_Item { }

    /// <summary>Represents proxy data for HTTP test fields.</summary>
    public class Proxy_Data_httptest_field : Proxy_Data_Item { }

    /// <summary>Represents proxy data for HTTP steps.</summary>
    public class Proxy_Data_httpstep : Proxy_Data_Item { }

    /// <summary>Represents proxy data for HTTP step items.</summary>
    public class Proxy_Data_httpstepitem : Proxy_Data_Item { }

    /// <summary>Represents proxy data for HTTP step fields.</summary>
    public class Proxy_Data_httpstep_field : Proxy_Data_Item { }

    /// <summary>Represents proxy data for auto-registration TLS configuration.</summary>
    public class Proxy_Data_config_autoreg_tls : Proxy_Data_Item { }

    /// <summary>
    /// Represents a single item in proxy data items.
    /// </summary>
    public class Proxy_Data_items_Item
    {
        /// <summary>Gets or sets the item ID.</summary>
        public long itemid { get; set; }
        /// <summary>Gets or sets the item type.</summary>
        public long type { get; set; }
        /// <summary>Gets or sets the SNMP OID.</summary>
        public string snmp_oid { get; set; }
        /// <summary>Gets or sets the host ID.</summary>
        public long hostid { get; set; }
        /// <summary>Gets or sets the item key.</summary>
        public string key_ { get; set; }
        /// <summary>Gets or sets the delay interval.</summary>
        public string delay { get; set; }
        /// <summary>Gets or sets the history period.</summary>
        public string history { get; set; }
        /// <summary>Gets or sets the item status.</summary>
        public long status { get; set; }
        /// <summary>Gets or sets the value type.</summary>
        public long value_type { get; set; }
        /// <summary>Gets or sets the trapper hosts.</summary>
        public string trapper_hosts { get; set; }
        /// <summary>Gets or sets the log time format.</summary>
        public string logtimefmt { get; set; }
        /// <summary>Gets or sets the item parameters.</summary>
        [JsonPropertyName("params")]
        public string @params { get; set; }
        /// <summary>Gets or sets the IPMI sensor.</summary>
        public string ipmi_sensor { get; set; }
        /// <summary>Gets or sets the authentication type.</summary>
        public long authtype { get; set; }
        /// <summary>Gets or sets the username.</summary>
        public string username { get; set; }
        /// <summary>Gets or sets the password.</summary>
        public string password { get; set; }
        /// <summary>Gets or sets the public key.</summary>
        public string publickey { get; set; }
        /// <summary>Gets or sets the private key.</summary>
        public string privatekey { get; set; }
        /// <summary>Gets or sets the item flags.</summary>
        public long flags { get; set; }
        /// <summary>Gets or sets the interface ID (nullable).</summary>
        public string? interfaceid { get; set; }
        /// <summary>Gets or sets the inventory link.</summary>
        public long inventory_link { get; set; }
        /// <summary>Gets or sets the JMX endpoint.</summary>
        public string jmx_endpoint { get; set; }
        /// <summary>Gets or sets the master item ID (nullable).</summary>
        public long? master_itemid { get; set; }
        /// <summary>Gets or sets the timeout value.</summary>
        public string timeout { get; set; }
        /// <summary>Gets or sets the URL.</summary>
        public string url { get; set; }
        /// <summary>Gets or sets the query fields.</summary>
        public string query_fields { get; set; }
        /// <summary>Gets or sets the POST data.</summary>
        public string posts { get; set; }
        /// <summary>Gets or sets the status codes.</summary>
        public string status_codes { get; set; }
        /// <summary>Gets or sets the follow redirects flag.</summary>
        public long follow_redirects { get; set; }
        /// <summary>Gets or sets the POST type.</summary>
        public long post_type { get; set; }
        /// <summary>Gets or sets the HTTP proxy.</summary>
        public string http_proxy { get; set; }
        /// <summary>Gets or sets the HTTP headers.</summary>
        public string headers { get; set; }
        /// <summary>Gets or sets the retrieve mode.</summary>
        public long retrieve_mode { get; set; }
        /// <summary>Gets or sets the request method.</summary>
        public long request_method { get; set; }
        /// <summary>Gets or sets the output format.</summary>
        public long output_format { get; set; }
        /// <summary>Gets or sets the SSL certificate file.</summary>
        public string ssl_cert_file { get; set; }
        /// <summary>Gets or sets the SSL key file.</summary>
        public string ssl_key_file { get; set; }
        /// <summary>Gets or sets the SSL key password.</summary>
        public string ssl_key_password { get; set; }
        /// <summary>Gets or sets the verify peer flag.</summary>
        public long verify_peer { get; set; }
        /// <summary>Gets or sets the verify host flag.</summary>
        public long verify_host { get; set; }
        /// <summary>Gets or sets the allow traps flag.</summary>
        public long allow_traps { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy_Data_items_Item"/> class from a list of objects.
        /// </summary>
        /// <param name="list">The list of item values.</param>
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
                // Handle invalid list count if needed
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy_Data_items_Item"/> class.
        /// </summary>
        public Proxy_Data_items_Item()
        {
        }
    }

    /// <summary>
    /// Represents a single interface item in proxy data.
    /// </summary>
    public class Proxy_Data_interface_Item
    {
        /// <summary>Gets or sets the interface ID.</summary>
        public long interfaceid { get; set; }
        /// <summary>Gets or sets the host ID.</summary>
        public long hostid { get; set; }
        /// <summary>Gets or sets the main flag.</summary>
        public long main { get; set; }
        /// <summary>Gets or sets the interface type.</summary>
        public long type { get; set; }
        /// <summary>Gets or sets the use IP flag.</summary>
        public long useip { get; set; }
        /// <summary>Gets or sets the IP address.</summary>
        public string ip { get; set; }
        /// <summary>Gets or sets the DNS name.</summary>
        public string dns { get; set; }
        /// <summary>Gets or sets the port.</summary>
        public string port { get; set; }
        /// <summary>Gets or sets the availability status.</summary>
        public long available { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy_Data_interface_Item"/> class from a list of objects.
        /// </summary>
        /// <param name="list">The list of interface values.</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy_Data_interface_Item"/> class.
        /// </summary>
        public Proxy_Data_interface_Item() { }
    }

    /// <summary>
    /// Represents a single host item in proxy data.
    /// </summary>
    public class Proxy_Data_Hosts_Item
    {
        /// <summary>Gets or sets the host ID.</summary>
        public long hostid { get; set; }
        /// <summary>Gets or sets the host name.</summary>
        public string host { get; set; }
        /// <summary>Gets or sets the host status.</summary>
        public long status { get; set; }
        /// <summary>Gets or sets the IPMI authentication type.</summary>
        public long ipmi_authtype { get; set; }
        /// <summary>Gets or sets the IPMI privilege.</summary>
        public long ipmi_privilege { get; set; }
        /// <summary>Gets or sets the IPMI username.</summary>
        public string ipmi_username { get; set; }
        /// <summary>Gets or sets the IPMI password.</summary>
        public string ipmi_password { get; set; }
        /// <summary>Gets or sets the display name.</summary>
        public string name { get; set; }
        /// <summary>Gets or sets the TLS connect mode.</summary>
        public long tls_connect { get; set; }
        /// <summary>Gets or sets the TLS accept mode.</summary>
        public long tls_accept { get; set; }
        /// <summary>Gets or sets the TLS issuer.</summary>
        public string tls_issuer { get; set; }
        /// <summary>Gets or sets the TLS subject.</summary>
        public string tls_subject { get; set; }
        /// <summary>Gets or sets the TLS PSK identity.</summary>
        public string tls_psk_identity { get; set; }
        /// <summary>Gets or sets the TLS PSK.</summary>
        public string tls_psk { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy_Data_Hosts_Item"/> class from a list of objects.
        /// </summary>
        /// <param name="list">The list of host values.</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy_Data_Hosts_Item"/> class.
        /// </summary>
        public Proxy_Data_Hosts_Item() { }
    }
    #endregion

    #region dataRequest

    /// <summary>
    /// Represents the availability status of an interface.
    /// </summary>
    public class interfaceAvailability
    {
        /// <summary>Gets or sets the interface ID.</summary>
        public long interfaceid { get; set; }
        /// <summary>Gets or sets the availability status.</summary>
        public long available { get; set; }
        /// <summary>Gets or sets the error message.</summary>
        public string error { get; set; }
    }

    /// <summary>
    /// Represents a single history data record.
    /// </summary>
    public class historyData
    {
        /// <summary>Gets or sets the record ID.</summary>
        public int id { get; set; }
        /// <summary>Gets or sets the item ID.</summary>
        public long itemid { get; set; }
        /// <summary>Gets or sets the clock (Unix timestamp).</summary>
        public long clock { get; set; }
        /// <summary>Gets or sets the nanoseconds part of the timestamp.</summary>
        public long ns { get; set; }
        /// <summary>Gets or sets the value.</summary>
        public string value { get; set; }
        /// <summary>Gets or sets the optional timestamp.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? timestamp { get; set; }
        /// <summary>Gets or sets the optional source.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? source { get; set; }
        /// <summary>Gets or sets the optional severity.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? severity { get; set; }
        /// <summary>Gets or sets the optional event ID.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? eventid { get; set; }
        /// <summary>Gets or sets the optional state.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? state { get; set; }
        /// <summary>Gets or sets the optional last log size.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? lastlogsize { get; set; }
        /// <summary>Gets or sets the optional modification time.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? mtime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="historyData"/> class with a value and item ID.
        /// </summary>
        /// <param name="value">The value to store.</param>
        /// <param name="itemid">The item ID.</param>
        public historyData(object value, long itemid)
        {
            this.value = Convert.ToString(value, CultureInfo.InvariantCulture);
            this.itemid = itemid;
            this.clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            this.ns = 0;
        }

        /// <summary>
        /// Sets the value using invariant culture.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public void SetValue(object newValue)
        {
            value = Convert.ToString(newValue, CultureInfo.InvariantCulture);
        }
    }

    /// <summary>
    /// Represents a single discovery data record.
    /// </summary>
    public class discoveryData
    {
        /// <summary>Gets or sets the clock (Unix timestamp).</summary>
        public long clock { get; set; }
        /// <summary>Gets or sets the discovery rule ID.</summary>
        public long druleid { get; set; }
        /// <summary>Gets or sets the discovery check ID.</summary>
        public long dcheckid { get; set; }
        /// <summary>Gets or sets the check type.</summary>
        public long type { get; set; }
        /// <summary>Gets or sets the IP address.</summary>
        public string ip { get; set; }
        /// <summary>Gets or sets the DNS name.</summary>
        public string dns { get; set; }
        /// <summary>Gets or sets the port (optional).</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? port { get; set; }
        /// <summary>Gets or sets the key (optional).</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? key_ { get; set; }
        /// <summary>Gets or sets the value (optional).</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? value { get; set; }
        /// <summary>Gets or sets the status (optional).</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? status { get; set; }
    }

    /// <summary>
    /// Represents auto-registration data for a host.
    /// </summary>
    public class autoRegistration
    {
        /// <summary>Gets or sets the clock (Unix timestamp).</summary>
        public long clock { get; set; }
        /// <summary>Gets or sets the host name.</summary>
        public string host { get; set; }
        /// <summary>Gets or sets the IP address (optional).</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ip { get; set; }
        /// <summary>Gets or sets the DNS name (optional).</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? dns { get; set; }
        /// <summary>Gets or sets the port (optional).</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? port { get; set; }
        /// <summary>Gets or sets the host metadata (optional).</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? host_metadata { get; set; }
    }

    /// <summary>
    /// Represents host data with ID and active status.
    /// </summary>
    public class hostData
    {
        /// <summary>Gets or sets the host ID.</summary>
        public long hostid { get; set; }
        /// <summary>Gets or sets the active status.</summary>
        public long active_status { get; set; }
    }

    /// <summary>
    /// Represents a task with type, status, error, and parent task ID.
    /// </summary>
    public class tasks
    {
        /// <summary>Gets or sets the task type.</summary>
        public long type { get; set; }
        /// <summary>Gets or sets the task status.</summary>
        public long status { get; set; }
        /// <summary>Gets or sets the error message (optional).</summary>
        public string? error { get; set; }
        /// <summary>Gets or sets the parent task ID.</summary>
        public long parent_taskid { get; set; }
    }

    #endregion
}

