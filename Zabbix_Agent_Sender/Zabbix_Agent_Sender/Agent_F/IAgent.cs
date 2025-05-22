using Zabbix_Agent_Sender.Agent_F;
using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender.Agent
{
    /// <summary>
    /// Defines the contract for a Zabbix agent implementation.
    /// </summary>
    public interface IAgent
    {
        /// <summary>
        /// Occurs when an asynchronous request is received by the agent.
        /// </summary>
        event AsyncRequestHandler? RequestReceived;

        /// <summary>
        /// Initializes the agent with the specified configuration.
        /// </summary>
        /// <param name="config">The agent configuration settings.</param>
        void Init(AgentConfig config);

        /// <summary>
        /// Processes the provided list of Zabbix configuration items.
        /// </summary>
        /// <param name="conf_Items">The list of configuration items to process.</param>
        void Process(List<Zabbix_Config_Item> conf_Items);

        /// <summary>
        /// Starts the agent's operation.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the agent's operation.
        /// </summary>
        void Stop();
    }
}

