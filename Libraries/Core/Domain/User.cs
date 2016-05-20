using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public IList<Role> Roles { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
