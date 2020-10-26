namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifsPath2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MedImages", "path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedImages", "path", c => c.String());
        }
    }
}
