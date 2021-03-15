namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultationOrder1 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ConsultDetailID)
                .ForeignKey("dbo.Consultations", t => t.ConsultationID, cascadeDelete: true)
                .Index(t => t.ConsultationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsultationDetails", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.ConsultationDetails", new[] { "ConsultationID" });
            DropTable("dbo.ConsultationDetails");
        }
    }
}
