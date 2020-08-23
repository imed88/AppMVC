namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConsultation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ConsultationID = c.Int(nullable: false, identity: true),
                        diagnostic = c.String(),
                        UserID = c.String(maxLength: 128),
                        IdPatients = c.String(),
                        Patients_IdPatients = c.Int(),
                    })
                .PrimaryKey(t => t.ConsultationID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Patients", t => t.Patients_IdPatients)
                .Index(t => t.UserID)
                .Index(t => t.Patients_IdPatients);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultations", "Patients_IdPatients", "dbo.Patients");
            DropForeignKey("dbo.Consultations", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Consultations", new[] { "Patients_IdPatients" });
            DropIndex("dbo.Consultations", new[] { "UserID" });
            DropTable("dbo.Consultations");
        }
    }
}
