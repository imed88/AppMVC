namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RadioBios", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.RadioBios", new[] { "ConsultationID" });
            DropTable("dbo.RadioBios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RadioBios",
                c => new
                    {
                        RadioBioID = c.Int(nullable: false, identity: true),
                        ConsultationID = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.RadioBioID);
            
            CreateIndex("dbo.RadioBios", "ConsultationID");
            AddForeignKey("dbo.RadioBios", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
        }
    }
}
