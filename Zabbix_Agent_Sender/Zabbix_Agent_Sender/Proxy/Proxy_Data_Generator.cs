using log4net.Config;
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
        
        

        public static async Task<historyData> GenerateData(Proxy_Data_items_Item items, CancellationToken token) 
        {
            

            log4net.ILog logProxy = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            logProxy.Info("task started");
            await Task.Delay(500,token);
            token.ThrowIfCancellationRequested();
            List<historyData> historyDatas = new List<historyData>();
            Random rnd = new Random();
            
                
                //switch (items.hostid) 
                //{
                //    case 11451:
                        switch (items.key_)
                        {
                            case "perf_counter_en[\"\\Memory\\Cache Bytes\"]":
                                return (new historyData(rnd.Next(300645000, 491655168), items.itemid)); break;

                            case "perf_counter_en[\"\\Memory\\Free System Page Table Entries\"]":
                               return (new historyData(rnd.Next(1000, 12471498), items.itemid)); break;


                            case "perf_counter_en[\"\\Memory\\Page Faults/sec\"]":

                               return (new historyData(rnd.NextDouble() * 1000, items.itemid)); break;

                            case "perf_counter_en[\"\\Memory\\Pages/sec\"]":
                               return (new historyData(rnd.NextDouble() + 8, items.itemid)); break;

                            case "perf_counter_en[\"\\Memory\\Pool Nonpaged Bytes\"]":
                               return (new historyData(rnd.Next(300645000, 491655168), items.itemid)); break;

                            case "perf_counter_en[\"\\Paging file(_Total)\\% Usage\"]":
                               return (new historyData(rnd.NextDouble() * 100, items.itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% DPC Time\"]":
                               return (new historyData(rnd.NextDouble(), items.itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% Interrupt Time\"]":
                               return (new historyData(rnd.NextDouble(), items.itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% Privileged Time\"]":
                               return (new historyData(rnd.NextDouble() + 5, items.itemid)); break;

                            case "perf_counter_en[\"\\Processor Information(_total)\\% User Time\"]":
                               return (new historyData(rnd.NextDouble() + 5, items.itemid)); break;

                            case "perf_counter_en[\"\\System\\Context Switches/sec\"]":
                               return (new historyData(rnd.NextDouble() + 18000, items.itemid)); break;

                            case "perf_counter_en[\"\\System\\Threads\"]":
                               return (new historyData(rnd.Next(1000, 5000), items.itemid)); break;

                            case "perf_counter_en[\"\\System\\Processor Queue Length\"]":
                               return (new historyData(rnd.Next(0, 100), items.itemid)); break;

                            case "proc.num[]":
                               return (new historyData(rnd.Next(10, 500), items.itemid)); break;

                            case "system.cpu.util":
                               return (new historyData(rnd.NextDouble() * 100, items.itemid)); break;

                            case "system.swap.size[,total]":
                               return (new historyData(rnd.Next(19514624, 2095514624), items.itemid)); break;

                            case "system.uptime":
                               return (new historyData(rnd.Next(6555, 603482), items.itemid)); break;

                            case "vm.memory.size[total]":
                               return (new historyData(rnd.Next(12713088, 1702713088), items.itemid)); break;

                            case "vm.memory.size[used]":
                               return (new historyData(rnd.Next(127113088, 170271388), items.itemid)); break;

                            case "wmi.get[root/cimv2,\"Select NumberOfLogicalProcessors from Win32_ComputerSystem\"]":
                               return (new historyData(rnd.Next(2, 16), items.itemid)); break;

                            case "agent.hostname":
                               return (new historyData("gyszp_pc3", items.itemid)); break;

                            case "agent.ping":
                               return (new historyData(1, items.itemid)); break;

                            case "agent.version":
                               return (new historyData("6.2", items.itemid)); break;

                            case "system.hostname":
                               return (new historyData("Gyakornok PC", items.itemid)); break;

                            case "system.localtime":
                               return (new historyData($"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}", items.itemid)); break;

                            case "system.sw.arch":
                               return (new historyData("x64", items.itemid)); break;

                            case "system.sw.os":
                               return (new historyData("Unknown metric system.sw.os", items.itemid)); break;

                            case "system.uname":
                               return (new historyData("Windows DESKTOP - J77B62V 10.0.19045 Microsoft Windows 10 Pro x64", items.itemid)); break;

                            case "vfs.fs.get":
                               return (new historyData("{}", items.itemid)); break;

                            case "wmi.getall[root\\cimv2,\"select Name,Description,NetConnectionID,Speed,AdapterTypeId,NetConnectionStatus,GUID from win32_networkadapter where PhysicalAdapter=True and NetConnectionStatus>0\"]":
                               return (new historyData(0, items.itemid)); break;

                            default:
                                logProxy.Warn($"Unknown key: {items.key_}");
                                break;
                        }
                        //break;

                    //case 11452:
                    //    switch (items.key_)
                    //    {
                    //        case "perf_counter_en[\"\\Memory\\Cache Bytes\"]":
                    //           return (new historyData(rnd.Next(300645000, 491655168), items.itemid)); break;

                    //        case "perf_counter_en[\"\\Memory\\Free System Page Table Entries\"]":
                    //           return (new historyData(rnd.Next(1000, 12471498), items.itemid)); break;


                    //        case "perf_counter_en[\"\\Memory\\Page Faults/sec\"]":

                    //           return (new historyData(rnd.NextDouble() * 1000, items.itemid)); break;

                    //        case "perf_counter_en[\"\\Memory\\Pages/sec\"]":
                    //           return (new historyData(rnd.NextDouble() + 8, items.itemid)); break;

                    //        case "perf_counter_en[\"\\Memory\\Pool Nonpaged Bytes\"]":
                    //           return (new historyData(rnd.Next(300645000, 491655168), items.itemid)); break;

                    //        case "perf_counter_en[\"\\Paging file(_Total)\\% Usage\"]":
                    //           return (new historyData(rnd.NextDouble() * 100, items.itemid)); break;

                    //        case "perf_counter_en[\"\\Processor Information(_total)\\% DPC Time\"]":
                    //           return (new historyData(rnd.NextDouble(), items.itemid)); break;

                    //        case "perf_counter_en[\"\\Processor Information(_total)\\% Interrupt Time\"]":
                    //           return (new historyData(rnd.NextDouble(), items.itemid)); break;

                    //        case "perf_counter_en[\"\\Processor Information(_total)\\% Privileged Time\"]":
                    //           return (new historyData(rnd.NextDouble() + 5, items.itemid)); break;

                    //        case "perf_counter_en[\"\\Processor Information(_total)\\% User Time\"]":
                    //           return (new historyData(rnd.NextDouble() + 5, items.itemid)); break;

                    //        case "perf_counter_en[\"\\System\\Context Switches/sec\"]":
                    //           return (new historyData(rnd.NextDouble() + 18000, items.itemid)); break;

                    //        case "perf_counter_en[\"\\System\\Threads\"]":
                    //           return (new historyData(rnd.Next(1000, 5000), items.itemid)); break;

                    //        case "perf_counter_en[\"\\System\\Processor Queue Length\"]":
                    //           return (new historyData(rnd.Next(0, 100), items.itemid)); break;

                    //        case "proc.num[]":
                    //           return (new historyData(rnd.Next(10, 500), items.itemid)); break;

                    //        case "system.cpu.util":
                    //           return (new historyData(rnd.NextDouble() * 100, items.itemid)); break;

                    //        case "system.swap.size[,total]":
                    //           return (new historyData(rnd.Next(19514624, 2095514624), items.itemid)); break;

                    //        case "system.uptime":
                    //           return (new historyData(rnd.Next(6555, 603482), items.itemid)); break;

                    //        case "vm.memory.size[total]":
                    //           return (new historyData(rnd.Next(12713088, 1702713088), items.itemid)); break;

                    //        case "vm.memory.size[used]":
                    //           return (new historyData(rnd.Next(127113088, 170271388), items.itemid)); break;

                    //        case "wmi.get[root/cimv2,\"Select NumberOfLogicalProcessors from Win32_ComputerSystem\"]":
                    //           return (new historyData(rnd.Next(2, 16), items.itemid)); break;

                    //        case "agent.hostname":
                    //           return (new historyData("gyszp_pc4", items.itemid)); break;

                    //        case "agent.ping":
                    //           return (new historyData(1, items.itemid)); break;

                    //        case "agent.version":
                    //           return (new historyData("6.2", items.itemid)); break;

                    //        case "system.hostname":
                    //           return (new historyData("Gyakornok PC", items.itemid)); break;

                    //        case "system.localtime":
                    //           return (new historyData($"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}", items.itemid)); break;

                    //        case "system.sw.arch":
                    //           return (new historyData("x64", items.itemid)); break;

                    //        case "system.sw.os":
                    //           return (new historyData("Unknown metric system.sw.os", items.itemid)); break;

                    //        case "system.uname":
                    //           return (new historyData("Windows DESKTOP - J77B62V 10.0.19045 Microsoft Windows 10 Pro x64", items.itemid)); break;

                    //        case "vfs.fs.get":
                    //           return (new historyData("{}", items.itemid)); break;

                    //        case "wmi.getall[root\\cimv2,\"select Name,Description,NetConnectionID,Speed,AdapterTypeId,NetConnectionStatus,GUID from win32_networkadapter where PhysicalAdapter=True and NetConnectionStatus>0\"]":
                    //           return (new historyData(0, items.itemid)); break;

                    //        default:
                    //            logProxy.Warn($"Unknown key: {items.key_}");
                    //            break;
                    //    }
                    //    break ;
                    //default:
                    //    logProxy.Warn($"Unknown hostid: {items.hostid}");
                    //    break;

                
                //}


            return null;
        }
    }
}
