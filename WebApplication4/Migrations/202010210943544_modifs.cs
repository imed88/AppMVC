namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartViewModels",
                c => new
                    {
                        ShoppingCartID = c.Int(nullable: false, identity: true),
                        CartTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ShoppingCartID);
            
            AddColumn("dbo.Carts", "ShoppingCartViewModel_ShoppingCartID", c => c.Int());
            CreateIndex("dbo.Carts", "ShoppingCartViewModel_ShoppingCartID");
            AddForeignKey("dbo.Carts", "ShoppingCartViewModel_ShoppingCartID", "dbo.ShoppingCartViewModels", "ShoppingCartID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ShoppingCartViewModel_ShoppingCartID", "dbo.ShoppingCartViewModels");
            DropIndex("dbo.Carts", new[] { "ShoppingCartViewModel_ShoppingCartID" });
            DropColumn("dbo.Carts", "ShoppingCartViewModel_ShoppingCartID");
            DropTable("dbo.ShoppingCartViewModels");
        }
    }
}
