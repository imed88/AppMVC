namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicaments", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicaments", "Image");
        }
    }
}
