using System;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using static ZabbixActiveChecks;

class ZabbixActiveChecks
{
    /*static void Main()
    {
        string zabbixServer = "zabbix2.beks.hu";  // Zabbix Server címe
        int zabbixPort = 10051;                   // Alapértelmezett port

        string host = "gyszp_pc1";  // A Zabbix Agentben beállított hostname

        
        string jsonPayload = $"{{\"request\":\"active checks\",\"host\":\"{host}\",\"version\":\"6.2\"}}";

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

                Console.WriteLine($"📨 Küldés Zabbixnak: {jsonPayload}");
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


                //string responseText = Encoding.UTF8.GetString(response, 13, jsonLength);
                Console.WriteLine(" Válasz a Zabbix szervertől:");
                //Console.WriteLine(jsonResponse);

                Console.WriteLine("Proccessed JSON: ");



                //string testText = "{\"response\":\"success\",\"config_revision\":1,\"data\":[{\"key\":\"agent.hostname\",\"itemid\":121031,\"delay\":\"1h\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"agent.ping\",\"itemid\":121032,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"agent.version\",\"itemid\":121033,\"delay\":\"1h\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\Memory\\\\Cache Bytes\\\"]\",\"itemid\":121034,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\Memory\\\\Free System Page Table Entries\\\"]\",\"itemid\":121035,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\Memory\\\\Page Faults/sec\\\"]\",\"itemid\":121036,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\Memory\\\\Pages/sec\\\"]\",\"itemid\":121037,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\Memory\\\\Pool Nonpaged Bytes\\\"]\",\"itemid\":121038,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\Paging file(_Total)\\\\% Usage\\\"]\",\"itemid\":121039,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\Processor Information(_total)\\\\% DPC Time\\\"]\",\"itemid\":121040,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\Processor Information(_total)\\\\% Interrupt Time\\\"]\",\"itemid\":121041,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\Processor Information(_total)\\\\% Privileged Time\\\"]\",\"itemid\":121042,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\Processor Information(_total)\\\\% User Time\\\"]\",\"itemid\":121043,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\System\\\\Context Switches/sec\\\"]\",\"itemid\":121044,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\System\\\\Processor Queue Length\\\"]\",\"itemid\":121045,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"perf_counter_en[\\\"\\\\System\\\\Threads\\\"]\",\"itemid\":121046,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"proc.num[]\",\"itemid\":121047,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"system.cpu.util\",\"itemid\":121048,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"system.hostname\",\"itemid\":121049,\"delay\":\"1h\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"system.localtime\",\"itemid\":121050,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"system.sw.arch\",\"itemid\":121051,\"delay\":\"1h\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"system.sw.os\",\"itemid\":121052,\"delay\":\"1h\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"system.swap.size[,total]\",\"itemid\":121054,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"system.uname\",\"itemid\":121055,\"delay\":\"15m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"system.uptime\",\"itemid\":121056,\"delay\":\"30s\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"vfs.fs.get\",\"itemid\":121057,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"vm.memory.size[total]\",\"itemid\":121058,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"vm.memory.size[used]\",\"itemid\":121059,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"wmi.get[root/cimv2,\\\"Select NumberOfLogicalProcessors from Win32_ComputerSystem\\\"]\",\"itemid\":121061,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"wmi.getall[root\\\\cimv2,\\\"select Name,Description,NetConnectionID,Speed,AdapterTypeId,NetConnectionStatus,GUID from win32_networkadapter where PhysicalAdapter=True and NetConnectionStatus>0\\\"]\",\"itemid\":121062,\"delay\":\"1m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.in[\\\"{65840EDE-5B1B-4BBD-83C0-D8D4E5CF0447}\\\",dropped]\",\"itemid\":121295,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.in[\\\"{84BE2E18-F72F-4BFF-9613-EA53160EBFF5}\\\",dropped]\",\"itemid\":121296,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.in[\\\"{65840EDE-5B1B-4BBD-83C0-D8D4E5CF0447}\\\",errors]\",\"itemid\":121297,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.in[\\\"{84BE2E18-F72F-4BFF-9613-EA53160EBFF5}\\\",errors]\",\"itemid\":121298,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.in[\\\"{65840EDE-5B1B-4BBD-83C0-D8D4E5CF0447}\\\"]\",\"itemid\":121299,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.in[\\\"{84BE2E18-F72F-4BFF-9613-EA53160EBFF5}\\\"]\",\"itemid\":121300,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.out[\\\"{65840EDE-5B1B-4BBD-83C0-D8D4E5CF0447}\\\",dropped]\",\"itemid\":121301,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.out[\\\"{84BE2E18-F72F-4BFF-9613-EA53160EBFF5}\\\",dropped]\",\"itemid\":121302,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.out[\\\"{65840EDE-5B1B-4BBD-83C0-D8D4E5CF0447}\\\",errors]\",\"itemid\":121303,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.out[\\\"{84BE2E18-F72F-4BFF-9613-EA53160EBFF5}\\\",errors]\",\"itemid\":121304,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.out[\\\"{65840EDE-5B1B-4BBD-83C0-D8D4E5CF0447}\\\"]\",\"itemid\":121305,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0},{\"key\":\"net.if.out[\\\"{84BE2E18-F72F-4BFF-9613-EA53160EBFF5}\\\"]\",\"itemid\":121306,\"delay\":\"3m\",\"lastlogsize\":0,\"mtime\":0}]}";


                ZabbixResponse zabbixData = JsonConvert.DeserializeObject<ZabbixResponse>(jsonResponse);

                Console.WriteLine("jsonRESPONSE:LENGTH:");
                Console.WriteLine(jsonResponse.Length);

                Console.WriteLine("Proccessed JSON: ");
                

                Console.WriteLine($"Zabbix válasz: {zabbixData.response}");
                Console.WriteLine($"Konfigurációs verzió: {zabbixData.configRevision}");
                Console.WriteLine($"Ellenőrzések száma: {zabbixData.data.Count}");

                foreach (var check in zabbixData.data)
                {
                    Console.WriteLine($"Kulcs: {check.key},\nID: {check.itemId},\nIdőzítés: {check.delay}");
                    Console.WriteLine("\n");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba történt: " + ex.Message);
        }
    }

    public class ZabbixResponse
    {
        public string response { get; set; }
        public int configRevision { get; set; }
        public List<ZabbixItem> data { get; set; }
    }

    public class ZabbixItem
    {
        public string key { get; set; }
        public int itemId { get; set; }
        public string delay { get; set; }
        public int lastlogsize { get; set; }
        public int mtime { get; set; }
    }*/
}
