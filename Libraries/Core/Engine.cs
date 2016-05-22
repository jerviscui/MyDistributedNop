using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Core.Infrastructure;

namespace Core
{
    /// <summary>
    /// Default Engine
    /// </summary>
    public class Engine : IEngine
    {
        #region Fields
        protected ContainerManager containerManager;
        #endregion

        #region Properties
        /// <summary>
        /// Ioc container manager
        /// </summary>
        public ContainerManager ContainerManager
        {
            get { return containerManager; }
        }
        #endregion

        /// <summary>
        /// Find and start startup tasks
        /// </summary>
        protected virtual void RunStartupTasks()
        {
            //var typeFinder = Resolve<ITypeFinder>();
            //var taskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            //var tasks = new List<IStartupTask>();

            //foreach (var taskType in taskTypes)
            //{
            //    tasks.Add(Activator.CreateInstance(taskType) as IStartupTask);
            //}

            //tasks = tasks.OrderBy(o => o.Order).ToList();
            //foreach (var startupTask in tasks)
            //{
            //    startupTask?.Startup();
            //}
        }

        /// <summary>
        /// Register Dependencies
        /// </summary>
        protected virtual void RegisterDependencies()
        {
            containerManager = new ContainerManager(new ContainerBuilder().Build());

            //var builder = new ContainerBuilder();
            //var container = builder.Build();
            //this._containerManager = new ContainerManager(container);

            //builder = new ContainerBuilder();
            //builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            //var typeFinder = new TypeFinder();
            //builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            //builder.Update(container);

            //set dependency resolve
        }


        #region Methods
        /// <summary>
        /// Initialize
        /// </summary>
        public void Initialize()
        {
            RegisterDependencies();

            RunStartupTasks();
        }

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }
        #endregion
    }
}
