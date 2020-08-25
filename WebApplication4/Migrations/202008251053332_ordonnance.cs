namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordonnance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientsMedicaments", "MedicamentID", "dbo.Medicaments");
            DropForeignKey("dbo.PatientsMedicaments", "IdPatients", "dbo.Patients");
            DropIndex("dbo.PatientsMedicaments", new[] { "IdPatients" });
            DropIndex("dbo.PatientsMedicaments", new[] { "MedicamentID" });
            CreateTable(
                "dbo.Ordonnances",
                c => new
                    {
                        OrdID = c.Int(nullable: false, identity: true),
                        idPatients = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrdID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Patients", t => t.idPatients, cascadeDelete: true)
                .Index(t => t.idPatients)
                .Index(t => t.UserID);
            
            DropTable("dbo.PatientsMedicaments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PatientsMedicaments",
                c => new
                    {
                        PatiMed = c.Int(nullable: false, identity: true),
                        IdPatients = c.Int(nullable: false),
                        MedicamentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatiMed);
            
            DropForeignKey("dbo.Ordonnances", "idPatients", "dbo.Patients");
            DropForeignKey("dbo.Ordonnances", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Ordonnances", new[] { "UserID" });
            DropIndex("dbo.Ordonnances", new[] { "idPatients" });
            DropTable("dbo.Ordonnances");
            CreateIndex("dbo.PatientsMedicaments", "MedicamentID");
            CreateIndex("dbo.PatientsMedicaments", "IdPatients");
            AddForeignKey("dbo.PatientsMedicaments", "IdPatients", "dbo.Patients", "IdPatients", cascadeDelete: true);
            AddForeignKey("dbo.PatientsMedicaments", "MedicamentID", "dbo.Medicaments", "MedicamentID", cascadeDelete: true);
        }
    }
}
