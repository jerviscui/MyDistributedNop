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

namespace Data.Mapping
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap(string table = "")
        {
            this.ToTable(!string.IsNullOrEmpty(table) ? table : typeof (T).Name);

            this.Property(o => o.Timespan).IsRowVersion().HasColumnOrder(100);
            this.Property(o => o.IsDelete).HasColumnOrder(99);
        }
    }
}
