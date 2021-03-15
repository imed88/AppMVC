namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifConsultation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "Comment", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consultations", "Comment");
        }
    }
}
