namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConsultationTraitement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "traitement", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consultations", "traitement");
        }
    }
}
