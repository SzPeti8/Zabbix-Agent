namespace Zabbix_Agent_Sender.Device
{
    public class DevNameDoesntMatchException : Exception
    {
        // Alapértelmezett konstruktor
        public DevNameDoesntMatchException() { }

        // Konstruktor hibaüzenettel
        public DevNameDoesntMatchException(string message)
            : base(message) { }

        // Konstruktor hibaüzenettel és belső kivétellel
        public DevNameDoesntMatchException(string message, Exception inner)
            : base(message, inner) { }
    }
}
