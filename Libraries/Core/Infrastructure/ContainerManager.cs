using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Core.Infrastructure
{
    public class ContainerManager
    {
        private readonly IContainer _container;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ContainerManager(IContainer container)
        {
            _container = container;
        }

        public virtual IContainer Container
        {
            get
            {
                return _container;
            }
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T Resolve<T>() where T : class
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual object Resolve(Type type)
        {
            return Container.Resolve(type);
        }
    }
}
