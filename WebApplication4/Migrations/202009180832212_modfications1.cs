namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modfications1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointementModels", "JourHeureTravail2", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppointementModels", "JourHeureTravail2");
        }
    }
}
