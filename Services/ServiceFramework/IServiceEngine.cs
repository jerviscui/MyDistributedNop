using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace ServiceFramework
{
    public interface IServiceEngine : IEngine
    {
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
