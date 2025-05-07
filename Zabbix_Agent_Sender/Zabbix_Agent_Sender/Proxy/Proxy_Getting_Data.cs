using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender.Proxy
{
    public class Proxy_Getting_Data
    {
        public async static Task<Zabbix_Proxy_Data_Request> gettingDataFromHosts(List<Proxy_Data_items_Item> Conf_items,
            List<Proxy_Data_Hosts_Item> hosts, List<Proxy_Data_interface_Item> interfaces)
        {
            Zabbix_Proxy_Data_Request data_Request = new Zabbix_Proxy_Data_Request();

            data_Request.interfaceAvailability = new List<interfaceAvailability>();
            for (int i = 0; i < interfaces.Count;i++)
            {
                
                data_Request.interfaceAvailability.Add(new interfaceAvailability()
                {
                    interfaceid = interfaces[i].interfaceid,
                    available = 1,
                    error = ""
                });
            }
            data_Request.hostDatas = new List<hostData>();
            for (int i = 0; i < hosts.Count; i++)
            {
                data_Request.hostDatas.Add(new hostData()
                {
                    hostid = hosts[i].hostid,
                    active_status = 1
                });
            }

            for (int i = 0; i < Conf_items.Count; i++)
            {

            }

            data_Request.historyData = Proxy_Data_Generator.GenerateData(Conf_items);
            



            return data_Request;
        }


    }
}
