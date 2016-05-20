using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity</returns>
        T GetById(object id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities"></param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities"></param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity by logic
        /// </summary>
        /// <param name="entity"></param>
        void Hide(T entity);

        /// <summary>
        /// Delete entities by logic
        /// </summary>
        /// <param name="entities"></param>
        void Hide(IEnumerable<T> entities);

        /// <summary>
        /// Get the Table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Get the table by load all records for readonly operation, 
        /// </summary>
        IQueryable<T> TableNoTracking { get; }
    }
}
