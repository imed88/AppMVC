namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifs1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicaments", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicaments", "ImagePath", c => c.String());
        }
    }
}
