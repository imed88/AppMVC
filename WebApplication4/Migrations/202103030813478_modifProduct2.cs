namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifProduct2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AP");
        }
    }
}
