namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderModif : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "OrderName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderName", c => c.String());
        }
    }
}
