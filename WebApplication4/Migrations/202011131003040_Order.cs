namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "idPatients", "dbo.Patients");
            DropIndex("dbo.Products", new[] { "idPatients" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderName = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        idPatients = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Patients", t => t.idPatients, cascadeDelete: true)
                .Index(t => t.idPatients);
            
            DropColumn("dbo.Products", "idPatients");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "idPatients", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "idPatients", "dbo.Patients");
            DropIndex("dbo.Orders", new[] { "idPatients" });
            DropTable("dbo.Orders");
            CreateIndex("dbo.Products", "idPatients");
            AddForeignKey("dbo.Products", "idPatients", "dbo.Patients", "IdPatients", cascadeDelete: true);
        }
    }
}
