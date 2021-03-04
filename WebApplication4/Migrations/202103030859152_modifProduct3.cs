namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifProduct3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "AP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "AP", c => c.String());
        }
    }
}
