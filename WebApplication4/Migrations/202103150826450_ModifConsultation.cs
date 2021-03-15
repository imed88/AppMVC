namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifConsultation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "PrescMed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Consultations", "ExplorRadio", c => c.Boolean(nullable: false));
            AddColumn("dbo.Consultations", "ExplorBio", c => c.Boolean(nullable: false));
            AddColumn("dbo.Consultations", "Transfert", c => c.Boolean(nullable: false));
            AddColumn("dbo.Consultations", "Hospitalisation", c => c.Boolean(nullable: false));
            DropColumn("dbo.Consultations", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Consultations", "Comment", c => c.String(nullable: false));
            DropColumn("dbo.Consultations", "Hospitalisation");
            DropColumn("dbo.Consultations", "Transfert");
            DropColumn("dbo.Consultations", "ExplorBio");
            DropColumn("dbo.Consultations", "ExplorRadio");
            DropColumn("dbo.Consultations", "PrescMed");
        }
    }
}
