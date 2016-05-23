using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ServiceFramework;

namespace WebServices.Host
{
    partial class WinService : ServiceBase
    {
        public WinService()
        {
            InitializeComponent();
            this.ServiceName = ConfigurationManager.AppSettings["ServiceName"];

            ServiceContext.Initialize(ServiceFinder.GetServices(ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location)));
        }

        protected override void OnStart(string[] args)
        {
            ServiceContext.Current.StartAllServices();
        }

        protected override void OnStop()
        {
            ServiceContext.Current.StopAllServices();
        }
    }
}
