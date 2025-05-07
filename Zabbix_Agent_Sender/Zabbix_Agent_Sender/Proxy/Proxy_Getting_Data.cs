using log4net.Config;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Zabbix_Serializables;

namespace Zabbix_Agent_Sender.Proxy
{
    public class Proxy_Getting_Data
    {

        public async static Task<Zabbix_Proxy_Data_Request> gettingDataFromHosts(List<Proxy_Data_items_Item> Conf_items,
            List<Proxy_Data_Hosts_Item> hosts, List<Proxy_Data_interface_Item> interfaces)
        {
            log4net.ILog logProxy = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            Zabbix_Proxy_Data_Request data_Request = new Zabbix_Proxy_Data_Request();

            data_Request.interfaceAvailability = new List<interfaceAvailability>();
            for (int i = 0; i < interfaces.Count;i++)
            {
                
                data_Request.interfaceAvailability.Add(new interfaceAvailability()
                {
                    interfaceid = interfaces[i].interfaceid,
                    available = 1,
                    error = ""
                });
            }
            data_Request.hostDatas = new List<hostData>();
            for (int i = 0; i < hosts.Count; i++)
            {
                data_Request.hostDatas.Add(new hostData()
                {
                    hostid = hosts[i].hostid,
                    active_status = 1
                });
            }

            data_Request.historyData = new List<historyData>();

            var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            var semaphore = new SemaphoreSlim(10); // max 10 párhuzamosan
            var tasks = Conf_items.Select(async item =>
            {
                await semaphore.WaitAsync().ConfigureAwait(false);
                try
                {
                    return await Proxy_Data_Generator.GenerateData(item,token);
                }
                catch (OperationCanceledException e)
                {
                    logProxy.Warn("Task Cancceled");
                    return null;

                }
                finally
                {
                    semaphore.Release();
                }
            }).ToList();

            logProxy.Debug("Timer INDUL#########################");
            await Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                cts.Cancel();
                logProxy.Debug("LEJART AZ IDO");

            });

            var results = tasks
                    .Where(t => t.IsCompletedSuccessfully).Where(t => t.Result != null)
                    .Select(t => t.Result)
                    .ToList();


            logProxy.Info($"After TimeOut {results.Count} task finished.");



            return data_Request;
        }


    }
}
