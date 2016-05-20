using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;

namespace Data.Mapping
{
    public class RoleMap : BaseMap<Role>
    {
        public RoleMap() : base("Role")
        {
            this.HasKey(o => o.Id);
        }
    }
}
