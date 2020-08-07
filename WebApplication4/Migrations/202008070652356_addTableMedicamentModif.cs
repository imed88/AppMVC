namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableMedicamentModif : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicaments", "IsSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicaments", "IsSelected", c => c.Boolean(nullable: false));
        }
    }
}
