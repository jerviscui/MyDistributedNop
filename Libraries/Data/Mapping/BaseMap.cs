using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Core.Domain;

namespace Data.Mapping
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        protected BaseMap(string table = "")
        {
            string typeName = typeof(T).Name;
            this.ToTable(!string.IsNullOrEmpty(table) ? table : typeName.Substring(0, typeName.IndexOf("Map", StringComparison.CurrentCulture)));

            this.Property(o => o.Timespan).IsRowVersion().HasColumnOrder(100);
            this.Property(o => o.IsDelete).HasColumnOrder(99);
        }
    }
}
