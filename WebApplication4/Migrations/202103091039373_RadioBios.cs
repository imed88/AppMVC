namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RadioBios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RadioBios",
                c => new
                    {
                        RadioBioID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.RadioBioID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RadioBios", "OrderID", "dbo.Orders");
            DropIndex("dbo.RadioBios", new[] { "OrderID" });
            DropTable("dbo.RadioBios");
        }
    }
}
