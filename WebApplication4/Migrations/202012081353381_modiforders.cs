namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modiforders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Patients_IdPatients", "dbo.Patients");
            DropIndex("dbo.Orders", new[] { "Patients_IdPatients" });
            DropColumn("dbo.Orders", "Patients_IdPatients");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Patients_IdPatients", c => c.Int());
            CreateIndex("dbo.Orders", "Patients_IdPatients");
            AddForeignKey("dbo.Orders", "Patients_IdPatients", "dbo.Patients", "IdPatients");
        }
    }
}
