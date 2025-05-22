using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender.Device
{
    /// <summary>
    /// Provides utility methods for working with Zabbix device requests and send items.
    /// </summary>
    public class Example_Utils
    {
        /// <summary>
        /// Creates a <see cref="Zabbix_Dev_Request"/> object using the specified configuration item and hostname.
        /// </summary>
        /// <param name="itemList">The Zabbix configuration item to include in the request.</param>
        /// <param name="hostname">The hostname to associate with the request.</param>
        /// <returns>A new <see cref="Zabbix_Dev_Request"/> initialized with the provided item and hostname.</returns>
        public static Zabbix_Dev_Request CreateZabbixRRRequest(Zabbix_Config_Item itemList, string hostname)
        {
            Zabbix_Dev_Request zabbix_Dev_Request = new Zabbix_Dev_Request();
            zabbix_Dev_Request.hostName = hostname;
            zabbix_Dev_Request.data = new Zabbix_Send_Item(itemList.key, itemList.itemId);
            return zabbix_Dev_Request;
        }

        /// <summary>
        /// Converts a <see cref="ZabbixRR"/> response to a <see cref="Zabbix_Send_Item"/>.
        /// </summary>
        /// <param name="zabbixRR">The Zabbix request-response object containing the response data.</param>
        /// <param name="hostname">The hostname associated with the request (currently unused).</param>
        /// <returns>The <see cref="Zabbix_Send_Item"/> from the response.</returns>
        public static Zabbix_Send_Item ConvertFromZabbixRRToZabbixSendItem(ZabbixRR zabbixRR, string hostname)
        {
            return zabbixRR.Response.data;
        }
    }
}
