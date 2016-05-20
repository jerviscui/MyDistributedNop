using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Data
{
    public interface IDbContext
    {
        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity, new();

        /// <summary>
        /// Put the entity into the context
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity, new();

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Get the ObjectContextAdapter configuration
        /// </summary>
        DbContextConfiguration Configuration { get; }

        /// <summary>
        /// Attach the entity to DbContext
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity AttachToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new();

        /// <summary>
        /// Detach entity from DbContext
        /// </summary>
        /// <param name="entity"></param>
        void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity, new();
    }
}
