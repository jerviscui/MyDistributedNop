using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Wcf;
using Core.Domain;
using Core.Infrastructure;
using DataService.Implement;
using WcfTools;
using WebServices.Interface;
using WebServices.Proxy;

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
            //register service type relation to service interface
            builder.RegisterType<DataService.Implement.UserService>().As<DataService.Interface.IUserService>().InstancePerLifetimeScope();

            //register WCF proxy
            //builder.RegisterInstance(new ProxyManager()).As<ProxyManager>().Keyed<ProxyManager>("ProxyManager").SingleInstance();
            ////builder.RegisterType<AddressServiceProxy>().As<IAddressService>().InstancePerDependency();
            //builder.Register(context => new AddressServiceProxy(context.Resolve<ProxyManager>().GetProxy<IAddressService>()))
            //    .As<IAddressService>().InstancePerDependency();
            //builder.Register(context => new UserServiceProxy(context.Resolve<ProxyManager>().GetProxy<IUserService>()))
            //    .As<IUserService>().InstancePerDependency();

            //use proxy or register WCF channel factory
            //The UseWcfSafeRelease() configuration option ensures that exception messages are not lost when disposing client channels.
            //builder.Register(context => new ChannelFactory<IAddressService>("IAddressService")).SingleInstance();
            //builder.Register(context => context.Resolve<ChannelFactory<IAddressService>>().CreateChannel()).As<IAddressService>().UseWcfSafeRelease();
            //create a channel factory manager
            builder.Register(context => new ChannelFactoryManager()).SingleInstance();
            builder.Register(context => context.Resolve<ChannelFactoryManager>().CreateChannel<IAddressService>())
                .As<IAddressService>()
                .UseWcfSafeRelease();
            builder.Register(context => context.Resolve<ChannelFactoryManager>().CreateChannel<IUserService>())
                .As<IUserService>()
                .UseWcfSafeRelease();

            builder.RegisterControllers(Assembly.GetAssembly(typeof (MvcApplication)));
        }
    }
}
