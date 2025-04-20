using ZabbixAgent;

var agent = new ZabbixAgent.Agent();
agent.Init("zabbix2.beks.hu", 10051);
agent.RequestReceived += Agent_RequestReceived;

void Agent_RequestReceived(object? sender, ZAbbixRR e)
{
    switch (e.Request.Key)
    {
        case "system.osname":
            e.Response = new ZabbixResponse()
            {
                Value = "Win11"
            };
            break;
    }
}