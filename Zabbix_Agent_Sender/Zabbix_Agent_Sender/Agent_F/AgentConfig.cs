namespace Zabbix_Agent_Sender.Agent
{
    public class AgentConfig
    {
        public AgentConfig(string zabbixServer, int zabbixPort, string host, string version,
            int heartbeat_freq_InMiliSecs, int data_sending_freq_InMiliSecs, int config_data_req_freq_InMiliSecs,
            int timeout_freq_ForGettingData_inSeconds, int maxThreads)
        {
            this.zabbixServer = zabbixServer;
            this.zabbixPort = zabbixPort;
            this.host = host;
            this.version = version;
            this.heartbeat_freq_InMiliSecs = heartbeat_freq_InMiliSecs;
            this.data_sending_freq_InMiliSecs = data_sending_freq_InMiliSecs;
            this.config_data_req_freq_InMiliSecs = config_data_req_freq_InMiliSecs;
            this.timeout_freq_ForGettingData_inSeconds = timeout_freq_ForGettingData_inSeconds;
            this.maxThreads = maxThreads;
        }

        public string zabbixServer { get; set; }
        public int zabbixPort { get; set; }
        public string host { get; set; }
        public string version { get; set; }
        public int heartbeat_freq_InMiliSecs { get; set; }
        public int data_sending_freq_InMiliSecs { get; set; }
        public int config_data_req_freq_InMiliSecs { get; set; }
        public int timeout_freq_ForGettingData_inSeconds { get; set; }
        public int maxThreads { get; set; }


    }
}
