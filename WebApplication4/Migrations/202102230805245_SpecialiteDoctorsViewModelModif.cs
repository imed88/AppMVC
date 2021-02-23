namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecialiteDoctorsViewModelModif : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialiteMedecinViewModels",
                c => new
                    {
                        IdSpecialite = c.Int(nullable: false, identity: true),
                        idDoctors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSpecialite);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpecialiteMedecinViewModels");
        }
    }
}
