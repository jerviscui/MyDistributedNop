using System.Collections.Generic;
using Core.Domain;

namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.DataDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.DataDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var user = new User()
            {
                Address = new Address()
                {
                    City = "Shenzhen",
                    Code = "00001",
                    Country = "China",
                    Province = "Guangzhou"
                },
                CreateTime = DateTime.Now,
                Roles = new List<Role>()
                {
                    new Role() {RoleName = "test"},
                    new Role() {RoleName = "admin"}
                },
                UserName = "xiaoming"
            };

            context.Set<Address>().AddOrUpdate(o => o.Code, user.Address);
            context.Set<Role>().AddOrUpdate(o => o.RoleName, user.Roles.ToArray());
            context.Set<User>().AddOrUpdate(o => new { o.UserName }, user);
        }
    }
}
