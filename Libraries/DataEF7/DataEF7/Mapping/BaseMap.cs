using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace DataEF7.Mapping
{
    public abstract class BaseMap : IBaseMap
    {
        protected BaseMap(Action<ModelBuilder> mapAction, string table = "")
        {
            MapAction = (builder) =>
            {
                var entity = builder.Entity<BaseEntity>();

                string typeName = this.GetType().Name;
                entity.ToTable(!string.IsNullOrEmpty(this._tableName) ? this._tableName : typeName.Substring(0, typeName.IndexOf("Map", StringComparison.CurrentCulture)));

                entity.Property(o => o.Timespan);
                entity.Property(o => o.IsDelete).HasDefaultValue(false).HasDefaultValueSql("(0)");

                mapAction?.Invoke(builder);
            };

            _tableName = table;
        }

        private readonly string _tableName;

        /// <summary>
        /// Rules for entity map to table
        /// </summary>
        private Action<ModelBuilder> MapAction { get; }

        /// <summary>
        /// Model creating event
        /// </summary>
        /// <param name="builder"></param>
        public void OnModelCreating(ModelBuilder builder)
        {
            //Mode B: childs call base's ctor method regist mapping rules
            MapAction(builder);

            //Mode A: childs override ModelMapping() method
            //this.ModelMapping(builder);
        }

        /// <summary>
        /// Rules for entity map to table
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void ModelMapping(ModelBuilder builder)
        {
            var entity = builder.Entity<BaseEntity>();

            string typeName = this.GetType().Name;
            entity.ToTable(!string.IsNullOrEmpty(this._tableName) ? this._tableName : typeName.Substring(0, typeName.IndexOf("Map", StringComparison.CurrentCulture)));

            entity.Property(o => o.Timespan);
            entity.Property(o => o.IsDelete).HasDefaultValue(false).HasDefaultValueSql("(0)");
        }
    }
}
