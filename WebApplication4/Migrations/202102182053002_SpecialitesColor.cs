namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecialitesColor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Specialites", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Specialites", "Color", c => c.String());
        }
    }
}
