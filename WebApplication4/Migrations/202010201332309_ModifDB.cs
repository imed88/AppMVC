namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "medicament_MedID", "dbo.Medicaments");
            DropIndex("dbo.OrderDetails", new[] { "medicament_MedID" });
            RenameColumn(table: "dbo.OrderDetails", name: "medicament_MedID", newName: "MedID");
            AddColumn("dbo.Medicaments", "quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "MedID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "MedID");
            AddForeignKey("dbo.OrderDetails", "MedID", "dbo.Medicaments", "MedID", cascadeDelete: true);
            DropColumn("dbo.OrderDetails", "AlbumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "AlbumId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetails", "MedID", "dbo.Medicaments");
            DropIndex("dbo.OrderDetails", new[] { "MedID" });
            AlterColumn("dbo.OrderDetails", "MedID", c => c.Int());
            DropColumn("dbo.Medicaments", "quantity");
            RenameColumn(table: "dbo.OrderDetails", name: "MedID", newName: "medicament_MedID");
            CreateIndex("dbo.OrderDetails", "medicament_MedID");
            AddForeignKey("dbo.OrderDetails", "medicament_MedID", "dbo.Medicaments", "MedID");
        }
    }
}
