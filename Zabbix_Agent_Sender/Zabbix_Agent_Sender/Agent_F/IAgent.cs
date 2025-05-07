using System;
using Zabbix_Agent_Sender.Agent_F;
using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender.Agent
{
    public interface IAgent
    {
        event AsyncRequestHandler? RequestReceived;

        void Init(AgentConfig config);
        void Process(List<Zabbix_Config_Item> conf_Items);
        void Start();
        void Stop();
    }
}

