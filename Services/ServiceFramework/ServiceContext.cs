using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace ServiceFramework
{
    public class ServiceContext : EngineContext
    {
        /// <summary>
        /// Engine context initialize
        /// </summary>
        /// <returns></returns>
        public static IServiceEngine Initialize(IEnumerable<Type> serviceTypes)
        {
            if (EngineContext.Current is Engine)
            {
                var engine = new ServiceEngine(serviceTypes);
                engine.Initialize();
                EngineContext.Replace(engine);
            }
            else if (EngineContext.Current is IServiceEngine)
            {
                return Singleton<IEngine>.Instance as IServiceEngine;
            }

            throw new ServiceContextException();
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
