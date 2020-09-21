namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModif2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmploiTempsMedecins", "idDoctors", "dbo.MedecinConventionnes");
            DropIndex("dbo.EmploiTempsMedecins", new[] { "idDoctors" });
            DropColumn("dbo.AppointementModels", "JourHeureTravail1");
            DropColumn("dbo.AppointementModels", "JourHeureTravail2");
            DropColumn("dbo.MedecinConventionnes", "JourHeureTravail1");
            DropColumn("dbo.MedecinConventionnes", "JourHeureTravail2");
            DropTable("dbo.EmploiTempsMedecins");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.idEmploi);
            
            AddColumn("dbo.MedecinConventionnes", "JourHeureTravail2", c => c.String());
            AddColumn("dbo.MedecinConventionnes", "JourHeureTravail1", c => c.String());
            AddColumn("dbo.AppointementModels", "JourHeureTravail2", c => c.String(nullable: false));
            AddColumn("dbo.AppointementModels", "JourHeureTravail1", c => c.String(nullable: false));
            CreateIndex("dbo.EmploiTempsMedecins", "idDoctors");
            AddForeignKey("dbo.EmploiTempsMedecins", "idDoctors", "dbo.MedecinConventionnes", "idDoctors", cascadeDelete: true);
        }
    }
}
