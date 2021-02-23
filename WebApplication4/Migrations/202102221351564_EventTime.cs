namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "time");
        }
    }
}
