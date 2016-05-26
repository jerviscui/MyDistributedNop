using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Wcf;
using ServiceFramework;

namespace Core.Infrastructure
{
    public class ServiceManager
    {
        public delegate void ServiceOpendHandler(ServiceHost host, EventArgs e);

        public event ServiceOpendHandler Opend;

        private readonly IDictionary<Type, ServiceHost> _allServiceHosts;

        public IDictionary<Type, ServiceHost> ServiceHosts
        {
            get
            {
                return _allServiceHosts;
            }
        }

        #region Ctor
        public ServiceManager(IEnumerable<Type> serviceTypes)
        {
            if (serviceTypes == null)
            {
                throw new ArgumentNullException();
            }

            _allServiceHosts = new Dictionary<Type, ServiceHost>();

            var enumerable = serviceTypes as Type[] ?? serviceTypes.ToArray();
            if (enumerable.Any(o => o == null))
            {
                throw new NullReferenceException("service types have null refrence");
            }

            foreach (var serviceType in enumerable)
            {
                _allServiceHosts.Add(serviceType, new ServiceHost(serviceType));
            }
        }

        public ServiceManager(IEnumerable<Type> serviceTypes, ServiceOpendHandler opend) : this(serviceTypes)
        {
            Opend += opend;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Use Dependency Registration for <see cref="System.ServiceModel.ServiceHost"/> 
        /// </summary>
        public void InitForDependencyRegister(IEngine engine)
        {
            foreach (var allServiceHost in _allServiceHosts)
            {
                var serviceType = allServiceHost.Key;
                Type interfaceType = serviceType.GetInterface("I" + serviceType.Name);
                //can also do like this
                //interfaceType = allServiceHost.Key.GetInterfaces()[0];

                allServiceHost.Value.AddDependencyInjectionBehavior(interfaceType, engine.ContainerManager.Container);

                //now, first replace engine then execute engine init, so can do like this
                //allServiceHost.Value.AddDependencyInjectionBehavior(interfaceType, ServiceContext.Current.ContainerManager.Container);
            }
        }

        /// <summary>
        /// Start all register services
        /// </summary>
        public void StartAllServices()
        {
            foreach (var allServiceHost in _allServiceHosts)
            {
                if (Opend != null)
                {
                    allServiceHost.Value.Opened += (sender, args) => { Opend((ServiceHost)sender, args); };
                }
                allServiceHost.Value.Open();
            }
        }

        /// <summary>
        /// Stop all register services
        /// </summary>
        public void StopAllServices()
        {
            foreach (var allServiceHost in _allServiceHosts)
            {
                allServiceHost.Value.Close();
            }
        }
        #endregion
    }
}
