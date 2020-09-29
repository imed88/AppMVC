namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductPurchases", "pro_id", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductPurchases", "pro_id");
            AddForeignKey("dbo.ProductPurchases", "pro_id", "dbo.tbl_product", "pro_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPurchases", "pro_id", "dbo.tbl_product");
            DropIndex("dbo.ProductPurchases", new[] { "pro_id" });
            DropColumn("dbo.ProductPurchases", "pro_id");
        }
    }
}
