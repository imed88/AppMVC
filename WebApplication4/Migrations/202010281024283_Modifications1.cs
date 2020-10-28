namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifications1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_order", "IdPatients", "dbo.Patients");
            DropForeignKey("dbo.tbl_invoice", "IdPatients", "dbo.Patients");
            DropIndex("dbo.tbl_order", new[] { "IdPatients" });
            DropIndex("dbo.tbl_invoice", new[] { "IdPatients" });
            CreateIndex("dbo.tbl_invoice", "ConsultationID");
            AddForeignKey("dbo.tbl_invoice", "ConsultationID", "dbo.Consultations", "ConsultationID");
            DropColumn("dbo.tbl_order", "IdPatients");
            DropColumn("dbo.tbl_invoice", "IdPatients");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_invoice", "IdPatients", c => c.Int());
            AddColumn("dbo.tbl_order", "IdPatients", c => c.Int());
            DropForeignKey("dbo.tbl_invoice", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.tbl_invoice", new[] { "ConsultationID" });
            CreateIndex("dbo.tbl_invoice", "IdPatients");
            CreateIndex("dbo.tbl_order", "IdPatients");
            AddForeignKey("dbo.tbl_invoice", "IdPatients", "dbo.Patients", "IdPatients");
            AddForeignKey("dbo.tbl_order", "IdPatients", "dbo.Patients", "IdPatients");
        }
    }
}
