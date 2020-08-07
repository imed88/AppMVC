namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableHistMedicmament1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicamentSelections", "MedicamentID", "dbo.Medicaments");
            DropIndex("dbo.MedicamentSelections", new[] { "MedicamentID" });
            AddColumn("dbo.Medicaments", "isSelected", c => c.Boolean(nullable: false));
            DropTable("dbo.MedicamentSelections");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MedicamentSelections",
                c => new
                    {
                        IdSelection = c.Int(nullable: false, identity: true),
                        MedicamentID = c.Int(nullable: false),
                        isSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdSelection);
            
            DropColumn("dbo.Medicaments", "isSelected");
            CreateIndex("dbo.MedicamentSelections", "MedicamentID");
            AddForeignKey("dbo.MedicamentSelections", "MedicamentID", "dbo.Medicaments", "MedicamentID", cascadeDelete: true);
        }
    }
}
