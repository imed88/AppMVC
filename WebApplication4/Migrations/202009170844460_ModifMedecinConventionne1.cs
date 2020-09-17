namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifMedecinConventionne1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedecinConventionnes", "JourHeureTravail1", c => c.String());
            AddColumn("dbo.MedecinConventionnes", "JourHeureTravail2", c => c.String());
            DropColumn("dbo.MedecinConventionnes", "JourHeureTravail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedecinConventionnes", "JourHeureTravail", c => c.String());
            DropColumn("dbo.MedecinConventionnes", "JourHeureTravail2");
            DropColumn("dbo.MedecinConventionnes", "JourHeureTravail1");
        }
    }
}
