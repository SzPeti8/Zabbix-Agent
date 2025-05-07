using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender.Proxy
{
    public class Proxy_Data_Generator
    {
        public static List<historyData> GenerateData(List<Proxy_Data_items_Item> items) 
        {
            List<historyData> historyDatas = new List<historyData>();
            Random rnd = new Random();
            for (int i = 0;i<items.Count;i++)
            {
                
                switch (items[i].hostid) 
                {
                    case 11451:
                        switch (items[i].key_)
                        {
                            case "perf_counter_en[\"\\Memory\\Cache Bytes\"]":
                                historyDatas.Add(new historyData(rnd.Next(300645000, 491655168), items[i].itemid)); break;

                            case "perf_counter_en[\"\\Memory\\Free System Page Table Entries\"]":
                               historyDatas.Add(new historyData(rnd.Next(1000, 12471498), items[i].itemid)); break;


                            case "perf_counter_en[\"\\Memory\\Page Faults/sec\"]":

                               historyDatas.Add(new historyData(rnd.NextDouble() * 1000, items[i].itemid)); break;

                            case "perf_counter_en[\"\\Memory\\Pages/sec\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble() + 8, items[i].itemid)); break;

                            case "perf_counter_en[\"\\Memory\\Pool Nonpaged Bytes\"]":
                               historyDatas.Add(new historyData(rnd.Next(300645000, 491655168), items[i].itemid)); break;

                            case "perf_counter_en[\"\\Paging file(_Total)\\% Usage\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble() * 100, items[i].itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% DPC Time\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble(), items[i].itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% Interrupt Time\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble(), items[i].itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% Privileged Time\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble() + 5, items[i].itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% User Time\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble() + 5, items[i].itemid)); break;

                            case "perf_counter_en[\"\\System\\Context Switches/sec\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble() + 18000, items[i].itemid)); break;

                            case "perf_counter_en[\"\\System\\Threads\"]":
                               historyDatas.Add(new historyData(rnd.Next(1000, 5000), items[i].itemid)); break;

                            case "perf_counter_en[\"\\System\\Processor Queue Length\"]":
                               historyDatas.Add(new historyData(rnd.Next(0, 100), items[i].itemid)); break;

                            case "proc.num[]":
                               historyDatas.Add(new historyData(rnd.Next(10, 500), items[i].itemid)); break;

                            case "system.cpu.util":
                               historyDatas.Add(new historyData(rnd.NextDouble() * 100, items[i].itemid)); break;

                            case "system.swap.size[,total]":
                               historyDatas.Add(new historyData(rnd.Next(19514624, 2095514624), items[i].itemid)); break;

                            case "system.uptime":
                               historyDatas.Add(new historyData(rnd.Next(6555, 603482), items[i].itemid)); break;

                            case "vm.memory.size[total]":
                               historyDatas.Add(new historyData(rnd.Next(12713088, 1702713088), items[i].itemid)); break;

                            case "vm.memory.size[used]":
                               historyDatas.Add(new historyData(rnd.Next(127113088, 170271388), items[i].itemid)); break;

                            case "wmi.get[root/cimv2,\"Select NumberOfLogicalProcessors from Win32_ComputerSystem\"]":
                               historyDatas.Add(new historyData(rnd.Next(2, 16), items[i].itemid)); break;

                            case "agent.hostname":
                               historyDatas.Add(new historyData("gyszp_pc3", items[i].itemid)); break;

                            case "agent.ping":
                               historyDatas.Add(new historyData(1, items[i].itemid)); break;

                            case "agent.version":
                               historyDatas.Add(new historyData("6.2", items[i].itemid)); break;

                            case "system.hostname":
                               historyDatas.Add(new historyData("Gyakornok PC", items[i].itemid)); break;

                            case "system.localtime":
                               historyDatas.Add(new historyData($"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}", items[i].itemid)); break;

                            case "system.sw.arch":
                               historyDatas.Add(new historyData("x64", items[i].itemid)); break;

                            case "system.sw.os":
                               historyDatas.Add(new historyData("Unknown metric system.sw.os", items[i].itemid)); break;

                            case "system.uname":
                               historyDatas.Add(new historyData("Windows DESKTOP - J77B62V 10.0.19045 Microsoft Windows 10 Pro x64", items[i].itemid)); break;

                            case "vfs.fs.get":
                               historyDatas.Add(new historyData("{}", items[i].itemid)); break;

                            case "wmi.getall[root\\cimv2,\"select Name,Description,NetConnectionID,Speed,AdapterTypeId,NetConnectionStatus,GUID from win32_networkadapter where PhysicalAdapter=True and NetConnectionStatus>0\"]":
                               historyDatas.Add(new historyData(0, items[i].itemid)); break;

                            default:
                                Console.WriteLine($"Unknown key: {items[i].key_}");
                                break;
                        }
                        break;

                    case 11452:
                        switch (items[i].key_)
                        {
                            case "perf_counter_en[\"\\Memory\\Cache Bytes\"]":
                               historyDatas.Add(new historyData(rnd.Next(300645000, 491655168), items[i].itemid)); break;

                            case "perf_counter_en[\"\\Memory\\Free System Page Table Entries\"]":
                               historyDatas.Add(new historyData(rnd.Next(1000, 12471498), items[i].itemid)); break;


                            case "perf_counter_en[\"\\Memory\\Page Faults/sec\"]":

                               historyDatas.Add(new historyData(rnd.NextDouble() * 1000, items[i].itemid)); break;

                            case "perf_counter_en[\"\\Memory\\Pages/sec\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble() + 8, items[i].itemid)); break;

                            case "perf_counter_en[\"\\Memory\\Pool Nonpaged Bytes\"]":
                               historyDatas.Add(new historyData(rnd.Next(300645000, 491655168), items[i].itemid)); break;

                            case "perf_counter_en[\"\\Paging file(_Total)\\% Usage\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble() * 100, items[i].itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% DPC Time\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble(), items[i].itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% Interrupt Time\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble(), items[i].itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% Privileged Time\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble() + 5, items[i].itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% User Time\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble() + 5, items[i].itemid)); break;

                            case "perf_counter_en[\"\\System\\Context Switches/sec\"]":
                               historyDatas.Add(new historyData(rnd.NextDouble() + 18000, items[i].itemid)); break;

                            case "perf_counter_en[\"\\System\\Threads\"]":
                               historyDatas.Add(new historyData(rnd.Next(1000, 5000), items[i].itemid)); break;

                            case "perf_counter_en[\"\\System\\Processor Queue Length\"]":
                               historyDatas.Add(new historyData(rnd.Next(0, 100), items[i].itemid)); break;

                            case "proc.num[]":
                               historyDatas.Add(new historyData(rnd.Next(10, 500), items[i].itemid)); break;

                            case "system.cpu.util":
                               historyDatas.Add(new historyData(rnd.NextDouble() * 100, items[i].itemid)); break;

                            case "system.swap.size[,total]":
                               historyDatas.Add(new historyData(rnd.Next(19514624, 2095514624), items[i].itemid)); break;

                            case "system.uptime":
                               historyDatas.Add(new historyData(rnd.Next(6555, 603482), items[i].itemid)); break;

                            case "vm.memory.size[total]":
                               historyDatas.Add(new historyData(rnd.Next(12713088, 1702713088), items[i].itemid)); break;

                            case "vm.memory.size[used]":
                               historyDatas.Add(new historyData(rnd.Next(127113088, 170271388), items[i].itemid)); break;

                            case "wmi.get[root/cimv2,\"Select NumberOfLogicalProcessors from Win32_ComputerSystem\"]":
                               historyDatas.Add(new historyData(rnd.Next(2, 16), items[i].itemid)); break;

                            case "agent.hostname":
                               historyDatas.Add(new historyData("gyszp_pc4", items[i].itemid)); break;

                            case "agent.ping":
                               historyDatas.Add(new historyData(1, items[i].itemid)); break;

                            case "agent.version":
                               historyDatas.Add(new historyData("6.2", items[i].itemid)); break;

                            case "system.hostname":
                               historyDatas.Add(new historyData("Gyakornok PC", items[i].itemid)); break;

                            case "system.localtime":
                               historyDatas.Add(new historyData($"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}", items[i].itemid)); break;

                            case "system.sw.arch":
                               historyDatas.Add(new historyData("x64", items[i].itemid)); break;

                            case "system.sw.os":
                               historyDatas.Add(new historyData("Unknown metric system.sw.os", items[i].itemid)); break;

                            case "system.uname":
                               historyDatas.Add(new historyData("Windows DESKTOP - J77B62V 10.0.19045 Microsoft Windows 10 Pro x64", items[i].itemid)); break;

                            case "vfs.fs.get":
                               historyDatas.Add(new historyData("{}", items[i].itemid)); break;

                            case "wmi.getall[root\\cimv2,\"select Name,Description,NetConnectionID,Speed,AdapterTypeId,NetConnectionStatus,GUID from win32_networkadapter where PhysicalAdapter=True and NetConnectionStatus>0\"]":
                               historyDatas.Add(new historyData(0, items[i].itemid)); break;

                            default:
                                Console.WriteLine($"Unknown key: {items[i].key_}");
                                break;
                        }
                        break ;
                    default:
                        Console.WriteLine($"Unknown key: {items[i].hostid}");
                        break;

                }
            }


            return historyDatas;
        }
    }
}
