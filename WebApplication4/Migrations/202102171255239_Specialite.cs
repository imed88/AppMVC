namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Specialite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Specialites", "Color", c => c.String());
            DropColumn("dbo.Specialites", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Specialites", "IsDelete", c => c.Boolean(nullable: false));
            DropColumn("dbo.Specialites", "Color");
        }
    }
}
