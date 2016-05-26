using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Wcf;
using Core;
using Core.Infrastructure;
using Data;

namespace ServiceFramework
{
    public class ServiceEngine : Engine, IServiceEngine
    {
        public ServiceEngine(IEnumerable<Type> serviceTypes)
        {
            ServiceManager = new ServiceManager(serviceTypes);
            OnInitializeComplete += ServiceManager.InitForDependencyRegister;
        }

        public ServiceEngine(IEnumerable<Type> serviceTypes, ServiceManager.ServiceOpendHandler opend)
        {
            ServiceManager = new ServiceManager(serviceTypes, opend);
            OnInitializeComplete += ServiceManager.InitForDependencyRegister;
        }

        /// <summary>
        /// Services manager
        /// </summary>
        public ServiceManager ServiceManager { get; }

        /// <summary>
        /// Find and start startup tasks
        /// </summary>
        protected override void RunStartupTasks()
        {
            base.RunStartupTasks();

            var typeFinder = Resolve<ITypeFinder>();

            var taskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            var tasks = new List<IStartupTask>();

            foreach (var taskType in taskTypes)
            {
                tasks.Add(Activator.CreateInstance(taskType) as IStartupTask);
            }

            tasks = tasks.OrderBy(o => o.Order).ToList();
            foreach (var startupTask in tasks)
            {
                startupTask?.Startup();
            }
        }

        /// <summary>
        /// Register Dependencies
        /// </summary>
        protected override void RegisterDependencies()
        {
            base.RegisterDependencies();

            var builder = new ContainerBuilder();
            var container = builder.Build();
            this.containerManager = new ContainerManager(container);

            builder = new ContainerBuilder();
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            var typeFinder = new TypeFinder();
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            builder.Update(container);

            //init db provider
            builder = new ContainerBuilder();
            builder.RegisterType<DataDbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.Update(container);

            builder = new ContainerBuilder();
            var registerType = typeFinder.FindClassesOfType<IDependencyRegister>();
            var registers = new List<IDependencyRegister>();
            foreach (var type in registerType)
            {
                registers.Add(Activator.CreateInstance(type) as IDependencyRegister);
            }
            registers = registers.Where(o => o != null).OrderBy(o => o.Order).ToList();
            foreach (var dependencyRegister in registers)
            {
                dependencyRegister.Register(builder);
            }
            builder.Update(container);

            //set dependency resolve
            AutofacHostFactory.Container = container;
        }

        #region Methods
        /// <summary>
        /// Start all register services
        /// </summary>
        public void StartAllServices()
        {
            ServiceManager.StartAllServices();
        }

        /// <summary>
        /// Stop all register services
        /// </summary>
        public void StopAllServices()
        {
            ServiceManager.StopAllServices();
        }
        #endregion
    }
}
