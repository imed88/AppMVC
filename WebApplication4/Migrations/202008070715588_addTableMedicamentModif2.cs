namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableMedicamentModif2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicaments", "IdSpecialite", c => c.Int(nullable: false));
            CreateIndex("dbo.Medicaments", "IdSpecialite");
            AddForeignKey("dbo.Medicaments", "IdSpecialite", "dbo.Specialites", "IdSpecialite", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicaments", "IdSpecialite", "dbo.Specialites");
            DropIndex("dbo.Medicaments", new[] { "IdSpecialite" });
            DropColumn("dbo.Medicaments", "IdSpecialite");
        }
    }
}
