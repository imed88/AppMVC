namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppointementModels", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.AppointementModels", new[] { "UserID" });
            DropColumn("dbo.AppointementModels", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppointementModels", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.AppointementModels", "UserID");
            AddForeignKey("dbo.AppointementModels", "UserID", "dbo.AspNetUsers", "Id");
        }
    }
}
