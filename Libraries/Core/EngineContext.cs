using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class EngineContext
    {
        /// <summary>
        /// Engine context initialize
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize()
        {
            if (Singleton<IEngine>.Instance == null)
            {
                Singleton<IEngine>.Instance = new Engine();
                Singleton<IEngine>.Instance.Initialize();
            }

            return Singleton<IEngine>.Instance;
        }

        /// <summary>
        /// Get current engine
        /// </summary>
        public static IEngine Current
        {
            get { return Singleton<IEngine>.Instance ?? Initialize(); }
        }

        /// <summary>
        /// Replace current engine
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="isIinit"></param>
        public static void Replace(IEngine engine, bool isIinit = false)
        {
            Singleton<IEngine>.Instance = engine;
            if (isIinit)
            {
                engine.Initialize();
            }
        }
    }
}
