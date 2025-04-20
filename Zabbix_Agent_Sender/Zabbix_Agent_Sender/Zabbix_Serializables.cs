using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Zabbix_Serializables
{
    public class ZabbixResponse
    {
        public string response { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? configRevision { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Zabbix_Config_Item>? data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? info { get; set; }


    }

    

    public class Zabbix_Config_Item
    {
        public string key { get; set; }
        public int itemId { get; set; }
        public string delay { get; set; }
        public int lastlogsize { get; set; }
        public int mtime { get; set; }
    }

    public class Zabbix_Send_Item
    {
        public Zabbix_Send_Item(string key, int itemId)
        {
            this.key = key;
            this.itemid = itemId;

        }
        public Zabbix_Send_Item()
        {
        }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? host {  get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? key { get; set; }
        public int itemid { get; set; }
        public string value { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? lastlogsize { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? state { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? source { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? eventid { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? severity { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? timestamp { get; set; }
        public long clock { get; set; }
        public long ns { get; set; }

        //TODO: megirni a settereket a többire
        public void SetValue(int newValue)
        {
            value = newValue.ToString();
        }

    }



    public class Zabbix_Send_Request
    {
        public string request { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Zabbix_Send_Item>? data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? session { get; set; }
        public string host { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? version { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? heartbeat_freq { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? config_revision { get; set; }
    }
    
    //TODO: örökoltessem a request responsoet legyen kulon response, és requests
    public class Zabbix_Dev_Request_Response
    {
        public string hostName { get; set; } 
        public List<Zabbix_Send_Item> data { get; set; }
    }
    





}
