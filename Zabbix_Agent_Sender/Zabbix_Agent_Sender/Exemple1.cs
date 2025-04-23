using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender
{
    public class Exemple1 : IExample
    {
        public string devname = "gyszp_pc2";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ZabbixRR Dev_Process(ZabbixRR zabbixRR )
        {
            
            if (zabbixRR.Request.hostName == devname)
            {
                Zabbix_Send_Item item = zabbixRR.Request.data;
   
                    try
                    {
                        item = GettingData(item);
                    }
                    catch(Exception e) { log.Error($"Couldnt get data for: hostname: {devname}, itemid: {item.itemid}, key: {item.key}. Error: {e.Message}"); }

                zabbixRR.Response = new Zabbix_Dev_Response();
                zabbixRR.Response.data = item;
                zabbixRR.Response.hostName = devname;

            }
            return zabbixRR;
        }

        public Zabbix_Send_Item GettingData(Zabbix_Send_Item item)
        {
            Random rnd = new Random();
            switch (item.key)
            {
                case "perf_counter_en[\"\\Memory\\Cache Bytes\"]":
                    item.value = rnd.Next(300645000, 491655168).ToString(); break;

                case "perf_counter_en[\"\\Memory\\Free System Page Table Entries\"]":
                    item.value = rnd.Next(1000, 12471498).ToString(); break;


                case "perf_counter_en[\"\\Memory\\Page Faults/sec\"]":
                    item.value = (rnd.NextDouble() * 1000).ToString().Replace(',', '.'); break;

                case "perf_counter_en[\"\\Memory\\Pages/sec\"]":
                    item.value = (rnd.NextDouble() + 8).ToString().Replace(',','.'); break;

                case "perf_counter_en[\"\\Memory\\Pool Nonpaged Bytes\"]":
                    item.value = rnd.Next(300645000, 491655168).ToString(); break;

                case "perf_counter_en[\"\\Paging file(_Total)\\% Usage\"]":
                    item.value = (rnd.NextDouble() * 100).ToString().Replace(',', '.'); break;

                case "perf_counter_en[\"\\Processor Information(_total)\\% DPC Time\"]":
                    item.value = (rnd.NextDouble()).ToString().Replace(',', '.'); break;

                case "perf_counter_en[\"\\Processor Information(_total)\\% Interrupt Time\"]":
                    item.value = (rnd.NextDouble()).ToString().Replace(',', '.'); break;

                case "perf_counter_en[\"\\Processor Information(_total)\\% Privileged Time\"]":
                    item.value = (rnd.NextDouble() + 5).ToString().Replace(',', '.'); break;

                case "perf_counter_en[\"\\Processor Information(_total)\\% User Time\"]":
                    item.value = (rnd.NextDouble() + 5).ToString().Replace(',', '.'); break;

                case "perf_counter_en[\"\\System\\Context Switches/sec\"]":
                    item.value = (rnd.NextDouble() + 18000).ToString().Replace(',', '.'); break;


                case "perf_counter_en[\"\\System\\Threads\"]":
                    item.value = rnd.Next(1000, 5000).ToString(); break;

                case "proc.num[]":
                    item.value = rnd.Next(10, 500).ToString(); break;

                case "system.cpu.util":
                    item.value = (rnd.NextDouble() * 100).ToString().Replace(',', '.'); break;

                case "system.swap.size[,total]":
                    item.value = rnd.Next(19514624, 2095514624).ToString(); break;

                case "system.uptime":
                    item.value = rnd.Next(6555, 603482).ToString(); break;

                case "vm.memory.size[total]":
                    item.value = rnd.Next(12713088, 1702713088).ToString(); break;

                case "vm.memory.size[used]":
                    item.value = rnd.Next(127113088, 170271388).ToString(); break;

                case "wmi.get[root/cimv2,\"Select NumberOfLogicalProcessors from Win32_ComputerSystem\"]":
                    item.value = rnd.Next(2, 16).ToString(); break;

            }

            throw new Exception($"Unknown key: {item.key}");
        }

        public string GetDevName()
        {
            return devname;
        }
    }
}
