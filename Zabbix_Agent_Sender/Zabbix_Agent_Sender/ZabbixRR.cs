using System;
using static Zabbix_Serializables;
namespace Zabbix_Agent_Sender
{

    public class ZabbixRR : EventArgs
    {
        public Zabbix_Dev_Request_Response Request { get; set; }

        //lehet átkell irni send itemre
        public Zabbix_Dev_Request_Response Response { get; set; }
    }
}
