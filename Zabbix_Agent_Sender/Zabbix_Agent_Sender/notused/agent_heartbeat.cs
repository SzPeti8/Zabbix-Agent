using System;
using System.Net.Sockets;
using System.Text;

public class AgentHeartBeat
{
    //IMPLEMENTED IN ZABBIX_SENDER.ZABBIX_ACTIVE_SENDER_NORMAL
    /*static void Main()
    {
        string zabbixServer = "zabbix2.beks.hu";  // Zabbix Server címe
        int zabbixPort = 10051;                   // Alapértelmezett port

        string host = "gyszp_pc1";  // A Zabbix Agentben beállított hostname


        string jsonPayload = $"{{\"request\":\"active check heartbeat\",\"host\":\"{host}\",\"heartbeat_freq\":60}}";

        try
        {
            Console.WriteLine("🔄 Kapcsolódás a Zabbix szerverhez...");
            using (TcpClient client = new TcpClient(zabbixServer, zabbixPort))
            {
                Console.WriteLine("✅ Sikeres kapcsolat!");

                NetworkStream stream = client.GetStream();
                byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonPayload);
                byte[] lengthBytes = BitConverter.GetBytes((long)jsonBytes.Length);

                if (!BitConverter.IsLittleEndian)
                {
                    Array.Reverse(lengthBytes);  // Little-endian módosítás
                }

                byte[] zabbixHeader = Encoding.ASCII.GetBytes("ZBXD\x01");
                byte[] packet = new byte[zabbixHeader.Length + lengthBytes.Length + jsonBytes.Length];

                Buffer.BlockCopy(zabbixHeader, 0, packet, 0, zabbixHeader.Length);
                Buffer.BlockCopy(lengthBytes, 0, packet, zabbixHeader.Length, lengthBytes.Length);
                Buffer.BlockCopy(jsonBytes, 0, packet, zabbixHeader.Length + lengthBytes.Length, jsonBytes.Length);

                Console.WriteLine($"Küldés Zabbixnak: {jsonPayload}");
                stream.Write(packet, 0, packet.Length);
                byte[] responseBuffer = new byte[8192]; // 8 KB buffer
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

                Console.WriteLine($" Beolvasott bájtok: {totalBytesRead}");

                int jsonLength = BitConverter.ToInt32(responseBuffer, 5);
                string jsonResponse = Encoding.UTF8.GetString(responseBuffer, 13, jsonLength);
                Console.WriteLine($" JSON válasz: {jsonResponse}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba történt: " + ex.Message);
        }
    }*/
}
