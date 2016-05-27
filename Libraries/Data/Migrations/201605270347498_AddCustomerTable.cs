namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        IsDelete = c.Boolean(nullable: false),
                        Timespan = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 20),
                        Password = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(o => o.Username);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customer", new[] { "Username" });
            DropTable("dbo.Customer");
        }
    }
}
