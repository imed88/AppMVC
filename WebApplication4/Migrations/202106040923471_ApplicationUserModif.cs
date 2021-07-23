namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserModif : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ActivationCode", c => c.Guid(nullable: false));
            AddColumn("dbo.AspNetUsers", "ResetPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ResetPassword");
            DropColumn("dbo.AspNetUsers", "ActivationCode");
        }
    }
}
