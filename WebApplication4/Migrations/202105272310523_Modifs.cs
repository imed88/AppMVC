namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedecinConventionnes", "nameDoctors", c => c.String(nullable: false));
            AlterColumn("dbo.MedecinConventionnes", "emailDoctors", c => c.String(nullable: false));
            AlterColumn("dbo.MedecinConventionnes", "phoneDoctors", c => c.String(nullable: false));
            AlterColumn("dbo.MedecinConventionnes", "JourTravail1", c => c.String(nullable: false));
            AlterColumn("dbo.MedecinConventionnes", "JourTravail2", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "MatriculePatients", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "NomPatient", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "PrenomPatient", c => c.String(nullable: false));
            AlterColumn("dbo.Consultations", "diagnostic", c => c.String(nullable: false));
            AlterColumn("dbo.ConsultationDetails", "Comment", c => c.String(nullable: false));
            AlterColumn("dbo.ConsultationDetails", "CNAM", c => c.String(nullable: false));
            AlterColumn("dbo.FileDetails", "FileName", c => c.String(nullable: false));
            AlterColumn("dbo.Usines", "UsineName", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "MatriculePatients", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "NameProduct", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Categorie", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "DenominationCI", c => c.String(nullable: false));
            AlterColumn("dbo.RDVs", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RDVs", "Message", c => c.String());
            AlterColumn("dbo.Products", "DenominationCI", c => c.String());
            AlterColumn("dbo.Products", "Categorie", c => c.String());
            AlterColumn("dbo.Products", "NameProduct", c => c.String());
            AlterColumn("dbo.Products", "Code", c => c.String());
            AlterColumn("dbo.Orders", "MatriculePatients", c => c.String());
            AlterColumn("dbo.Usines", "UsineName", c => c.String());
            AlterColumn("dbo.FileDetails", "FileName", c => c.String());
            AlterColumn("dbo.ConsultationDetails", "CNAM", c => c.String());
            AlterColumn("dbo.ConsultationDetails", "Comment", c => c.String());
            AlterColumn("dbo.Consultations", "diagnostic", c => c.String());
            AlterColumn("dbo.Patients", "PrenomPatient", c => c.String());
            AlterColumn("dbo.Patients", "NomPatient", c => c.String());
            AlterColumn("dbo.Patients", "MatriculePatients", c => c.String());
            AlterColumn("dbo.MedecinConventionnes", "JourTravail2", c => c.String());
            AlterColumn("dbo.MedecinConventionnes", "JourTravail1", c => c.String());
            AlterColumn("dbo.MedecinConventionnes", "phoneDoctors", c => c.String());
            AlterColumn("dbo.MedecinConventionnes", "emailDoctors", c => c.String());
            AlterColumn("dbo.MedecinConventionnes", "nameDoctors", c => c.String());
        }
    }
}
