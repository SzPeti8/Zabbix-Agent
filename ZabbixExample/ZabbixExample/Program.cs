using ZabbixAgent;

ManualResetEvent manualResetEvent = new ManualResetEvent(false);

IAgent agent = AgentGenerator.CreateAgent("zabbix2.beks.hu", "1.2.3.4");
agent.Init("zabbix2.beks.hu", 10051);
agent.RequestReceived += Agent_RequestReceived;

agent.Start();

Console.CancelKeyPress += (sender, e) => { e.Cancel = true; manualResetEvent.Set(); };

manualResetEvent.WaitOne();

agent.Stop();

// TODO: erőforrások felszabadítása


void Agent_RequestReceived(object? sender, ZAbbixRR e)
{
    //Thread.Sleep(rnd.Next(1000));//program eze npontján vár 
    switch (e.Request.Key)
    {
        case "system.uptime":
            e.Response = new ZabbixResponse()
            {
                Value = "123456"
            };
            break;
    }
}