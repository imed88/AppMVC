namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsultationOrdonnances", "patients_IdPatients", "dbo.Patients");
            DropIndex("dbo.ConsultationOrdonnances", new[] { "patients_IdPatients" });
            DropColumn("dbo.ConsultationOrdonnances", "patients_IdPatients");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ConsultationOrdonnances", "patients_IdPatients", c => c.Int());
            CreateIndex("dbo.ConsultationOrdonnances", "patients_IdPatients");
            AddForeignKey("dbo.ConsultationOrdonnances", "patients_IdPatients", "dbo.Patients", "IdPatients");
        }
    }
}
