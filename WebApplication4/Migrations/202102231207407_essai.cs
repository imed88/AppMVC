namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class essai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Subjects", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Subjects");
        }
    }
}
