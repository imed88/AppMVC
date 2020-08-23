namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConsultationmodif2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consultations", "DateCreated");
        }
    }
}
