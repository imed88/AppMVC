namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifis4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.OrderDetails", new[] { "ConsultationID" });
            RenameColumn(table: "dbo.OrderDetails", name: "ConsultationID", newName: "Consultation_ConsultationID");
            AddColumn("dbo.Orders", "MatriculePatients", c => c.String());
            AddColumn("dbo.Orders", "ConsultationID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "Consultation_ConsultationID", c => c.Int());
            CreateIndex("dbo.OrderDetails", "Consultation_ConsultationID");
            CreateIndex("dbo.Orders", "ConsultationID");
            AddForeignKey("dbo.Orders", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "Consultation_ConsultationID", "dbo.Consultations", "ConsultationID");
            DropColumn("dbo.OrderDetails", "MatriculePatients");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "MatriculePatients", c => c.String());
            DropForeignKey("dbo.OrderDetails", "Consultation_ConsultationID", "dbo.Consultations");
            DropForeignKey("dbo.Orders", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.Orders", new[] { "ConsultationID" });
            DropIndex("dbo.OrderDetails", new[] { "Consultation_ConsultationID" });
            AlterColumn("dbo.OrderDetails", "Consultation_ConsultationID", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "ConsultationID");
            DropColumn("dbo.Orders", "MatriculePatients");
            RenameColumn(table: "dbo.OrderDetails", name: "Consultation_ConsultationID", newName: "ConsultationID");
            CreateIndex("dbo.OrderDetails", "ConsultationID");
            AddForeignKey("dbo.OrderDetails", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
        }
    }
}
