namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Categorie", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Categorie");
        }
    }
}
