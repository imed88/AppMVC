namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class essai1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "idDoctors", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "idDoctors");
            AddForeignKey("dbo.Events", "idDoctors", "dbo.MedecinConventionnes", "idDoctors", cascadeDelete: true);
            DropColumn("dbo.Events", "Subjects");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Subjects", c => c.String());
            DropForeignKey("dbo.Events", "idDoctors", "dbo.MedecinConventionnes");
            DropIndex("dbo.Events", new[] { "idDoctors" });
            DropColumn("dbo.Events", "idDoctors");
        }
    }
}
