namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppointementModels", "Specialite_IdSpecialite", "dbo.Specialites");
            DropIndex("dbo.AppointementModels", new[] { "Specialite_IdSpecialite" });
            AddColumn("dbo.AppointementModels", "JourHeureTravail1", c => c.String(nullable: false));
            AddColumn("dbo.AppointementModels", "JourHeureTravail2", c => c.String(nullable: false));
            DropColumn("dbo.AppointementModels", "JourHeureTravail");
            DropColumn("dbo.AppointementModels", "Specialite_IdSpecialite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppointementModels", "Specialite_IdSpecialite", c => c.Int());
            AddColumn("dbo.AppointementModels", "JourHeureTravail", c => c.String(nullable: false));
            DropColumn("dbo.AppointementModels", "JourHeureTravail2");
            DropColumn("dbo.AppointementModels", "JourHeureTravail1");
            CreateIndex("dbo.AppointementModels", "Specialite_IdSpecialite");
            AddForeignKey("dbo.AppointementModels", "Specialite_IdSpecialite", "dbo.Specialites", "IdSpecialite");
        }
    }
}
