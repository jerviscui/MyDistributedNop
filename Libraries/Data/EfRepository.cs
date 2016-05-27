using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;

namespace Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly IDbContext DbContext;
        private DbSet<T> _entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public EfRepository(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected DbSet<T> Entities
        {
            get
            {
                return _entities ?? (_entities = DbContext.Set<T>());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private string GetValidErrorMessages(DbEntityValidationException exception)
        {
            var builder = new StringBuilder();

            foreach (var validationErrors in exception.EntityValidationErrors)
            {
                foreach (var error in validationErrors.ValidationErrors)
                {
                    builder.Append(error.PropertyName + " : " + error.ErrorMessage).Append(Environment.NewLine);
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity</returns>
        public T GetById(object id)
        {
            //use SingleOrDefault for without DetectChanges()
            return this.Entities.SingleOrDefault(o => o.Id == (int)id);
            //return this.Entities.Find(id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            try
            {
                this.Entities.Add(entity);
                this.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(GetValidErrorMessages(ex), ex);
            }
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities"></param>
        public void Insert(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            try
            {
                //todo bulk insert efficiency
                //explain.1
                //foreach (var entity in entities)
                //{
                //    this.Entities.Add(entity);
                //}

                //explain.2
                //var enable = this._dbContext.Configuration.AutoDetectChangesEnabled;
                //try
                //{
                //    this._dbContext.Configuration.AutoDetectChangesEnabled = false;
                //    foreach (var entity in entities)
                //    {
                //        this.Entities.Add(entity);
                //    }
                //}
                //finally
                //{
                //    this._dbContext.Configuration.AutoDetectChangesEnabled = enable;
                //}
                
                //explain.3 DbSet.AddRange() by EF 6.0
                this.Entities.AddRange(entities);

                this.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(GetValidErrorMessages(ex), ex);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entities");
            }

            try
            {
                this.DbContext.Entry(entity).State = EntityState.Modified;

                this.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(GetValidErrorMessages(ex), ex);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ((IObjectContextAdapter)this.DbContext).ObjectContext.Refresh(RefreshMode.ClientWins, ex.Entries);
                this.DbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities"></param>
        public void Update(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            try
            {
                foreach (var entity in entities)
                {
                    this.DbContext.Entry(entity).State = EntityState.Modified;
                }

                this.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(GetValidErrorMessages(ex), ex);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ((IObjectContextAdapter)this.DbContext).ObjectContext.Refresh(RefreshMode.ClientWins, ex.Entries);
                this.DbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entities");
            }

            try
            {
                this.Entities.Remove(entity);

                this.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(GetValidErrorMessages(ex), ex);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities"></param>
        public void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            try
            {
                this.Entities.RemoveRange(entities);

                this.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(GetValidErrorMessages(ex), ex);
            }
        }

        /// <summary>
        /// Delete entity by logic
        /// </summary>
        /// <param name="entity"></param>
        public void Hide(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entities");
            }

            entity.IsDelete = true;
            Update(entity);
        }

        /// <summary>
        /// Delete entities by logic
        /// </summary>
        /// <param name="entities"></param>
        public void Hide(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            foreach (var entity in entities)
            {
                entity.IsDelete = true;
            }
            Update(entities);
        }

        /// <summary>
        /// Get the Table
        /// </summary>
        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        /// <summary>
        /// Get the table by load all records for readonly operation, 
        /// </summary>
        public IQueryable<T> TableNoTracking
        {
            get { return this.Entities.AsNoTracking(); }
        }
    }
}
