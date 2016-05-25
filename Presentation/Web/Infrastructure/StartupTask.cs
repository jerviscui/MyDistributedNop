using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Infrastructure;

namespace Web.Infrastructure
{
    public class StartupTask : IStartupTask
    {
        /// <summary>
        /// 0 is the first startup task
        /// </summary>
        public int Order { get { return 2; } }

        /// <summary>
        /// 
        /// </summary>
        public void Startup()
        {
            
        }
    }
}