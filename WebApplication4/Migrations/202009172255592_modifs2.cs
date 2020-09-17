namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointementModels", "IdSpecialites", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppointementModels", "IdSpecialites");
        }
    }
}
