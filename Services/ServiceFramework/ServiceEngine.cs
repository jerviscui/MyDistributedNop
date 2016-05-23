using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Infrastructure;

namespace ServiceFramework
{
    public class ServiceEngine : Engine
    {
        public ServiceEngine(IEnumerable<Type> serviceTypes)
        {
            ServiceManager = new ServiceManager(serviceTypes);
        }

        public ServiceManager ServiceManager { get; }

        /// <summary>
        /// Find and start startup tasks
        /// </summary>
        protected override void RunStartupTasks()
        {
            base.RunStartupTasks();
        }

        /// <summary>
        /// Register Dependencies
        /// </summary>
        protected override void RegisterDependencies()
        {
            base.RegisterDependencies();
        }

        #region Methods
        /// <summary>
        /// Start all register services
        /// </summary>
        public void StartAllServices()
        {
            ServiceManager.StartAllServices();
        }

        /// <summary>
        /// Stop all register services
        /// </summary>
        public void StopAllServices()
        {
            ServiceManager.StopAllServices();
        }
        #endregion
    }
}
