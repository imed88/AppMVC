namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class consultationModif : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Consultations", name: "Patients_IdPatients", newName: "Patient_IdPatients");
            RenameIndex(table: "dbo.Consultations", name: "IX_Patients_IdPatients", newName: "IX_Patient_IdPatients");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Consultations", name: "IX_Patient_IdPatients", newName: "IX_Patients_IdPatients");
            RenameColumn(table: "dbo.Consultations", name: "Patient_IdPatients", newName: "Patients_IdPatients");
        }
    }
}
