namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "DOB", c => c.DateTime());
        }
    }
}
