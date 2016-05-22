using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Core;
using Core.Infrastructure;
using Data;

namespace Web.Framework
{
    public class DependencyRegister : IDependencyRegister
    {
        /// <summary>
        /// 0 is the first regist
        /// </summary>
        public int Order
        {
            get { return 0; }
        }

        /// <summary>
        /// Regist implementation for interface
        /// </summary>
        /// <param name="builder"></param>
        public void Register(ContainerBuilder builder)
        {
            
        }
    }
}
