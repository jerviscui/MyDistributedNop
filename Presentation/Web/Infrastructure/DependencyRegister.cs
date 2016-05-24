using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Core.Infrastructure;
using DataService.Implement;
using DataService.Interface;

namespace Web.Infrastructure
{
    public class DependencyRegister : IDependencyRegister
    {
        /// <summary>
        /// 0 is the first regist
        /// </summary>
        public int Order
        {
            get { return 2; }
        }

        /// <summary>
        /// Regist implementation for interface
        /// </summary>
        /// <param name="builder"></param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }
    }
}
