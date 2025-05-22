namespace Zabbix_Agent_Sender.Agent
{
    /// <summary>
    /// Represents the configuration settings for the Zabbix agent.
    /// </summary>
    public class AgentConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgentConfig"/> class with the specified parameters.
        /// </summary>
        /// <param name="zabbixServer">The address of the Zabbix server.</param>
        /// <param name="zabbixPort">The port number of the Zabbix server.</param>
        /// <param name="host">The host name or identifier for the agent.</param>
        /// <param name="version">The version of the agent.</param>
        /// <param name="heartbeat_freq_InMiliSecs">The frequency (in milliseconds) at which heartbeats are sent.</param>
        /// <param name="data_sending_freq_InMiliSecs">The frequency (in milliseconds) at which data is sent.</param>
        /// <param name="config_data_req_freq_InMiliSecs">The frequency (in milliseconds) for requesting configuration data.</param>
        /// <param name="timeout_freq_ForGettingData_inSeconds">The timeout (in seconds) for getting data.</param>
        /// <param name="maxThreads">The maximum number of threads allowed.</param>
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

        /// <summary>
        /// Gets or sets the address of the Zabbix server.
        /// </summary>
        public string zabbixServer { get; set; }

        /// <summary>
        /// Gets or sets the port number of the Zabbix server.
        /// </summary>
        public int zabbixPort { get; set; }

        /// <summary>
        /// Gets or sets the host name or identifier for the agent.
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// Gets or sets the version of the agent.
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// Gets or sets the frequency (in milliseconds) at which heartbeats are sent.
        /// </summary>
        public int heartbeat_freq_InMiliSecs { get; set; }

        /// <summary>
        /// Gets or sets the frequency (in milliseconds) at which data is sent.
        /// </summary>
        public int data_sending_freq_InMiliSecs { get; set; }

        /// <summary>
        /// Gets or sets the frequency (in milliseconds) for requesting configuration data.
        /// </summary>
        public int config_data_req_freq_InMiliSecs { get; set; }

        /// <summary>
        /// Gets or sets the timeout (in seconds) for getting data.
        /// </summary>
        public int timeout_freq_ForGettingData_inSeconds { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of threads allowed.
        /// </summary>
        public int maxThreads { get; set; }
    }
}
