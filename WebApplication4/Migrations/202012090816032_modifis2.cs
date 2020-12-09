namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifis2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OrderID", "dbo.Consultations");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "OrderID" });
            DropPrimaryKey("dbo.Orders");
            AddColumn("dbo.OrderDetails", "ConsultationID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "OrderID");
            CreateIndex("dbo.OrderDetails", "ConsultationID");
            AddForeignKey("dbo.OrderDetails", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.OrderDetails", new[] { "ConsultationID" });
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "OrderID", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "ConsultationID");
            AddPrimaryKey("dbo.Orders", "OrderID");
            CreateIndex("dbo.Orders", "OrderID");
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "OrderID", "dbo.Consultations", "ConsultationID");
        }
    }
}
