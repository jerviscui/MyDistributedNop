using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ServiceFramework;

namespace WebServices.Host
{
    public class ServiceHelper
    {
        static ServiceHelper()
        {
            ServiceContext.Initialize(ServiceFinder.GetServices(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)),
                (host, args) =>
                {
                    Console.WriteLine("服务{0}启动", host.Description.Name);
                });
        }

        public static void Run()
        {
            ServiceContext.Current.StartAllServices();
        }

        public static void Stop()
        {
            ServiceContext.Current.StopAllServices();
        }
    }
}
