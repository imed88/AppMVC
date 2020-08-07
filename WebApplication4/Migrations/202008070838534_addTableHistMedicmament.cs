namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableHistMedicmament : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicamentSelections",
                c => new
                    {
                        IdSelection = c.Int(nullable: false, identity: true),
                        MedicamentID = c.Int(nullable: false),
                        isSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdSelection)
                .ForeignKey("dbo.Medicaments", t => t.MedicamentID, cascadeDelete: true)
                .Index(t => t.MedicamentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicamentSelections", "MedicamentID", "dbo.Medicaments");
            DropIndex("dbo.MedicamentSelections", new[] { "MedicamentID" });
            DropTable("dbo.MedicamentSelections");
        }
    }
}
