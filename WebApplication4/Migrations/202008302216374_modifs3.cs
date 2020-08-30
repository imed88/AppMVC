namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ordonnances", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Ordonnances", new[] { "UserID" });
            DropColumn("dbo.Ordonnances", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ordonnances", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ordonnances", "UserID");
            AddForeignKey("dbo.Ordonnances", "UserID", "dbo.AspNetUsers", "Id");
        }
    }
}
