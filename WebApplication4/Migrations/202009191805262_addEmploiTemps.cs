namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmploiTemps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmploiTempsMedecins",
                c => new
                    {
                        idEmploi = c.Int(nullable: false, identity: true),
                        Jour1 = c.String(),
                        Jour2 = c.String(),
                        idDoctors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idEmploi)
                .ForeignKey("dbo.MedecinConventionnes", t => t.idDoctors, cascadeDelete: true)
                .Index(t => t.idDoctors);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmploiTempsMedecins", "idDoctors", "dbo.MedecinConventionnes");
            DropIndex("dbo.EmploiTempsMedecins", new[] { "idDoctors" });
            DropTable("dbo.EmploiTempsMedecins");
        }
    }
}
