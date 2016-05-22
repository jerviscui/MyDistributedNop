using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public interface IStartupTask
    {
        /// <summary>
        /// 0 is the first startup task
        /// </summary>
        int Order { get; }

        void Startup();
    }
}
