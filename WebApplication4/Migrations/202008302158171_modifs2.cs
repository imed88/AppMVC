namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsultationOrdonnances", "ConsultationID", "dbo.Consultations");
            DropForeignKey("dbo.ConsultationOrdonnances", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd", "dbo.ConsultationOrdonnances");
            DropIndex("dbo.Patients", new[] { "ConsultationOrdonnances_IDConsultOrd" });
            DropIndex("dbo.ConsultationOrdonnances", new[] { "ConsultationID" });
            DropIndex("dbo.ConsultationOrdonnances", new[] { "UserID" });
            DropColumn("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd");
            DropTable("dbo.ConsultationOrdonnances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ConsultationOrdonnances",
                c => new
                    {
                        IDConsultOrd = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        ConsultationID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDConsultOrd);
            
            AddColumn("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd", c => c.Int());
            CreateIndex("dbo.ConsultationOrdonnances", "UserID");
            CreateIndex("dbo.ConsultationOrdonnances", "ConsultationID");
            CreateIndex("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd");
            AddForeignKey("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd", "dbo.ConsultationOrdonnances", "IDConsultOrd");
            AddForeignKey("dbo.ConsultationOrdonnances", "UserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ConsultationOrdonnances", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
        }
    }
}
