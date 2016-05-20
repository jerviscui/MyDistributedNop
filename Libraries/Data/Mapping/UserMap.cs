using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Data.Mapping
{
    public class UserMap : BaseMap<User>
    {
        public UserMap() : base("User")
        {
            this.HasKey(o => o.Id);

            //one to many
            this.HasRequired(o => o.Address).WithMany().HasForeignKey(user => user.AddressId);
            //many to many
            this.HasMany(o => o.Roles).WithMany().Map(configuration => configuration.ToTable("UserRoleMapping").MapLeftKey("UserId").MapRightKey("RoleId"));

            this.Property(o => o.UserName).HasMaxLength(50);
        }

        private void ConfigurationAction(ManyToManyAssociationMappingConfiguration manyToManyAssociationMappingConfiguration)
        {
            manyToManyAssociationMappingConfiguration.ToTable("UserRoleMapping")
                .MapLeftKey("UserId")
                .MapRightKey("RoleId");
        }
    }
}
