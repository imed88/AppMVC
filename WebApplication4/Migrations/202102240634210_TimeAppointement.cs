namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeAppointement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointementModels", "dateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppointementModels", "dateTime");
        }
    }
}
