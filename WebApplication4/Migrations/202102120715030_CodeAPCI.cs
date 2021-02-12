namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeAPCI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "CodeAPCI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "CodeAPCI");
        }
    }
}
