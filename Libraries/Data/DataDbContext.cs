using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Data.Mapping;

namespace Data
{
    public class DataDbContext : DbContext, IDbContext
    {
        public DataDbContext() : base("DefaultConnection")
        {
            //((IObjectContextAdapter) this).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// 在完成对派生上下文的模型的初始化后，并在该模型已锁定并用于初始化上下文之前，将调用此方法。虽然此方法的默认实现不执行任何操作，但可在派生类中重写此方法，这样便能在锁定模型之前对其进行进一步的配置。
        /// </summary>
        /// <param name="modelBuilder">定义要创建的上下文的模型的生成器。</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new AddressMap());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, new()
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Put the entity into the context
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            return base.Entry(entity);
        }

        /// <summary>
        /// Attach the entity to DbContext
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity AttachToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            var localEntity = this.Set<TEntity>().Local.FirstOrDefault(o => o.Id == entity.Id);
            if (localEntity == null)
            {
                //todo Local.Add() can do same thing?
                //this.Set<TEntity>().Local.Add(entity);
                this.Set<TEntity>().Attach(entity);
                return entity;
            }

            return localEntity;
        }

        /// <summary>
        /// Detach entity from DbContext
        /// </summary>
        /// <param name="entity"></param>
        public void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            ((IObjectContextAdapter)this).ObjectContext.Detach(entity);
        }
    }
}
