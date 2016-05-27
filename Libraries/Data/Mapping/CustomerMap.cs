using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Data.Mapping
{
    public class CustomerMap : BaseMap<Customer>
    {
        #region Ctor

        public CustomerMap() : base("Customer")
        {
            this.HasKey(o => o.Id);
            this.Property(o => o.Username).HasMaxLength(20);
            this.Property(o => o.Password).HasMaxLength(30);
        }
        #endregion
    }
}
