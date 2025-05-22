namespace Zabbix_Agent_Sender.Agent_F
{
    /// <summary>
    /// Represents an asynchronous handler for processing Zabbix request-response operations.
    /// </summary>
    /// <param name="sender">The source of the event or request.</param>
    /// <param name="zabbixRR">The <see cref="ZabbixRR"/> instance containing the request, response, and cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public delegate Task AsyncRequestHandler(object? sender, ZabbixRR zabbixRR);
}
