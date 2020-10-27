namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "MedID", "dbo.Medicaments");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "IdPatients", "dbo.Patients");
            DropForeignKey("dbo.Carts", "MedID", "dbo.Medicaments");
            DropForeignKey("dbo.Carts", "ShoppingCartViewModel_ShoppingCartID", "dbo.ShoppingCartViewModels");
            DropIndex("dbo.Orders", new[] { "IdPatients" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "MedID" });
            DropIndex("dbo.Carts", new[] { "MedID" });
            DropIndex("dbo.Carts", new[] { "ShoppingCartViewModel_ShoppingCartID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Carts");
            DropTable("dbo.ShoppingCartViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingCartViewModels",
                c => new
                    {
                        ShoppingCartID = c.Int(nullable: false, identity: true),
                        CartTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ShoppingCartID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        MedID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ShoppingCartViewModel_ShoppingCartID = c.Int(),
                    })
                .PrimaryKey(t => t.RecordId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        MedID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        IdPatients = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateIndex("dbo.Carts", "ShoppingCartViewModel_ShoppingCartID");
            CreateIndex("dbo.Carts", "MedID");
            CreateIndex("dbo.OrderDetails", "MedID");
            CreateIndex("dbo.OrderDetails", "OrderId");
            CreateIndex("dbo.Orders", "IdPatients");
            AddForeignKey("dbo.Carts", "ShoppingCartViewModel_ShoppingCartID", "dbo.ShoppingCartViewModels", "ShoppingCartID");
            AddForeignKey("dbo.Carts", "MedID", "dbo.Medicaments", "MedID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "IdPatients", "dbo.Patients", "IdPatients", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "MedID", "dbo.Medicaments", "MedID", cascadeDelete: true);
        }
    }
}
