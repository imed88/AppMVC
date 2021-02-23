namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventhemeColor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "ThemeColor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "ThemeColor", c => c.String(nullable: false));
        }
    }
}
