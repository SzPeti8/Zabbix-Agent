using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender
{
    public class Example_Utils
    {
        public static Zabbix_Dev_Request_Response CreateZabbixRRRequest(List<Zabbix_Config_Item> itemList,string hostname)
        {
            Zabbix_Dev_Request_Response zabbix_Dev_Request_Response = new Zabbix_Dev_Request_Response();
            zabbix_Dev_Request_Response.hostName = hostname;
            List < Zabbix_Send_Item > devItems = new List<Zabbix_Send_Item>();
            for (int i = 0; i < itemList.Count; i++)
            {
                devItems.Add (new Zabbix_Send_Item(itemList[i].key, itemList[i].itemId));
            }
            zabbix_Dev_Request_Response.data = devItems;
            return zabbix_Dev_Request_Response;
        }

        public static List<Zabbix_Send_Item> ConvertFromZabbixRRToZabbixSendItemList(ZabbixRR zabbixRR, string hostname)
        {
            List<Zabbix_Send_Item> SendItems =  new List<Zabbix_Send_Item>();
            for (int i = 0;zabbixRR.Response.data.Count> i;i++ )
            {
                if (zabbixRR.Response.data[i].value != null)
                {
                    SendItems.Add(zabbixRR.Response.data[i]);
                }
            }

            return SendItems;
        }

    }
}
