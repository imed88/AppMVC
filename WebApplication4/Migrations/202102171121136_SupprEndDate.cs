namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupprEndDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "DateEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "DateEnd", c => c.DateTime(nullable: false));
        }
    }
}
