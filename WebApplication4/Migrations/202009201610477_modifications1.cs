namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AppointementModels", "DtEdit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppointementModels", "DtEdit", c => c.DateTime());
        }
    }
}
