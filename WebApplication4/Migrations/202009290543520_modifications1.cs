namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductPurchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        PurchaseProd = c.String(),
                        PurchaseQuantity = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductPurchases");
        }
    }
}
