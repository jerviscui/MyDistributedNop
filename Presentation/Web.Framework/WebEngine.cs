using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Core;
using Core.Infrastructure;
using Data;

namespace Web.Framework
{
    public class WebEngine : Engine
    {
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

            builder.RegisterControllers(Assembly.Load("Web"));

            builder.Update(container);

            //set dependency resolve
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

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
    }
}
