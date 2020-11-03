namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "IdSpecialite" });
            CreateIndex("dbo.Products", "idSpecialite");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "idSpecialite" });
            CreateIndex("dbo.Products", "IdSpecialite");
        }
    }
}
