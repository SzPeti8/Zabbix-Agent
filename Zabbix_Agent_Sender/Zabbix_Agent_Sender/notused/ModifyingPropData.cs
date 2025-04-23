using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Zabbix_Serializables;
using static Zabbix_Prop_Data;

namespace Zabbix_Agent_Sender.notused
{
    internal class ModifyingPropData
    {
        public static List<Zabbix_Send_Item> Items()
        {
            Random rnd = new Random();
            List<Zabbix_Send_Item> old = DATA();



            for (int i = 0; i < old.Count; i++)
            {
                switch (old[i].key)
                {
                    case "perf_counter_en[\"\\Memory\\Cache Bytes\"]":
                        old[i].value = rnd.Next(300645000, 491655168).ToString(); break;

                    case "perf_counter_en[\"\\Memory\\Free System Page Table Entries\"]":
                        old[i].value = rnd.Next(1000, 12471498).ToString(); break;


                    case "perf_counter_en[\"\\Memory\\Page Faults/sec\"]":
                        old[i].value = (rnd.NextDouble() * 1000).ToString(); break;

                    case "perf_counter_en[\"\\Memory\\Pages/sec\"]":
                        old[i].value = (rnd.NextDouble() + 8).ToString(); break;

                    case "perf_counter_en[\"\\Memory\\Pool Nonpaged Bytes\"]":
                        old[i].value = rnd.Next(300645000, 491655168).ToString(); break;

                    case "perf_counter_en[\"\\Paging file(_Total)\\% Usage\"]":
                        old[i].value = (rnd.NextDouble() * 100).ToString(); break;

                    case "perf_counter_en[\"\\Processor Information(_total)\\% DPC Time\"]":
                        old[i].value = rnd.NextDouble().ToString(); break;

                    case "perf_counter_en[\"\\Processor Information(_total)\\% Interrupt Time\"]":
                        old[i].value = rnd.NextDouble().ToString(); break;

                    case "perf_counter_en[\"\\Processor Information(_total)\\% Privileged Time\"]":
                        old[i].value = (rnd.NextDouble() + 5).ToString(); break;

                    case "perf_counter_en[\"\\Processor Information(_total)\\% User Time\"]":
                        old[i].value = (rnd.NextDouble() + 5).ToString(); break;

                    case "perf_counter_en[\"\\System\\Context Switches/sec\"]":
                        old[i].value = (rnd.NextDouble() + 18000).ToString(); break;


                    case "perf_counter_en[\"\\System\\Threads\"]":
                        old[i].value = rnd.Next(1000, 5000).ToString(); break;

                    case "proc.num[]":
                        old[i].value = rnd.Next(10, 500).ToString(); break;

                    case "system.cpu.util":
                        old[i].value = (rnd.NextDouble() * 100).ToString(); break;

                    case "system.swap.size[,total]":
                        old[i].value = rnd.Next(19514624, 2095514624).ToString(); break;

                    case "system.uptime":
                        old[i].value = rnd.Next(6555, 603482).ToString(); break;

                    case "vm.memory.size[total]":
                        old[i].value = rnd.Next(12713088, 1702713088).ToString(); break;

                    case "vm.memory.size[used]":
                        old[i].value = rnd.Next(127113088, 170271388).ToString(); break;

                    case "wmi.get[root/cimv2,\"Select NumberOfLogicalProcessors from Win32_ComputerSystem\"]":
                        old[i].value = rnd.Next(2, 16).ToString(); break;

                }
            }

            return old;
        }
    }
}
