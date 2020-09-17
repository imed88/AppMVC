namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointementModels", "JourHeureTravail1", c => c.String(nullable: false));
            DropColumn("dbo.AppointementModels", "JourHeureTravail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppointementModels", "JourHeureTravail", c => c.String(nullable: false));
            DropColumn("dbo.AppointementModels", "JourHeureTravail1");
        }
    }
}
