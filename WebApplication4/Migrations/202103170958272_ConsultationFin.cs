namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultationFin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "ExplorRadioComment", c => c.String());
            AddColumn("dbo.Consultations", "ExplorBioComment", c => c.String());
            AddColumn("dbo.Consultations", "TransfertComment", c => c.String());
            AddColumn("dbo.Consultations", "HospitalComment", c => c.String());
            DropColumn("dbo.Consultations", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Consultations", "Comment", c => c.String(nullable: false));
            DropColumn("dbo.Consultations", "HospitalComment");
            DropColumn("dbo.Consultations", "TransfertComment");
            DropColumn("dbo.Consultations", "ExplorBioComment");
            DropColumn("dbo.Consultations", "ExplorRadioComment");
        }
    }
}
