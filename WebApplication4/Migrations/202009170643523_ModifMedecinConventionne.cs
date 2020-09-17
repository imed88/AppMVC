namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifMedecinConventionne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedecinConventionnes", "JourHeureTravail1", c => c.String());
            AddColumn("dbo.MedecinConventionnes", "JourHeureTravail2", c => c.String());
            DropColumn("dbo.MedecinConventionnes", "picDoctor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedecinConventionnes", "picDoctor", c => c.String());
            DropColumn("dbo.MedecinConventionnes", "JourHeureTravail2");
            DropColumn("dbo.MedecinConventionnes", "JourHeureTravail1");
        }
    }
}
