namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RadioBios1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RadioBios", "OrderID", "dbo.Orders");
            DropIndex("dbo.RadioBios", new[] { "OrderID" });
            AddColumn("dbo.RadioBios", "ConsultationID", c => c.Int(nullable: false));
            CreateIndex("dbo.RadioBios", "ConsultationID");
            AddForeignKey("dbo.RadioBios", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
            DropColumn("dbo.RadioBios", "OrderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RadioBios", "OrderID", c => c.Int(nullable: false));
            DropForeignKey("dbo.RadioBios", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.RadioBios", new[] { "ConsultationID" });
            DropColumn("dbo.RadioBios", "ConsultationID");
            CreateIndex("dbo.RadioBios", "OrderID");
            AddForeignKey("dbo.RadioBios", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
    }
}
