namespace ZabbixAgent
{
    public class AgentGenerator
    {
        public static IAgent CreateAgent(string server, string ip)
        {
            if (ip == "1.2.3.4")
                return new Agent();

            return new Agent7();
        }
    }
}
