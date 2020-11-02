namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.carts", "ConsultationID", "dbo.Consultations");
            DropForeignKey("dbo.carts", "IdPatients", "dbo.Patients");
            DropForeignKey("dbo.tbl_order", "IdPatients", "dbo.Patients");
            DropForeignKey("dbo.tbl_invoice", "IdPatients", "dbo.Patients");
            DropForeignKey("dbo.tbl_product", "cart_CartID", "dbo.carts");
            DropIndex("dbo.carts", new[] { "ConsultationID" });
            DropIndex("dbo.carts", new[] { "IdPatients" });
            DropIndex("dbo.tbl_product", new[] { "cart_CartID" });
            DropIndex("dbo.tbl_order", new[] { "IdPatients" });
            DropIndex("dbo.tbl_invoice", new[] { "IdPatients" });
            DropColumn("dbo.tbl_product", "cart_CartID");
            DropColumn("dbo.tbl_order", "IdPatients");
            DropColumn("dbo.tbl_invoice", "IdPatients");
            DropTable("dbo.carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        productid = c.Int(nullable: false),
                        productname = c.String(),
                        price = c.Single(nullable: false),
                        qty = c.Int(nullable: false),
                        bill = c.Single(nullable: false),
                        ConsultationID = c.Int(nullable: false),
                        IdPatients = c.Int(),
                    })
                .PrimaryKey(t => t.CartID);
            
            AddColumn("dbo.tbl_invoice", "IdPatients", c => c.Int());
            AddColumn("dbo.tbl_order", "IdPatients", c => c.Int());
            AddColumn("dbo.tbl_product", "cart_CartID", c => c.Int());
            CreateIndex("dbo.tbl_invoice", "IdPatients");
            CreateIndex("dbo.tbl_order", "IdPatients");
            CreateIndex("dbo.tbl_product", "cart_CartID");
            CreateIndex("dbo.carts", "IdPatients");
            CreateIndex("dbo.carts", "ConsultationID");
            AddForeignKey("dbo.tbl_product", "cart_CartID", "dbo.carts", "CartID");
            AddForeignKey("dbo.tbl_invoice", "IdPatients", "dbo.Patients", "IdPatients");
            AddForeignKey("dbo.tbl_order", "IdPatients", "dbo.Patients", "IdPatients");
            AddForeignKey("dbo.carts", "IdPatients", "dbo.Patients", "IdPatients");
            AddForeignKey("dbo.carts", "ConsultationID", "dbo.Consultations", "ConsultationID", cascadeDelete: true);
        }
    }
}
