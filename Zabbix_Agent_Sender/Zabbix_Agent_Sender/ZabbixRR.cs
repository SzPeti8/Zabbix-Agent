using static Zabbix_Serializables;
namespace Zabbix_Agent_Sender
{

    /// <summary>
    /// Represents a request-response pair for Zabbix agent communication, including cancellation support.
    /// </summary>
    public class ZabbixRR : EventArgs
    {
        /// <summary>
        /// Gets or sets the Zabbix device request.
        /// </summary>
        public Zabbix_Dev_Request Request { get; set; }

        /// <summary>
        /// Gets or sets the Zabbix device response.
        /// </summary>
        public Zabbix_Dev_Response Response { get; set; }

        /// <summary>
        /// Gets or sets the cancellation token for the request-response operation.
        /// </summary>
        public CancellationToken CancellationToken { get; set; }
    }
}
