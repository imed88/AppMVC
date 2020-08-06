namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentModels",
                c => new
                    {
                        AppointmentID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        DoctorID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        TimeBlockHelper = c.String(),
                        Doctor_idDoctors = c.Int(),
                    })
                .PrimaryKey(t => t.AppointmentID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.MedecinConventionnes", t => t.Doctor_idDoctors)
                .Index(t => t.UserID)
                .Index(t => t.Doctor_idDoctors);
            
          
        }
        
        public override void Down()
        {
        
            
            DropForeignKey("dbo.AppointmentModels", "Doctor_idDoctors", "dbo.MedecinConventionnes");
            DropForeignKey("dbo.AppointmentModels", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.AppointmentModels", new[] { "Doctor_idDoctors" });
            DropIndex("dbo.AppointmentModels", new[] { "UserID" });
            DropTable("dbo.AppointmentModels");
        }
    }
}
