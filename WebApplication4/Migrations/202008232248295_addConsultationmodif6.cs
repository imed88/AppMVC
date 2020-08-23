namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConsultationmodif6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medicaments", "Consultation_ConsultationID", "dbo.Consultations");
            DropIndex("dbo.Medicaments", new[] { "Consultation_ConsultationID" });
            DropColumn("dbo.Medicaments", "Consultation_ConsultationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicaments", "Consultation_ConsultationID", c => c.Int());
            CreateIndex("dbo.Medicaments", "Consultation_ConsultationID");
            AddForeignKey("dbo.Medicaments", "Consultation_ConsultationID", "dbo.Consultations", "ConsultationID");
        }
    }
}
