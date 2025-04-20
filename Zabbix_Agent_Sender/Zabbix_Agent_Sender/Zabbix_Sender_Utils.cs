using Newtonsoft.Json;
using System;
using System.Text;
using System.Linq;
using static Zabbix_Serializables;
using System.Text.Json.Serialization;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Zabbix_Agent_Sender;


public class Zabbix_Active_Sender_Utils
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public static byte[] CompilePacketTOSend(string jsonPayload)
	{
        log.Debug("Compileing Packet to send");
        log.Debug("Converting payload to bytes");
        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonPayload);
        log.Debug("Getting the length of converted bytes");
        byte[] lengthBytes = BitConverter.GetBytes((long)jsonBytes.Length);

        log.Debug("Little-endian conversion");
        if (!BitConverter.IsLittleEndian)
        {
            Array.Reverse(lengthBytes);  // Little-endian módosítás
        }

        log.Debug("Creating Zabbix header");
        byte[] zabbixHeader = Encoding.ASCII.GetBytes("ZBXD\x01");
        log.Debug("Creating Packet");
        byte[] packet = new byte[zabbixHeader.Length + lengthBytes.Length + jsonBytes.Length];

        Buffer.BlockCopy(zabbixHeader, 0, packet, 0, zabbixHeader.Length);
        Buffer.BlockCopy(lengthBytes, 0, packet, zabbixHeader.Length, lengthBytes.Length);
        Buffer.BlockCopy(jsonBytes, 0, packet, zabbixHeader.Length + lengthBytes.Length, jsonBytes.Length);

        return packet;
    }

    public static ZabbixResponse DeserializeResponseConfig(string jsonResponse)
    {
        log.Debug("Deserializeing config response");
        ZabbixResponse zabbixData = JsonConvert.DeserializeObject<ZabbixResponse>(jsonResponse);

        log.Debug($"jsonRESPONSE.LENGTH: {jsonResponse.Length}");
        //Console.WriteLine("jsonRESPONSE:LENGTH:");
        //Console.WriteLine(jsonResponse.Length);

        log.Info($"Proccessed JSON: \nZabbix válasz: {zabbixData.response}\nKonfigurációs verzió: {zabbixData.configRevision}\nEllenőrzések száma: {zabbixData.data.Count}");

        return zabbixData;
    }

    public static string SerializeSendRequest(Zabbix_Send_Request request)
    {
        log.Debug("Serialize request");
        return JsonSerializer.Serialize(request);
    }

    public static string CreateProxyConfigPayload(string host, string version,string session)
    {

        Zabbix_Send_Request request = new Zabbix_Send_Request()
        {
            
            request = "proxy config",
            host = host,
            version = version,
            session = session,
            config_revision = 0
        };
        log.Debug($"Created Zabbix_Send_Request: {SerializeSendRequest(request)}");
        return SerializeSendRequest(request);
    }

    public static string CreateConfigPayload(string host, string version)
    {
        
        Zabbix_Send_Request request = new Zabbix_Send_Request()
        {
            request = "active checks",
            //request = "proxy config",
            host = host,
            version = version
        };
        log.Debug($"Created Zabbix_Send_Request: {SerializeSendRequest(request)}");
        return SerializeSendRequest(request);
    }

    public static string CreateHeartbeatPayload(string host, string version, int heartbeat_freq)
    {
        Zabbix_Send_Request request = new Zabbix_Send_Request()
        {
            request = "active check heartbeat",
            host = host,
            heartbeat_freq = heartbeat_freq
        };
        log.Debug($"Created Zabbix_Send_Request: {SerializeSendRequest(request)}");
        return SerializeSendRequest(request);
    }

    public static string CreateAgentDataPayload(string host, List<Zabbix_Send_Item> items,string session, string version)
    {
        Zabbix_Send_Request request = new Zabbix_Send_Request()
        {
            request = "agent data",
            data = items,
            session = session,
            host = host,
            version = version
            
        };
        log.Debug($"Created Zabbix_Send_Request: {SerializeSendRequest(request)}");
        return SerializeSendRequest(request);
    }

    public static string GenerateSessionID(int length = 32)
    {
        Random random = new Random();

        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        string str = new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        log.Debug($"Created session id: {str}");
        return str;
    }

    public static ZabbixRR CreateZabbixRRFromConfig(List<Zabbix_Config_Item> data,string hostName)
    {
        ZabbixRR zabbixRR = new ZabbixRR();
        zabbixRR.Request.hostName = hostName;
        for (int i = 0;data.Count>i;i++)
        {
            zabbixRR.Request.data.Add(new Zabbix_Send_Item(data[i].key, data[i].itemId));
        }

        return zabbixRR;
    }

}
