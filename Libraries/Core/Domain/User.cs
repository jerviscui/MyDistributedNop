using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
