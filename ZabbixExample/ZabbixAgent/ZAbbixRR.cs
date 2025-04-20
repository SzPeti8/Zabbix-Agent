namespace ZabbixAgent
{
    public class ZAbbixRR : EventArgs
    {
        public ZabbixRequest Request { get; set; }
        public ZabbixResponse Response { get; set; }
    }
}
