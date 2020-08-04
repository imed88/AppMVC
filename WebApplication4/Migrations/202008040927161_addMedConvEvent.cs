namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedConvEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "idDoctors", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "idDoctors");
            AddForeignKey("dbo.Events", "idDoctors", "dbo.MedecinConventionnes", "idDoctors", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "idDoctors", "dbo.MedecinConventionnes");
            DropIndex("dbo.Events", new[] { "idDoctors" });
            DropColumn("dbo.Events", "idDoctors");
        }
    }
}
