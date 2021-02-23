namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IdPatients", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "IdPatients");
            AddForeignKey("dbo.Events", "IdPatients", "dbo.Patients", "IdPatients", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "IdPatients", "dbo.Patients");
            DropIndex("dbo.Events", new[] { "IdPatients" });
            DropColumn("dbo.Events", "IdPatients");
        }
    }
}
