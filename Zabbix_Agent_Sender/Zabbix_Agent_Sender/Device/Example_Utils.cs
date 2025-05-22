using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender.Device
{
    public class Example_Utils
    {
        public static Zabbix_Dev_Request CreateZabbixRRRequest(Zabbix_Config_Item itemList, string hostname)
        {
            Zabbix_Dev_Request zabbix_Dev_Request = new Zabbix_Dev_Request();
            zabbix_Dev_Request.hostName = hostname;
            zabbix_Dev_Request.data = new Zabbix_Send_Item(itemList.key, itemList.itemId);
            return zabbix_Dev_Request;
        }

        public static Zabbix_Send_Item ConvertFromZabbixRRToZabbixSendItem(ZabbixRR zabbixRR, string hostname)
        {
            //List<Zabbix_Send_Item> SendItems =  new List<Zabbix_Send_Item>();
            //for (int i = 0;zabbixRR.Response.data.Count> i;i++ )
            //{
            //    if (zabbixRR.Response.data[i].value != null)
            //    {
            //        SendItems.Add(zabbixRR.Response.data[i]);
            //    }
            //}

            return zabbixRR.Response.data;
        }

    }
}
