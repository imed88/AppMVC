namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifsPath4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedImages", "MedID", "dbo.Medicaments");
            DropIndex("dbo.MedImages", new[] { "MedID" });
            AddColumn("dbo.Medicaments", "MedPic", c => c.String());
            DropTable("dbo.MedImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MedImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        ImgPath = c.String(),
                        MedID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Medicaments", "MedPic");
            CreateIndex("dbo.MedImages", "MedID");
            AddForeignKey("dbo.MedImages", "MedID", "dbo.Medicaments", "MedID", cascadeDelete: true);
        }
    }
}
