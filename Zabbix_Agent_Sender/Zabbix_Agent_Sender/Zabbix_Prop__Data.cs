using System;
using static Zabbix_Serializables;

public class Zabbix_Prop_Data
{
    public static List<Zabbix_Send_Item> DATA()
    {

        //int Data_ID = 1;
        List<Zabbix_Send_Item> send_tems = new List<Zabbix_Send_Item>()
        {
            //key: agent.hostname
            new Zabbix_Send_Item { id = 1,itemid =121091,value ="gyszp_pc2", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: agent.ping
            new Zabbix_Send_Item { id = 2,itemid =121092,value ="1", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: agent.version
            new Zabbix_Send_Item { id = 3,itemid =121093,value ="6.2", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\Memory\Cache Bytes"]
            new Zabbix_Send_Item { id = 4,itemid =121094,value ="491655168", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\Memory\Free System Page Table Entries"]
            new Zabbix_Send_Item { id = 5,itemid =121095,value ="12471498", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\Memory\Page Faults/sec"]
            new Zabbix_Send_Item { id = 6,itemid =121096,value ="1575.283004", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\Memory\Pages/sec"]
            new Zabbix_Send_Item { id = 7,itemid =121097,value ="8.041635", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\Memory\Pool Nonpaged Bytes"]
            new Zabbix_Send_Item { id = 8,itemid =121098,value ="611397632", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\Paging file(_Total)\% Usage"]
            new Zabbix_Send_Item { id = 9,itemid =121099,value ="53.448", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\Processor Information(_total)\% DPC Time"]
            new Zabbix_Send_Item { id = 10,itemid =121100,value ="0", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\Processor Information(_total)\% Interrupt Time"]
            new Zabbix_Send_Item { id = 11,itemid =121101,value ="0.781308", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\Processor Information(_total)\% Privileged Time"]
            new Zabbix_Send_Item { id = 12,itemid =121102,value ="5.072324", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\Processor Information(_total)\% User Time"]
            new Zabbix_Send_Item { id = 13,itemid =121103,value ="5.85449", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\System\Context Switches/sec"]
            new Zabbix_Send_Item { id = 14,itemid =121104,value ="19313.422258", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\System\Processor Queue Length"]
            new Zabbix_Send_Item { id = 15,itemid =121105,value ="0", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: perf_counter_en["\System\Threads"]
            new Zabbix_Send_Item { id = 16,itemid =121106,value ="4161", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: proc.num[]
            new Zabbix_Send_Item { id = 17,itemid =121107,value ="315", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: system.cpu.util
            new Zabbix_Send_Item { id = 18,itemid =121108,value ="16.27485", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: system.hostname
            new Zabbix_Send_Item { id = 19,itemid =121109,value ="nemmodommeg", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: system.localtime
            new Zabbix_Send_Item { id = 20,itemid =121110,value =$"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: system.sw.arch
            new Zabbix_Send_Item { id = 21,itemid =121111,value ="x64", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: system.sw.os
            new Zabbix_Send_Item { id = 22,itemid =121112,value ="Unknown metric system.sw.os", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: system.swap.size[,total]
            new Zabbix_Send_Item { id = 23,itemid =121114,value ="14495514624", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: system.uname
            new Zabbix_Send_Item { id = 24,itemid =121115,value ="Windows DESKTOP-J77B62V 10.0.19045 Microsoft Windows 10 Pro x64", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: system.uptime
            new Zabbix_Send_Item { id = 25,itemid =121116,value ="553482", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: vfs.fs.get
            new Zabbix_Send_Item { id = 26,itemid =121117,value ="{}", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: vm.memory.size[total]
            new Zabbix_Send_Item { id = 27,itemid =121118,value ="17002713088", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: vm.memory.size[used]
            new Zabbix_Send_Item { id = 28,itemid =121119,value ="12921782272", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: wmi.get[root/cimv2,"Select NumberOfLogicalProcessors from Win32_ComputerSystem"]
            new Zabbix_Send_Item { id = 29,itemid =121121,value ="8", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0},
            //key: wmi.getall[root\cimv2,"select Name,Description,NetConnectionID,Speed,AdapterTypeId,NetConnectionStatus,GUID from win32_networkadapter where PhysicalAdapter=True and NetConnectionStatus>0"]
            new Zabbix_Send_Item { id = 30,itemid =121122,value ="0", clock = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),ns = 0}
        };

        return send_tems;
    }
}
