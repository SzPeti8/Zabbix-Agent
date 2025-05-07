using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabbix_Agent_Sender.Agent_F
{
    public delegate Task AsyncRequestHandler(object? sender, ZabbixRR zabbixRR);
}
