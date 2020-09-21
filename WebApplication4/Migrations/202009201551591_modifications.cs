namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointementModels", "DtEdit", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppointementModels", "DtEdit");
        }
    }
}
