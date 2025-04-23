using System;
using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender.Agent
{
    public interface IAgent
    {
        event EventHandler<ZabbixRR> RequestReceived;

        void Init(AgentConfig config);
        void Process(List<Zabbix_Config_Item> conf_Items);
        void Start();
        void Stop();
    }
}

