namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        IsDelete = c.Boolean(nullable: false),
                        Timespan = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Test");
        }
    }
}
