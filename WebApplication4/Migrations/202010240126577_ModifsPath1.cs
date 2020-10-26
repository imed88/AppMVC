namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifsPath1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedImages", "path", c => c.String());
            DropColumn("dbo.Medicaments", "path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicaments", "path", c => c.String());
            DropColumn("dbo.MedImages", "path");
        }
    }
}
