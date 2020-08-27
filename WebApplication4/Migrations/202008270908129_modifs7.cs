namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsultationOrdonnances", "patients_IdPatients", "dbo.Patients");
            DropIndex("dbo.ConsultationOrdonnances", new[] { "patients_IdPatients" });
            AddColumn("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd", c => c.Int());
            CreateIndex("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd");
            AddForeignKey("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd", "dbo.ConsultationOrdonnances", "IDConsultOrd");
            DropColumn("dbo.ConsultationOrdonnances", "patients_IdPatients");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ConsultationOrdonnances", "patients_IdPatients", c => c.Int());
            DropForeignKey("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd", "dbo.ConsultationOrdonnances");
            DropIndex("dbo.Patients", new[] { "ConsultationOrdonnances_IDConsultOrd" });
            DropColumn("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd");
            CreateIndex("dbo.ConsultationOrdonnances", "patients_IdPatients");
            AddForeignKey("dbo.ConsultationOrdonnances", "patients_IdPatients", "dbo.Patients", "IdPatients");
        }
    }
}
