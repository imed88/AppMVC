namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifis5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Consultation_ConsultationID", "dbo.Consultations");
            DropIndex("dbo.OrderDetails", new[] { "Consultation_ConsultationID" });
            DropColumn("dbo.OrderDetails", "Consultation_ConsultationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Consultation_ConsultationID", c => c.Int());
            CreateIndex("dbo.OrderDetails", "Consultation_ConsultationID");
            AddForeignKey("dbo.OrderDetails", "Consultation_ConsultationID", "dbo.Consultations", "ConsultationID");
        }
    }
}
