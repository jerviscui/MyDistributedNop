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
            ServiceContext.Initialize(ServiceFinder.GetServices(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)));
        }

        public static void Run()
        {
            ServiceContext.Current.StopAllServices();
        }

        public static void Stop()
        {
            ServiceContext.Current.StopAllServices();
        }
    }
}
