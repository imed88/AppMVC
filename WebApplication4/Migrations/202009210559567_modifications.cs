namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppointementModels", "Specialite_IdSpecialite", "dbo.Specialites");
            DropIndex("dbo.AppointementModels", new[] { "Specialite_IdSpecialite" });
            AddColumn("dbo.AppointementModels", "DtEdit", c => c.DateTime(nullable: false));
            DropColumn("dbo.AppointementModels", "JourHeureTravail1");
            DropColumn("dbo.AppointementModels", "JourHeureTravail2");
            DropColumn("dbo.AppointementModels", "Specialite_IdSpecialite");
            DropColumn("dbo.MedecinConventionnes", "JourHeureTravail1");
            DropColumn("dbo.MedecinConventionnes", "JourHeureTravail2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedecinConventionnes", "JourHeureTravail2", c => c.String());
            AddColumn("dbo.MedecinConventionnes", "JourHeureTravail1", c => c.String());
            AddColumn("dbo.AppointementModels", "Specialite_IdSpecialite", c => c.Int());
            AddColumn("dbo.AppointementModels", "JourHeureTravail2", c => c.String(nullable: false));
            AddColumn("dbo.AppointementModels", "JourHeureTravail1", c => c.String(nullable: false));
            DropColumn("dbo.AppointementModels", "DtEdit");
            CreateIndex("dbo.AppointementModels", "Specialite_IdSpecialite");
            AddForeignKey("dbo.AppointementModels", "Specialite_IdSpecialite", "dbo.Specialites", "IdSpecialite");
        }
    }
}