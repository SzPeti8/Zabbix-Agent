using System;
using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender
{

	public interface IExample
	{
		
		ZabbixRR Dev_Process(ZabbixRR zabbixRR);
		
		Zabbix_Send_Item GettingData(Zabbix_Send_Item item);

		string GetDevName();
    }
}