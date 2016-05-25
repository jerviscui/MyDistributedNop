using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Infrastructure;

namespace ServiceFramework
{
    public class ServiceContext : EngineContext
    {
        /// <summary>
        /// Engine context initialize
        /// </summary>
        /// <returns></returns>
        public static IServiceEngine Initialize(IEnumerable<Type> serviceTypes, ServiceManager.ServiceOpendHandler opend = null)
        {
            if (EngineContext.Current is Engine)
            {
                var engine = opend == null ? new ServiceEngine(serviceTypes) : new ServiceEngine(serviceTypes, opend);
                engine.Initialize();
                EngineContext.Replace(engine);
            }
            else if (!(EngineContext.Current is IServiceEngine))
            {
                throw new ServiceContextException(); 
            }

            return Singleton<IEngine>.Instance as IServiceEngine;
        }

        /// <summary>
        /// Get current engine
        /// </summary>
        public new static IServiceEngine Current
        {
            get { return Singleton<IEngine>.Instance as IServiceEngine; }
        }
    }
}
