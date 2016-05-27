using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Core.Infrastructure;
using WebServices.Implementation;
using WebServices.Interface;

namespace WebServices.Host.Infrastructure
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
            builder.RegisterType<AddressService>().As<IAddressService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
        }
    }
}
