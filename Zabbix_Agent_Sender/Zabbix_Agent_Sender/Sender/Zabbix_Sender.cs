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
        
            log.Debug("Kapcsolódás a Zabbix szerverhez...");

        using (TcpClient client = new TcpClient(zabbixServer, zabbixPort))
        {
            log.Debug("Sikeres kapcsolat!");


            NetworkStream stream = client.GetStream();
            byte[] packet = CompilePacketTOSend(jsonPayload);
            log.Debug($"Küldés Zabbixnak: {jsonPayload}");

            stream.Write(packet, 0, packet.Length);
            

            // Use a MemoryStream to accumulate the response
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[4096]; // Read in 4KB chunks
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, bytesRead);

                    
                    if (ms.Length >= 13)
                    {
                        byte[] temp = ms.ToArray();
                        int jsonPayloadLength = BitConverter.ToInt32(temp, 5);
                        if (ms.Length >= 13 + jsonPayloadLength)
                            break;
                    }
                }

                byte[] responseBuffer = ms.ToArray();
                log.Debug($" Beolvasott bájtok: {responseBuffer.Length}");

                log.Debug("Converting Response to int");

                if (responseBuffer.Length < 13)
                {
                    log.Warn("No or incomplete response received from server.");
                    return "No response or incomplete response from server";
                }

                int jsonLength = BitConverter.ToInt32(responseBuffer, 5);
                log.Debug("Converting Response to string");
                string jsonResponse = Encoding.UTF8.GetString(responseBuffer, 13, jsonLength);


                if (jsonResponse.Contains("config_revision"))
                {
                    log.Info($" JSON válasz: Config File");


                }
                else
                {
                    log.Info($" JSON válasz: {jsonResponse}");

                }

                return jsonResponse;
            }
        }
        
        
        log.Error("HIBA: Zabbix_Active_Sender_Normal ln end");
        return "HIBA: Zabbix_Active_Sender_Normal";
    }
}
