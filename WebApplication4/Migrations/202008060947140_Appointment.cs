namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Appointment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AppointementModels", "TimeBlockHelper");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppointementModels", "TimeBlockHelper", c => c.String());
        }
    }
}
