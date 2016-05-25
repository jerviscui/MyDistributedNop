using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Infrastructure;

namespace ServiceFramework
{
    public interface IServiceEngine : IEngine
    {
        /// <summary>
        /// Services manager
        /// </summary>
        ServiceManager ServiceManager { get; }

        /// <summary>
        /// Start all register services
        /// </summary>
        void StartAllServices();

        /// <summary>
        /// Stop all register services
        /// </summary>
        void StopAllServices();
    }
}
