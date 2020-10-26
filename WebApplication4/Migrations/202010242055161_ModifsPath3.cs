namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifsPath3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedImages", "ImgPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedImages", "ImgPath");
        }
    }
}
