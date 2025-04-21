using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public partial class Zabbix_Serializables
{
        public class Proxy_Data_Item
        {
            public string Item_Name { get; set; }
            public List<string> fields { get; set; }
            public List<List<object>> data { get; set; }
        }

        public class Proxy_Data_Hosts : Proxy_Data_Item { }

        public class Proxy_Data_interface : Proxy_Data_Item { }

        public class Proxy_Data_interface_snmp : Proxy_Data_Item{ }

        public class Proxy_Data_host_inventory : Proxy_Data_Item{ }
        
        public class Proxy_Data_items : Proxy_Data_Item{ }

        public class Proxy_Data_item_rtdata : Proxy_Data_Item{ }

        public class Proxy_Data_item_preproc : Proxy_Data_Item { }

        public class Proxy_Data_item_parameter : Proxy_Data_Item { }

        public class Proxy_Data_globalmacro : Proxy_Data_Item { }

        public class Proxy_Data_hosts_templates : Proxy_Data_Item { }

        public class Proxy_Data_hostmacro : Proxy_Data_Item { }

        public class Proxy_Data_drules : Proxy_Data_Item { }

        public class Proxy_Data_dchecks : Proxy_Data_Item { }

        public class Proxy_Data_regexps : Proxy_Data_Item { }

        public class Proxy_Data_expressions : Proxy_Data_Item { }

        public class Proxy_Data_config : Proxy_Data_Item { }

        public class Proxy_Data_httptest : Proxy_Data_Item { }

        public class Proxy_Data_httptestitem : Proxy_Data_Item { }

        public class Proxy_Data_httptest_field : Proxy_Data_Item { }

        public class Proxy_Data_httpstep : Proxy_Data_Item { }

        public class Proxy_Data_httpstepitem : Proxy_Data_Item { }

        public class Proxy_Data_httpstep_field : Proxy_Data_Item { }

        public class Proxy_Data_config_autoreg_tls : Proxy_Data_Item { }



}

