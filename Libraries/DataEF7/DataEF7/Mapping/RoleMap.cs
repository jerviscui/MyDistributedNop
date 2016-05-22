using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.Data.Entity;

namespace DataEF7.Mapping
{
    public class RoleMap : BaseMap
    {
        public RoleMap() : base(builder => {
            var entity = builder.Entity<Role>();
            entity.HasKey(o => o.Id);
        }, "Role")
        {

        }
        
        protected override void ModelMapping(ModelBuilder builder)
        {
            base.ModelMapping(builder);

            var entity = builder.Entity<Role>();
            entity.HasKey(o => o.Id);
        }
    }
}
