namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientMedicaments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientsMedicaments",
                c => new
                    {
                        PatiMed = c.Int(nullable: false, identity: true),
                        IdPatients = c.Int(nullable: false),
                        MedicamentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatiMed)
                .ForeignKey("dbo.Medicaments", t => t.MedicamentID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.IdPatients, cascadeDelete: true)
                .Index(t => t.IdPatients)
                .Index(t => t.MedicamentID);
            
       
        }
        
        public override void Down()
        {
          
            
            DropForeignKey("dbo.PatientsMedicaments", "IdPatients", "dbo.Patients");
            DropForeignKey("dbo.PatientsMedicaments", "MedicamentID", "dbo.Medicaments");
            DropIndex("dbo.PatientsMedicaments", new[] { "MedicamentID" });
            DropIndex("dbo.PatientsMedicaments", new[] { "IdPatients" });
            DropTable("dbo.PatientsMedicaments");
        }
    }
}
