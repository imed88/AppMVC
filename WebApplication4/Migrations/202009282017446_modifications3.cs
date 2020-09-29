namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_invoice", "ConsultationID", c => c.Int());
            AlterColumn("dbo.tbl_invoice", "in_totalbill", c => c.Double());
            CreateIndex("dbo.tbl_invoice", "ConsultationID");
            AddForeignKey("dbo.tbl_invoice", "ConsultationID", "dbo.Consultations", "ConsultationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_invoice", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.tbl_invoice", new[] { "ConsultationID" });
            AlterColumn("dbo.tbl_invoice", "in_totalbill", c => c.Int());
            DropColumn("dbo.tbl_invoice", "ConsultationID");
        }
    }
}
