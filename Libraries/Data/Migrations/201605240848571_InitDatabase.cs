namespace Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IsDelete = c.Boolean(nullable: false),
                        Timespan = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        AddressId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        IsDelete = c.Boolean(nullable: false),
                        Timespan = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "code",
                                    new AnnotationValues(oldValue: null, newValue: "唯一编码")
                                },
                            }),
                        Province = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        Country = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        IsDelete = c.Boolean(nullable: false),
                        Timespan = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoleMapping",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleMapping", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRoleMapping", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "AddressId", "dbo.Address");
            DropIndex("dbo.UserRoleMapping", new[] { "RoleId" });
            DropIndex("dbo.UserRoleMapping", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "AddressId" });
            DropTable("dbo.UserRoleMapping");
            DropTable("dbo.Role");
            DropTable("dbo.Address",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Code",
                        new Dictionary<string, object>
                        {
                            { "code", "唯一编码" },
                        }
                    },
                });
            DropTable("dbo.User");
        }
    }
}
