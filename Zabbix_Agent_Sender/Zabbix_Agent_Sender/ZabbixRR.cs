using static Zabbix_Serializables;
namespace Zabbix_Agent_Sender
{

    public class ZabbixRR : EventArgs
    {
        public Zabbix_Dev_Request Request { get; set; }

        //lehet átkell irni send itemre
        public Zabbix_Dev_Response Response { get; set; }
        public CancellationToken CancellationToken { get; set; }
    }
}
