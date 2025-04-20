
namespace ZabbixAgent
{
    public interface IAgent
    {
        event EventHandler<ZAbbixRR> RequestReceived;

        void Init(string servername, int port);
        void Process();
        void Start();
        void Stop();
    }
}