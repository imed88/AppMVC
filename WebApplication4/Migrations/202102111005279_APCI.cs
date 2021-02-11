namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class APCI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "APCI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "APCI");
        }
    }
}
