namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicaments", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicaments", "Image", c => c.String());
        }
    }
}
