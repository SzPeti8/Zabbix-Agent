namespace ZabbixAgent
{
    public class Agent : IAgent
    {
        public void Init(string servername, int port)
        {
            // TODO: konfig beállítások betöltése
        }

        public void Start()
        { 
        // pl elindit egy timert, 
        
        }

        public void Stop()
        { 
        //leállitja a timert
        
        }

        public void Process()
        {
            //timer elapsaben meghivjuk a processt

            var rr = new ZAbbixRR()
            {
                Request = new ZabbixRequest()
                {
                    Hostname = "localhost",
                    Key = "system.uptime"
                }
            };
            RequestReceived?.Invoke(this, rr);

           //response felépítése 

            Console.WriteLine(rr.Response.Value);
        }

        public event EventHandler<ZAbbixRR> RequestReceived;
    }
}
