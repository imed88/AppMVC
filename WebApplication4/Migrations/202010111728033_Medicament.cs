namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Medicament : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        MedId = c.Int(nullable: false, identity: true),
                        PID = c.Int(nullable: false),
                        PName = c.String(nullable: false),
                        UnitsInStock = c.Int(nullable: false),
                        IdSpecialite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedId)
                .ForeignKey("dbo.Specialites", t => t.IdSpecialite, cascadeDelete: true)
                .Index(t => t.IdSpecialite);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicaments", "IdSpecialite", "dbo.Specialites");
            DropIndex("dbo.Medicaments", new[] { "IdSpecialite" });
            DropTable("dbo.Medicaments");
        }
    }
}
