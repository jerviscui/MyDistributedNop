using Core;
using Core.Domain;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.ChangeTracking;

namespace DataEF7
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
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity, new();

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        ///// <summary>
        ///// Get the ObjectContextAdapter configuration
        ///// </summary>
        //DbContextConfiguration Configuration { get; }

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
