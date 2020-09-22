namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "natureVisite", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consultations", "natureVisite");
        }
    }
}
