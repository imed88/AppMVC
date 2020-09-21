namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointementModels", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppointementModels", "Date");
        }
    }
}
