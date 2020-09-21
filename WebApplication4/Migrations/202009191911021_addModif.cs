namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModif : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedecinEmploiTempsViewModels",
                c => new
                    {
                        MedEmploi = c.Int(nullable: false, identity: true),
                        idDoctors = c.Int(nullable: false),
                        idEmploi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedEmploi);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MedecinEmploiTempsViewModels");
        }
    }
}
