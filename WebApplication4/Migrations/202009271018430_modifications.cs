namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tbl_product", "pro_price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_product", "pro_price", c => c.Double());
        }
    }
}
