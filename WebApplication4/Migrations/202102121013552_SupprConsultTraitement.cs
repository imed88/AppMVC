namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupprConsultTraitement : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Consultations", "traitement");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Consultations", "traitement", c => c.String());
        }
    }
}
