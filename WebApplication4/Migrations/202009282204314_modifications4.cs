namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ordonnances", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.Ordonnances", new[] { "ConsultationID" });
            DropTable("dbo.Ordonnances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ordonnances",
                c => new
                    {
                        ConsultOrdID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        ConsultationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultOrdID);
            
            CreateIndex("dbo.Ordonnances", "ConsultationID");
            AddForeignKey("dbo.Ordonnances", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
        }
    }
}
