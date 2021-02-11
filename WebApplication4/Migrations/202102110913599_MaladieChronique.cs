namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaladieChronique : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "MaladieChronique", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "MaladieChronique");
        }
    }
}
