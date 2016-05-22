using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.Data.Entity;

namespace DataEF7.Mapping
{
    public class UserMap : BaseMap
    {
        public UserMap() : base(Mapping, "User")
        {
            
        }
        
        private static void Mapping(ModelBuilder builder)
        {
            var entity = builder.Entity<User>();
            entity.HasKey(o => o.Id);

            entity.HasOne(o => o.Address).WithMany().HasForeignKey(o => o.AddressId);
            //todo: how to do many to many?
            entity.HasMany(o => o.Roles);
        }
    }
}
