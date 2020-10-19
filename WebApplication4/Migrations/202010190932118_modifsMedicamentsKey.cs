namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifsMedicamentsKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        MedID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ModeEmploi = c.String(),
                        idSpecialite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedID)
                .ForeignKey("dbo.Specialites", t => t.idSpecialite, cascadeDelete: true)
                .Index(t => t.idSpecialite);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicaments", "idSpecialite", "dbo.Specialites");
            DropIndex("dbo.Medicaments", new[] { "idSpecialite" });
            DropTable("dbo.Medicaments");
        }
    }
}
