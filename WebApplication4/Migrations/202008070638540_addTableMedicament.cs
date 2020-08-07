namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableMedicament : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        MedicamentID = c.Int(nullable: false, identity: true),
                        MedicamentName = c.String(),
                        MedicamentStock = c.Int(nullable: false),
                        IsSelected = c.Boolean(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MedicamentID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicaments", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Medicaments", new[] { "UserID" });
            DropTable("dbo.Medicaments");
        }
    }
}
