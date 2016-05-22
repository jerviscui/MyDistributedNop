using System;
using System.Linq;
using Core;
using Core.Domain;
using DataEF7.Mapping;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.ChangeTracking;

namespace DataEF7
{
    public class Ef7DbContext : DbContext, IDbContext
    {
        /// <summary>
        ///     Override this method to configure the database (and other options) to be used for this context.
        ///     This method is called for each instance of the context that is created.
        /// </summary>
        /// <remarks>
        ///     If you passed an instance of <see cref="T:Microsoft.Data.Entity.Infrastructure.DbContextOptions" /> to the constructor of the context (or
        ///     provided an <see cref="T:System.IServiceProvider" /> with <see cref="T:Microsoft.Data.Entity.Infrastructure.DbContextOptions" /> registered) then
        ///     it is cloned before being passed to this method. This allows the options to be altered without
        ///     affecting other context instances that are constructed with the same <see cref="T:Microsoft.Data.Entity.Infrastructure.DbContextOptions" />
        ///     instance.
        /// </remarks>
        /// <param name="optionsBuilder">
        ///     A builder used to create or modify options for this context. Databases (and other extensions)
        ///     typically define extension methods on this object that allow you to configure the context.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //todo: UseSqlServer() not work!
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MyDistributedNopEF7;Integrated Security=False;User ID=sa;Password=123456;Connect Timeout=15;");

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        ///     Override this method to further configure the model that was discovered by convention from the entity types
        ///     exposed in <see cref="T:Microsoft.Data.Entity.DbSet`1" /> properties on your derived context. The resulting model may be cached
        ///     and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">
        ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
        ///     define extension methods on this object that allow you to configure aspects of the model that are specific
        ///     to a given database.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //todo: has another way to replace Configurations and EntityTypeConfiguration<>

            //modelBuilder.Entity<BaseEntity>().Property(o => o.Timespan);
            new RoleMap().OnModelCreating(modelBuilder);
            new UserMap().OnModelCreating(modelBuilder);
            new AddressMap().OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, new()
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Put the entity into the context
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public new EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
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
            var localEntity = this.Set<TEntity>().FirstOrDefault(o => o.Id == entity.Id);
            if (localEntity == null)
            {
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
            throw new NotImplementedException();
        }
    }
}
