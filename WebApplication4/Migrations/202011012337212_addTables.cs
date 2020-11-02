namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductPurchases", "pro_id", "dbo.tbl_product");
            DropForeignKey("dbo.tbl_order", "ConsultationID", "dbo.Consultations");
            DropForeignKey("dbo.tbl_invoice", "ConsultationID", "dbo.Consultations");
            DropForeignKey("dbo.tbl_order", "tbl_invoice_in_id", "dbo.tbl_invoice");
            DropForeignKey("dbo.tbl_order", "tbl_product_pro_id", "dbo.tbl_product");
            DropIndex("dbo.ProductPurchases", new[] { "pro_id" });
            DropIndex("dbo.tbl_order", new[] { "ConsultationID" });
            DropIndex("dbo.tbl_order", new[] { "tbl_invoice_in_id" });
            DropIndex("dbo.tbl_order", new[] { "tbl_product_pro_id" });
            DropIndex("dbo.tbl_invoice", new[] { "ConsultationID" });
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        IdPaitents = c.Int(nullable: false),
                        CartStatusId = c.Int(nullable: false),
                        Patients_IdPatients = c.Int(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.CartStatus", t => t.CartStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patients_IdPatients)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CartStatusId)
                .Index(t => t.Patients_IdPatients);
            
            CreateTable(
                "dbo.CartStatus",
                c => new
                    {
                        CartStatusId = c.Int(nullable: false, identity: true),
                        CartStatusName = c.String(),
                    })
                .PrimaryKey(t => t.CartStatusId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        IdSpecialite = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Description = c.DateTime(nullable: false),
                        ProductImage = c.String(),
                        IsFeatured = c.Boolean(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Specialites", t => t.IdSpecialite, cascadeDelete: true)
                .Index(t => t.IdSpecialite);
            
            CreateTable(
                "dbo.Ordonnances",
                c => new
                    {
                        OrdonnancesId = c.Int(nullable: false, identity: true),
                        IdPaitents = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Patients_IdPatients = c.Int(),
                    })
                .PrimaryKey(t => t.OrdonnancesId)
                .ForeignKey("dbo.Patients", t => t.Patients_IdPatients)
                .Index(t => t.Patients_IdPatients);
            
            DropTable("dbo.ProductPurchases");
            DropTable("dbo.tbl_product");
            DropTable("dbo.tbl_order");
            DropTable("dbo.tbl_invoice");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tbl_invoice",
                c => new
                    {
                        in_id = c.Int(nullable: false, identity: true),
                        ConsultationID = c.Int(),
                        in_date = c.DateTime(),
                        in_totalbill = c.Double(),
                    })
                .PrimaryKey(t => t.in_id);
            
            CreateTable(
                "dbo.tbl_order",
                c => new
                    {
                        o_id = c.Int(nullable: false, identity: true),
                        o_fk_pro = c.Int(),
                        o_fk_invoice = c.Int(),
                        o_date = c.DateTime(),
                        o_qty = c.Int(),
                        o_bill = c.Double(),
                        o_unitprice = c.Int(),
                        ConsultationID = c.Int(),
                        tbl_invoice_in_id = c.Int(),
                        tbl_product_pro_id = c.Int(),
                    })
                .PrimaryKey(t => t.o_id);
            
            CreateTable(
                "dbo.tbl_product",
                c => new
                    {
                        pro_id = c.Int(nullable: false, identity: true),
                        pro_name = c.String(),
                        Quantity = c.Int(),
                        pro_desc = c.String(),
                        pro_image = c.String(),
                    })
                .PrimaryKey(t => t.pro_id);
            
            CreateTable(
                "dbo.ProductPurchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        PurchaseQuantity = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        pro_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID);
            
            DropForeignKey("dbo.Ordonnances", "Patients_IdPatients", "dbo.Patients");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "IdSpecialite", "dbo.Specialites");
            DropForeignKey("dbo.Carts", "Patients_IdPatients", "dbo.Patients");
            DropForeignKey("dbo.Carts", "CartStatusId", "dbo.CartStatus");
            DropIndex("dbo.Ordonnances", new[] { "Patients_IdPatients" });
            DropIndex("dbo.Products", new[] { "IdSpecialite" });
            DropIndex("dbo.Carts", new[] { "Patients_IdPatients" });
            DropIndex("dbo.Carts", new[] { "CartStatusId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropTable("dbo.Ordonnances");
            DropTable("dbo.Products");
            DropTable("dbo.CartStatus");
            DropTable("dbo.Carts");
            CreateIndex("dbo.tbl_invoice", "ConsultationID");
            CreateIndex("dbo.tbl_order", "tbl_product_pro_id");
            CreateIndex("dbo.tbl_order", "tbl_invoice_in_id");
            CreateIndex("dbo.tbl_order", "ConsultationID");
            CreateIndex("dbo.ProductPurchases", "pro_id");
            AddForeignKey("dbo.tbl_order", "tbl_product_pro_id", "dbo.tbl_product", "pro_id");
            AddForeignKey("dbo.tbl_order", "tbl_invoice_in_id", "dbo.tbl_invoice", "in_id");
            AddForeignKey("dbo.tbl_invoice", "ConsultationID", "dbo.Consultations", "ConsultationID");
            AddForeignKey("dbo.tbl_order", "ConsultationID", "dbo.Consultations", "ConsultationID");
            AddForeignKey("dbo.ProductPurchases", "pro_id", "dbo.tbl_product", "pro_id", cascadeDelete: true);
        }
    }
}
