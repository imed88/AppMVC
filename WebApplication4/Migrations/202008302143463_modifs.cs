namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd", c => c.Int());
            CreateIndex("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd");
            AddForeignKey("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd", "dbo.ConsultationOrdonnances", "IDConsultOrd");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd", "dbo.ConsultationOrdonnances");
            DropIndex("dbo.Patients", new[] { "ConsultationOrdonnances_IDConsultOrd" });
            DropColumn("dbo.Patients", "ConsultationOrdonnances_IDConsultOrd");
        }
    }
}
