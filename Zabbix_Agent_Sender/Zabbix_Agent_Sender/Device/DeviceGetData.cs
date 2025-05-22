using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender.Device
{
    public class DeviceGetData
    {



        public static void GettingData(Zabbix_Send_Item item)
        {
            Random rnd = new Random();
            var devname = "gyszpc_2";
            switch (item.key)
            {
                case "perf_counter_en[\"\\Memory\\Cache Bytes\"]":
                    item.SetValue(rnd.Next(300645000, 491655168)); break;

                case "perf_counter_en[\"\\Memory\\Free System Page Table Entries\"]":
                    item.SetValue(rnd.Next(1000, 12471498)); break;


                case "perf_counter_en[\"\\Memory\\Page Faults/sec\"]":

                    item.SetValue(rnd.NextDouble() * 1000); break;

                case "perf_counter_en[\"\\Memory\\Pages/sec\"]":
                    item.SetValue(rnd.NextDouble() + 8); break;

                case "perf_counter_en[\"\\Memory\\Pool Nonpaged Bytes\"]":
                    item.SetValue(rnd.Next(300645000, 491655168)); break;

                case "perf_counter_en[\"\\Paging file(_Total)\\% Usage\"]":
                    item.SetValue(rnd.NextDouble() * 100); break;

                case "perf_counter_en[\"\\Processor Information(_total)\\% DPC Time\"]":
                    item.SetValue(rnd.NextDouble()); break;

                case "perf_counter_en[\"\\Processor Information(_total)\\% Interrupt Time\"]":
                    item.SetValue(rnd.NextDouble()); break;

                case "perf_counter_en[\"\\Processor Information(_total)\\% Privileged Time\"]":
                    item.SetValue(rnd.NextDouble() + 5); break;

                case "perf_counter_en[\"\\Processor Information(_total)\\% User Time\"]":
                    item.SetValue(rnd.NextDouble() + 5); break;

                case "perf_counter_en[\"\\System\\Context Switches/sec\"]":
                    item.SetValue(rnd.NextDouble() + 18000); break;

                case "perf_counter_en[\"\\System\\Threads\"]":
                    item.SetValue(rnd.Next(1000, 5000)); break;

                case "perf_counter_en[\"\\System\\Processor Queue Length\"]":
                    item.SetValue(rnd.Next(0, 100)); break;

                case "proc.num[]":
                    item.SetValue(rnd.Next(10, 500)); break;

                case "system.cpu.util":
                    item.SetValue(rnd.NextDouble() * 100); break;

                case "system.swap.size[,total]":
                    item.SetValue(rnd.Next(19514624, 2095514624)); break;

                case "system.uptime":
                    item.SetValue(rnd.Next(6555, 603482)); break;

                case "vm.memory.size[total]":
                    item.SetValue(rnd.Next(12713088, 1702713088)); break;

                case "vm.memory.size[used]":
                    item.SetValue(rnd.Next(127113088, 170271388)); break;

                case "wmi.get[root/cimv2,\"Select NumberOfLogicalProcessors from Win32_ComputerSystem\"]":
                    item.SetValue(rnd.Next(2, 16)); break;

                case "agent.hostname":
                    item.SetValue(devname); break;

                case "agent.ping":
                    item.SetValue(1); break;

                case "agent.version":
                    item.SetValue("6.2"); break;

                case "system.hostname":
                    item.SetValue("Gyakornok PC"); break;

                case "system.localtime":
                    item.SetValue($"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}"); break;

                case "system.sw.arch":
                    item.SetValue("x64"); break;

                case "system.sw.os":
                    item.SetValue("Unknown metric system.sw.os"); break;

                case "system.uname":
                    item.SetValue("Windows DESKTOP - J77B62V 10.0.19045 Microsoft Windows 10 Pro x64"); break;

                case "vfs.fs.get":
                    item.SetValue("{}"); break;

                case "wmi.getall[root\\cimv2,\"select Name,Description,NetConnectionID,Speed,AdapterTypeId,NetConnectionStatus,GUID from win32_networkadapter where PhysicalAdapter=True and NetConnectionStatus>0\"]":
                    item.SetValue(0); break;

                default:
                    throw new Exception($"Unknown key: {item.key}");
            }


        }

    }
}
