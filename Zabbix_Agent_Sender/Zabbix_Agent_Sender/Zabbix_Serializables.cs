using System.Globalization;
using System.Text.Json.Serialization;

public partial class Zabbix_Serializables
{
    /// <summary>
    /// Represents a response from the Zabbix server.
    /// </summary>
    public class ZabbixResponse
    {
        /// <summary>
        /// The response type or status.
        /// </summary>
        public string response { get; set; }

        /// <summary>
        /// The configuration revision, if available.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? configRevision { get; set; }

        /// <summary>
        /// The list of configuration items returned in the response.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Zabbix_Config_Item>? data { get; set; }

        /// <summary>
        /// Additional information about the response.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? info { get; set; }
    }

    /// <summary>
    /// Represents a configuration item in Zabbix.
    /// </summary>
    public class Zabbix_Config_Item
    {
        /// <summary>
        /// The item key.
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// The item ID.
        /// </summary>
        public int itemId { get; set; }

        /// <summary>
        /// The delay interval for the item.
        /// </summary>
        public string delay { get; set; }

        /// <summary>
        /// The last log size.
        /// </summary>
        public int lastlogsize { get; set; }

        /// <summary>
        /// The modification time.
        /// </summary>
        public int mtime { get; set; }
    }

    /// <summary>
    /// Represents an item to be sent to Zabbix.
    /// </summary>
    public class Zabbix_Send_Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Zabbix_Send_Item"/> class with the specified key and item ID.
        /// </summary>
        /// <param name="key">The item key.</param>
        /// <param name="itemId">The item ID.</param>
        public Zabbix_Send_Item(string key, int itemId)
        {
            this.key = key;
            this.itemid = itemId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Zabbix_Send_Item"/> class.
        /// </summary>
        public Zabbix_Send_Item()
        {
        }

        /// <summary>
        /// The unique identifier for the send item.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? id { get; set; }

        /// <summary>
        /// The host associated with the item.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? host { get; set; }

        /// <summary>
        /// The item key.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? key { get; set; }

        /// <summary>
        /// The item ID.
        /// </summary>
        public int itemid { get; set; }

        /// <summary>
        /// The value to be sent.
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// The last log size, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? lastlogsize { get; set; }

        /// <summary>
        /// The state of the item, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? state { get; set; }

        /// <summary>
        /// The source of the item, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? source { get; set; }

        /// <summary>
        /// The event ID, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? eventid { get; set; }

        /// <summary>
        /// The severity of the item, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? severity { get; set; }

        /// <summary>
        /// The timestamp of the item, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? timestamp { get; set; }

        /// <summary>
        /// The clock value (seconds since epoch).
        /// </summary>
        public long clock { get; set; }

        /// <summary>
        /// The nanoseconds part of the timestamp.
        /// </summary>
        public long ns { get; set; }

        /// <summary>
        /// Sets the value of the item using the invariant culture.
        /// </summary>
        /// <param name="newValue">The new value to set.</param>
        public void SetValue(object newValue)
        {
            value = Convert.ToString(newValue, CultureInfo.InvariantCulture);
        }
    }

    /// <summary>
    /// Represents a request to send items to Zabbix.
    /// </summary>
    public class Zabbix_Send_Request
    {
        /// <summary>
        /// The request type.
        /// </summary>
        public string request { get; set; }

        /// <summary>
        /// The list of items to send.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Zabbix_Send_Item>? data { get; set; }

        /// <summary>
        /// The session identifier, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? session { get; set; }

        /// <summary>
        /// The host name.
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// The protocol version, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? version { get; set; }

        /// <summary>
        /// The heartbeat frequency, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? heartbeat_freq { get; set; }

        /// <summary>
        /// The configuration revision, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? config_revision { get; set; }
    }

    /// <summary>
    /// Represents a development request or response containing a host name and a data item.
    /// </summary>
    public class Zabbix_Dev_Request_Response
    {
        /// <summary>
        /// The host name.
        /// </summary>
        public string hostName { get; set; }

        /// <summary>
        /// The data item.
        /// </summary>
        public Zabbix_Send_Item data { get; set; }
    }

    /// <summary>
    /// Represents a development request.
    /// </summary>
    public class Zabbix_Dev_Request : Zabbix_Dev_Request_Response { }

    /// <summary>
    /// Represents a development response.
    /// </summary>
    public class Zabbix_Dev_Response : Zabbix_Dev_Request_Response { }

    #region proxy

    /// <summary>
    /// Represents a response containing proxy configuration data.
    /// </summary>
    public class Zabbix_Proxy_Config_Response
    {
        /// <summary>
        /// Indicates if a full sync is required.
        /// </summary>
        public int full_sync { get; set; }

        /// <summary>
        /// The proxy configuration data.
        /// </summary>
        public Zabbix_Proxy_Config_Data data { get; set; }

        /// <summary>
        /// The configuration revision.
        /// </summary>
        public int config_revision { get; set; }
    }

    /// <summary>
    /// Represents the proxy configuration data.
    /// </summary>
    public class Zabbix_Proxy_Config_Data
    {
        /// <summary>
        /// The hosts data.
        /// </summary>
        public Proxy_Data_Hosts hosts { get; set; }

        /// <summary>
        /// The interface data.
        /// </summary>
        [JsonPropertyName("interface")]
        public Proxy_Data_interface @interface { get; set; }

        /// <summary>
        /// The SNMP interface data.
        /// </summary>
        public Proxy_Data_interface_snmp interface_snmp { get; set; }

        /// <summary>
        /// The host inventory data.
        /// </summary>
        public Proxy_Data_host_inventory host_inventory { get; set; }

        /// <summary>
        /// The items data.
        /// </summary>
        public Proxy_Data_items items { get; set; }

        /// <summary>
        /// The real-time item data.
        /// </summary>
        public Proxy_Data_item_rtdata item_rtdata { get; set; }

        /// <summary>
        /// The item preprocessing data.
        /// </summary>
        public Proxy_Data_item_preproc item_preproc { get; set; }

        /// <summary>
        /// The item parameter data.
        /// </summary>
        public Proxy_Data_item_parameter item_parameter { get; set; }

        /// <summary>
        /// The global macro data.
        /// </summary>
        public Proxy_Data_globalmacro globalmacro { get; set; }

        /// <summary>
        /// The hosts templates data.
        /// </summary>
        public Proxy_Data_hosts_templates hosts_templates { get; set; }

        /// <summary>
        /// The host macro data.
        /// </summary>
        public Proxy_Data_hostmacro hostmacro { get; set; }

        /// <summary>
        /// The discovery rules data.
        /// </summary>
        public Proxy_Data_drules drules { get; set; }

        /// <summary>
        /// The discovery checks data.
        /// </summary>
        public Proxy_Data_dchecks dchecks { get; set; }

        /// <summary>
        /// The regular expressions data.
        /// </summary>
        public Proxy_Data_regexps regexps { get; set; }

        /// <summary>
        /// The expressions data.
        /// </summary>
        public Proxy_Data_expressions expressions { get; set; }

        /// <summary>
        /// The configuration data.
        /// </summary>
        public Proxy_Data_config config { get; set; }

        /// <summary>
        /// The HTTP test data.
        /// </summary>
        public Proxy_Data_httptest httptest { get; set; }

        /// <summary>
        /// The HTTP test item data.
        /// </summary>
        public Proxy_Data_httptestitem httptestitem { get; set; }

        /// <summary>
        /// The HTTP test field data.
        /// </summary>
        public Proxy_Data_httptest_field httptest_field { get; set; }

        /// <summary>
        /// The HTTP step data.
        /// </summary>
        public Proxy_Data_httpstep httpstep { get; set; }

        /// <summary>
        /// The HTTP step item data.
        /// </summary>
        public Proxy_Data_httpstepitem httpstepitem { get; set; }

        /// <summary>
        /// The HTTP step field data.
        /// </summary>
        public Proxy_Data_httpstep_field httpstep_field { get; set; }

        /// <summary>
        /// The configuration for autoregistration TLS.
        /// </summary>
        public Proxy_Data_config_autoreg_tls config_autoreg_tls { get; set; }
    }

    /// <summary>
    /// Represents a request containing proxy data to be sent to Zabbix.
    /// </summary>
    public class Zabbix_Proxy_Data_Request
    {
        /// <summary>
        /// The request type.
        /// </summary>
        public string request { get; set; }

        /// <summary>
        /// The host name.
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// The session identifier.
        /// </summary>
        public string session { get; set; }

        /// <summary>
        /// The list of interface availability data.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("interface availability")]
        public List<interfaceAvailability>? interfaceAvailability { get; set; }

        /// <summary>
        /// The list of history data.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("history data")]
        public List<historyData>? historyData { get; set; }

        /// <summary>
        /// The list of discovery data.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("discovery data")]
        public List<discoveryData>? discoveryData { get; set; }

        /// <summary>
        /// The list of auto registration data.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<autoRegistration>? autoRegistration { get; set; }

        /// <summary>
        /// The list of host data.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("host data")]
        public List<hostData>? hostDatas { get; set; }

        /// <summary>
        /// The list of tasks.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<tasks>? tasks { get; set; }

        /// <summary>
        /// Indicates if there is more data.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? more { get; set; }

        /// <summary>
        /// The clock value (seconds since epoch), if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? clock { get; set; }

        /// <summary>
        /// The nanoseconds part of the timestamp, if applicable.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? ns { get; set; }

        /// <summary>
        /// The protocol version.
        /// </summary>
        public string version { get; set; }
    }

    #endregion
}
