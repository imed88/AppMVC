namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForiegnKeyMedecinEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventsMedecinConventionnes",
                c => new
                    {
                        Events_EventID = c.Int(nullable: false),
                        MedecinConventionne_idDoctors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Events_EventID, t.MedecinConventionne_idDoctors })
                .ForeignKey("dbo.Events", t => t.Events_EventID, cascadeDelete: true)
                .ForeignKey("dbo.MedecinConventionnes", t => t.MedecinConventionne_idDoctors, cascadeDelete: true)
                .Index(t => t.Events_EventID)
                .Index(t => t.MedecinConventionne_idDoctors);
            
            AddColumn("dbo.Events", "idDoctors", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventsMedecinConventionnes", "MedecinConventionne_idDoctors", "dbo.MedecinConventionnes");
            DropForeignKey("dbo.EventsMedecinConventionnes", "Events_EventID", "dbo.Events");
            DropIndex("dbo.EventsMedecinConventionnes", new[] { "MedecinConventionne_idDoctors" });
            DropIndex("dbo.EventsMedecinConventionnes", new[] { "Events_EventID" });
            DropColumn("dbo.Events", "idDoctors");
            DropTable("dbo.EventsMedecinConventionnes");
        }
    }
}
