namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointementModels", "Dates", c => c.DateTime(nullable: false));
            DropColumn("dbo.AppointementModels", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppointementModels", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.AppointementModels", "Dates");
        }
    }
}
