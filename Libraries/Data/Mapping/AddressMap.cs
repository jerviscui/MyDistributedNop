using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Data.Mapping
{
    public class AddressMap : BaseMap<Address>
    {
        public AddressMap() : base("Address")
        {
            this.HasKey(o => o.Id);

            this.Property(o => o.Code).HasMaxLength(50).HasColumnAnnotation("code", "唯一编码");
            this.Property(o => o.City).HasMaxLength(100);
            this.Property(o => o.Country).HasMaxLength(100);
            this.Property(o => o.Province).HasMaxLength(100);
        }
    }
}
