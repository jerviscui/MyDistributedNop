using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Core.Infrastructure
{
    public interface IDependencyRegister
    {
        /// <summary>
        /// 0 is the first regist
        /// </summary>
        int Order { get; }

        /// <summary>
        /// Regist implementation for interface
        /// </summary>
        /// <param name="builder"></param>
        void Register(ContainerBuilder builder);
    }
}
