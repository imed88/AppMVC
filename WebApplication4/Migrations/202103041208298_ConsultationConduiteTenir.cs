namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultationConduiteTenir : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "ConduiteTenir", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consultations", "ConduiteTenir");
        }
    }
}
