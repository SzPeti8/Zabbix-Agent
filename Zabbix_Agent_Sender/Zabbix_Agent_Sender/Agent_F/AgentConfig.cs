using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabbix_Agent_Sender.Agent
{
    public class AgentConfig
    {
        public AgentConfig(string zabbixServer, int zabbixPort, string host, string version, int heartbeat_freq)
        {
            this.zabbixServer = zabbixServer;
            this.zabbixPort = zabbixPort;
            this.host = host;
            this.version = version;
            this.heartbeat_freq = heartbeat_freq;
        }

        public string zabbixServer { get; set; }
        public int zabbixPort { get; set; }
        public string host { get; set; }
        public string version { get; set; }
        public int heartbeat_freq { get; set; }


    }
}
