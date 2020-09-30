namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_order", "ConsultationID", c => c.Int());
            CreateIndex("dbo.tbl_order", "ConsultationID");
            AddForeignKey("dbo.tbl_order", "ConsultationID", "dbo.Consultations", "ConsultationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_order", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.tbl_order", new[] { "ConsultationID" });
            DropColumn("dbo.tbl_order", "ConsultationID");
        }
    }
}
