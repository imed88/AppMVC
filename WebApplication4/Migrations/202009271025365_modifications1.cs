namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_product", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_product", "Quantity");
        }
    }
}
