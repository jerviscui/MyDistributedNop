using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Core.Domain;
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

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  
        /// The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. 
        /// The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params DbParameter[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters?.ToArray<object>());
        }

        /// <summary>
        /// Execute stores procedure and load a list of entities at the end
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="commandText">Command text, procedure name</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entities</returns>
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params DbParameter[] parameters)
            where TEntity : BaseEntity, new()
        {
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    commandText += i == 0 ? " " : ", ";
                    commandText += "@" + parameters[i].ParameterName;

                    if (parameters[i].Direction == ParameterDirection.InputOutput || parameters[i].Direction == ParameterDirection.Output)
                    {
                        commandText += " output";
                    }
                }
            }

            var result = this.Database.SqlQuery<TEntity>(commandText, parameters?.ToArray<object>()).ToList();

            var enable = this.Configuration.AutoDetectChangesEnabled;
            try
            {
                this.Configuration.AutoDetectChangesEnabled = false;
                for (int i = 0; i < result.Count(); i++)
                {
                    result[i] = AttachToContext(result[i]);
                }
            }
            finally
            {
                this.Configuration.AutoDetectChangesEnabled = enable;
            }

            return result;
        }

        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string</param>
        /// <param name="doNotEnsureTransaction">false - the transaction creation is not ensured; true - the transaction creation is ensured.</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null,
            params DbParameter[] parameters)
        {
            int? originalTime = this.Database.CommandTimeout;
            if (timeout.HasValue)
            {
                this.Database.CommandTimeout = timeout;
            }

            var result = this.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql, parameters.ToArray<object>());
            if (originalTime != null)
            {
                this.Database.CommandTimeout = originalTime;
            }

            return result;
        }

    }
}
