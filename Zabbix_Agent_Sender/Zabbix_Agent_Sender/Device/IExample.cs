using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender.Device
{

    /// <summary>
    /// Defines the contract for a device example that interacts with Zabbix agent sender.
    /// </summary>
    public interface IExample
    {
        /// <summary>
        /// Processes a Zabbix request-response pair for the device.
        /// </summary>
        /// <param name="zabbixRR">The Zabbix request-response object containing the request and response data.</param>
        /// <returns>The processed <see cref="ZabbixRR"/> object.</returns>
        ZabbixRR Dev_Process(ZabbixRR zabbixRR);

        /// <summary>
        /// Retrieves or updates data for a Zabbix send item.
        /// </summary>
        /// <param name="item">The <see cref="Zabbix_Send_Item"/> to get or update data for.</param>
        /// <returns>The updated <see cref="Zabbix_Send_Item"/>.</returns>
        Zabbix_Send_Item GettingData(Zabbix_Send_Item item);

        /// <summary>
        /// Gets the name of the device.
        /// </summary>
        /// <returns>The device name as a string.</returns>
        string GetDevName();
    }
}