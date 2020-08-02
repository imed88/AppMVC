namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableMedecinConventionne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedecinConventionnes",
                c => new
                    {
                        idDoctors = c.Int(nullable: false, identity: true),
                        nameDoctors = c.String(),
                        emailDoctors = c.String(),
                        phoneDoctors = c.String(),
                        picDoctor = c.String(),
                        IdSpecialite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDoctors)
                .ForeignKey("dbo.Specialites", t => t.IdSpecialite, cascadeDelete: true)
                .Index(t => t.IdSpecialite);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedecinConventionnes", "IdSpecialite", "dbo.Specialites");
            DropIndex("dbo.MedecinConventionnes", new[] { "IdSpecialite" });
            DropTable("dbo.MedecinConventionnes");
        }
    }
}
