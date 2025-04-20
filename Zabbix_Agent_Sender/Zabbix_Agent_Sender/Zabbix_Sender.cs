using System;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using static Zabbix_Active_Sender_Utils;
using static Zabbix_Serializables;



 
public class Zabbix_Active_Sender
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public static string Zabbix_Active_Request_Sender_Normal(string zabbixServer,int zabbixPort,string jsonPayload)
	{
        try
        {
            log.Debug("Kapcsolódás a Zabbix szerverhez...");
            //Console.WriteLine("Kapcsolódás a Zabbix szerverhez...");
            using (TcpClient client = new TcpClient(zabbixServer, zabbixPort))
            {
                log.Debug("Sikeres kapcsolat!");
                //Console.WriteLine("Sikeres kapcsolat!");

                NetworkStream stream = client.GetStream();
                byte[] packet = CompilePacketTOSend(jsonPayload);
                log.Debug($"Küldés Zabbixnak: {jsonPayload}");
                //Console.WriteLine($"Küldés Zabbixnak: {jsonPayload}");
                stream.Write(packet, 0, packet.Length);
                byte[] responseBuffer = new byte[30000]; // 8 KB buffer
                int totalBytesRead = 0;
                int bytesRead;

                do
                {
                    bytesRead = stream.Read(responseBuffer, totalBytesRead, responseBuffer.Length - totalBytesRead);
                    totalBytesRead += bytesRead;

                    // Ha a fogadás véget ért, kilépünk
                    if (bytesRead == 0) break;
                }
                while (totalBytesRead < 13 || totalBytesRead < 13 + BitConverter.ToInt32(responseBuffer, 5));
                log.Debug($" Beolvasott bájtok: {totalBytesRead}");
                //Console.WriteLine($" Beolvasott bájtok: {totalBytesRead}");
                log.Debug("Converting Response to int");
                int jsonLength = BitConverter.ToInt32(responseBuffer, 5);
                log.Debug("Converting Response to string");
                string jsonResponse = Encoding.UTF8.GetString(responseBuffer, 13, jsonLength);
               

                if (jsonResponse.Contains("config_revision"))
                {
                    log.Info($" JSON válasz: Config File");
                    //Console.WriteLine($" JSON válasz: Config File");

                }
                else
                {
                    log.Info($" JSON válasz: {jsonResponse}");
                    //Console.WriteLine($" JSON válasz: {jsonResponse}");
                }

                return jsonResponse;
            }
        }
        catch (Exception ex)
        {
            log.Error("Hiba történt a Zabbix_Active_Sender_Normal-ban: " + ex.Message + "\n" + ex);
            //Console.WriteLine("Hiba történt a Zabbix_Active_Sender_Normal-ban: " + ex.Message + "\n"+ ex);
        }
        log.Error("HIBA: Zabbix_Active_Sender_Normal ln end");
        return "HIBA: Zabbix_Active_Sender_Normal";
    }
}
