namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductPurchases", "PurchaseProd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductPurchases", "PurchaseProd", c => c.String());
        }
    }
}
