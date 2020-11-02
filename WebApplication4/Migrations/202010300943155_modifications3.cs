namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_invoice", "IdPatients", c => c.Int());
            CreateIndex("dbo.tbl_invoice", "IdPatients");
            AddForeignKey("dbo.tbl_invoice", "IdPatients", "dbo.Patients", "IdPatients");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_invoice", "IdPatients", "dbo.Patients");
            DropIndex("dbo.tbl_invoice", new[] { "IdPatients" });
            DropColumn("dbo.tbl_invoice", "IdPatients");
        }
    }
}
