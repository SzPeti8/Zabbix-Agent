using Newtonsoft.Json;
using System.Text;
using Zabbix_Agent_Sender;
using static Zabbix_Serializables;
using JsonSerializer = System.Text.Json.JsonSerializer;


/// <summary>
/// Provides utility methods for constructing, serializing, and deserializing Zabbix agent sender packets and payloads.
/// </summary>
public class Zabbix_Active_Sender_Utils
{
    /// <summary>
    /// The logger instance for this class.
    /// </summary>
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    /// <summary>
    /// Compiles a Zabbix packet from a JSON payload, including the Zabbix header and length prefix.
    /// </summary>
    /// <param name="jsonPayload">The JSON payload to send.</param>
    /// <returns>A byte array representing the complete Zabbix packet.</returns>
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

    /// <summary>
    /// Deserializes a JSON response from the Zabbix server into a <see cref="ZabbixResponse"/> object.
    /// </summary>
    /// <param name="jsonResponse">The JSON response string.</param>
    /// <returns>The deserialized <see cref="ZabbixResponse"/> object.</returns>
    public static ZabbixResponse DeserializeResponseConfig(string jsonResponse)
    {
        log.Debug("Deserializeing config response");
        ZabbixResponse zabbixData = JsonConvert.DeserializeObject<ZabbixResponse>(jsonResponse);

        log.Debug($"jsonRESPONSE.LENGTH: {jsonResponse.Length}");
        log.Info($"Proccessed JSON: \nZabbix válasz: {zabbixData.response}\nKonfigurációs verzió: {zabbixData.configRevision}\nEllenőrzések száma: {zabbixData.data.Count}");

        return zabbixData;
    }

    /// <summary>
    /// Serializes a <see cref="Zabbix_Send_Request"/> object to a JSON string.
    /// </summary>
    /// <param name="request">The request object to serialize.</param>
    /// <returns>The JSON string representation of the request.</returns>
    public static string SerializeSendRequest(Zabbix_Send_Request request)
    {
        log.Debug("Serialize request");
        return JsonSerializer.Serialize(request);
    }

    /// <summary>
    /// Creates a JSON payload for an "active checks" configuration request.
    /// </summary>
    /// <param name="host">The host name.</param>
    /// <param name="version">The protocol version.</param>
    /// <returns>The JSON payload string.</returns>
    public static string CreateConfigPayload(string host, string version)
    {
        Zabbix_Send_Request request = new Zabbix_Send_Request()
        {
            request = "active checks",
            host = host,
            version = version
        };
        log.Debug($"Created Zabbix_Send_Request: {SerializeSendRequest(request)}");
        return SerializeSendRequest(request);
    }

    /// <summary>
    /// Creates a JSON payload for an "active check heartbeat" request.
    /// </summary>
    /// <param name="host">The host name.</param>
    /// <param name="version">The protocol version.</param>
    /// <param name="heartbeat_freq">The heartbeat frequency.</param>
    /// <returns>The JSON payload string.</returns>
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

    /// <summary>
    /// Creates a JSON payload for an "agent data" request.
    /// </summary>
    /// <param name="host">The host name.</param>
    /// <param name="items">The list of items to send.</param>
    /// <param name="session">The session identifier.</param>
    /// <param name="version">The protocol version.</param>
    /// <returns>The JSON payload string.</returns>
    public static string CreateAgentDataPayload(string host, List<Zabbix_Send_Item> items, string session, string version)
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

    /// <summary>
    /// Generates a random session ID consisting of lowercase letters and digits.
    /// </summary>
    /// <param name="length">The length of the session ID. Default is 32.</param>
    /// <returns>The generated session ID string.</returns>
    public static string GenerateSessionID(int length = 32)
    {
        Random random = new Random();

        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        string str = new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        log.Debug($"Created session id: {str}");
        return str;
    }

    /// <summary>
    /// Creates a <see cref="ZabbixRR"/> request-response object from a list of configuration items and a host name.
    /// </summary>
    /// <param name="data">The list of configuration items.</param>
    /// <param name="hostName">The host name.</param>
    /// <returns>A <see cref="ZabbixRR"/> object with the request populated.</returns>
    public static ZabbixRR CreateZabbixRRFromConfig(List<Zabbix_Config_Item> data, string hostName)
    {
        ZabbixRR zabbixRR = new ZabbixRR();
        zabbixRR.Request.hostName = hostName;
        for (int i = 0; data.Count > i; i++)
        {
            zabbixRR.Request.data = (new Zabbix_Send_Item(data[i].key, data[i].itemId));
        }

        return zabbixRR;
    }

    #region Proxy

    /// <summary>
    /// Creates a JSON payload for a "proxy config" request.
    /// </summary>
    /// <param name="host">The host name.</param>
    /// <param name="version">The protocol version.</param>
    /// <param name="session">The session identifier.</param>
    /// <returns>The JSON payload string.</returns>
    public static string CreateProxyConfigPayload(string host, string version, string session)
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

    /// <summary>
    /// Serializes a <see cref="Zabbix_Proxy_Data_Request"/> object to a JSON string.
    /// </summary>
    /// <param name="request">The proxy data request object to serialize.</param>
    /// <returns>The JSON string representation of the proxy data request.</returns>
    public static string SerializeProxySendRequest(Zabbix_Proxy_Data_Request request)
    {
        log.Debug("Serialize request");
        return JsonSerializer.Serialize(request);
    }

    #endregion
}
