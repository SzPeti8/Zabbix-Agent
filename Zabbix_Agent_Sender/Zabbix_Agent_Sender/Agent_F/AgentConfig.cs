using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabbix_Agent_Sender.Agent
{
    public class AgentConfig
    {
        public AgentConfig(string zabbixServer, int zabbixPort, string host, string version, int heartbeat_freq_InMiliSecs, int data_sending_freq_InMiliSecs, int config_data_req_freq_InMiliSecs)
        {
            this.zabbixServer = zabbixServer;
            this.zabbixPort = zabbixPort;
            this.host = host;
            this.version = version;
            this.heartbeat_freq_InMiliSecs = heartbeat_freq_InMiliSecs;
            this.data_sending_freq_InMiliSecs = data_sending_freq_InMiliSecs;
            this.config_data_req_freq_InMiliSecs = config_data_req_freq_InMiliSecs;
        }

        public string zabbixServer { get; set; }
        public int zabbixPort { get; set; }
        public string host { get; set; }
        public string version { get; set; }
        public int heartbeat_freq_InMiliSecs { get; set; }
        public int data_sending_freq_InMiliSecs { get; set;}
        public int config_data_req_freq_InMiliSecs { get; set; }


    }
}
