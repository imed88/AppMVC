namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifRDV : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RDVs",
                c => new
                    {
                        ConsultRDVID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        ConsultationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultRDVID)
                .ForeignKey("dbo.Consultations", t => t.ConsultationID, cascadeDelete: true)
                .Index(t => t.ConsultationID);
            
            DropTable("dbo.EditProfileViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EditProfileViewModels",
                c => new
                    {
                        IdProfile = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CurrentPassword = c.String(nullable: false, maxLength: 100),
                        NewPassword = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.IdProfile);
            
            DropForeignKey("dbo.RDVs", "ConsultationID", "dbo.Consultations");
            DropIndex("dbo.RDVs", new[] { "ConsultationID" });
            DropTable("dbo.RDVs");
        }
    }
}
