namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedConvEvent2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Subject", c => c.String());
            AddColumn("dbo.Events", "ThemeColor", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "IsFullDay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "IsFullDay");
            DropColumn("dbo.Events", "ThemeColor");
            DropColumn("dbo.Events", "Subject");
        }
    }
}
