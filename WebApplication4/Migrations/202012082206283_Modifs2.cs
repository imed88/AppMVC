namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifs2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.Orders", new[] { "ConsultationID" });
            AddColumn("dbo.OrderDetails", "ConsultationID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "ConsultationID");
            AddForeignKey("dbo.OrderDetails", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
            DropColumn("dbo.Orders", "ConsultationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ConsultationID", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetails", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.OrderDetails", new[] { "ConsultationID" });
            DropColumn("dbo.OrderDetails", "ConsultationID");
            CreateIndex("dbo.Orders", "ConsultationID");
            AddForeignKey("dbo.Orders", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
        }
    }
}
