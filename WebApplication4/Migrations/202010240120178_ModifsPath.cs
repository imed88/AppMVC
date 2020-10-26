namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifsPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicaments", "path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicaments", "path");
        }
    }
}
