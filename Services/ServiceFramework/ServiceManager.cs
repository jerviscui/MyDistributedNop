using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public class ServiceManager
    {
        private readonly IDictionary<Type, ServiceHost> _allServiceHosts;

        public IDictionary<Type, ServiceHost> ServiceHosts
        {
            get
            {
                return _allServiceHosts;
            }
        }

        public ServiceManager(IEnumerable<Type> serviceTypes) : base()
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

        /// <summary>
        /// Start all register services
        /// </summary>
        public void StartAllServices()
        {
            foreach (var allServiceHost in _allServiceHosts)
            {
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
    }
}
