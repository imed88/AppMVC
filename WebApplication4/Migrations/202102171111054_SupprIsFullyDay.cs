namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupprIsFullyDay : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "IsFullDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "IsFullDay", c => c.Boolean(nullable: false));
        }
    }
}
