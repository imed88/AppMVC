namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageFile", c => c.String());
            DropColumn("dbo.Products", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Image", c => c.String());
            DropColumn("dbo.Products", "ImageFile");
        }
    }
}
