namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dobparente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Patients", "Parente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Parente");
            DropColumn("dbo.Patients", "DOB");
        }
    }
}
