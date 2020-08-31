namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConsultationOrdonnances", "idPatients", c => c.Int(nullable: false));
            CreateIndex("dbo.ConsultationOrdonnances", "idPatients");
            AddForeignKey("dbo.ConsultationOrdonnances", "idPatients", "dbo.Patients", "IdPatients", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsultationOrdonnances", "idPatients", "dbo.Patients");
            DropIndex("dbo.ConsultationOrdonnances", new[] { "idPatients" });
            DropColumn("dbo.ConsultationOrdonnances", "idPatients");
        }
    }
}
