namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultationOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsultationDetails", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.ConsultationDetails", new[] { "ConsultationID" });
            CreateTable(
                "dbo.RadioBios",
                c => new
                    {
                        RadioBioID = c.Int(nullable: false, identity: true),
                        ConsultationID = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.RadioBioID)
                .ForeignKey("dbo.Consultations", t => t.ConsultationID, cascadeDelete: true)
                .Index(t => t.ConsultationID);
            
            AddColumn("dbo.Consultations", "Comment", c => c.String(nullable: false));
            AddColumn("dbo.Consultations", "CNAM", c => c.String(nullable: false));
            DropTable("dbo.ConsultationDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ConsultationDetails",
                c => new
                    {
                        ConsultDetailID = c.Int(nullable: false, identity: true),
                        ConsultationID = c.Int(nullable: false),
                        Comment = c.String(),
                        CNAM = c.String(),
                    })
                .PrimaryKey(t => t.ConsultDetailID);
            
            DropForeignKey("dbo.RadioBios", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.RadioBios", new[] { "ConsultationID" });
            DropColumn("dbo.Consultations", "CNAM");
            DropColumn("dbo.Consultations", "Comment");
            DropTable("dbo.RadioBios");
            CreateIndex("dbo.ConsultationDetails", "ConsultationID");
            AddForeignKey("dbo.ConsultationDetails", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
        }
    }
}
