namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedConvEvent3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "ThemeColor", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "ThemeColor", c => c.DateTime(nullable: false));
        }
    }
}
