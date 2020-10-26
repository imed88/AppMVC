namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FileDetails", "Medicaments_MedID", "dbo.Medicaments");
            DropIndex("dbo.FileDetails", new[] { "Medicaments_MedID" });
            CreateTable(
                "dbo.MedImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        MedID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicaments", t => t.MedID, cascadeDelete: true)
                .Index(t => t.MedID);
            
            DropColumn("dbo.FileDetails", "Medicaments_MedID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileDetails", "Medicaments_MedID", c => c.Int());
            DropForeignKey("dbo.MedImages", "MedID", "dbo.Medicaments");
            DropIndex("dbo.MedImages", new[] { "MedID" });
            DropTable("dbo.MedImages");
            CreateIndex("dbo.FileDetails", "Medicaments_MedID");
            AddForeignKey("dbo.FileDetails", "Medicaments_MedID", "dbo.Medicaments", "MedID");
        }
    }
}
