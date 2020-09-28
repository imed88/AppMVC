namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifications3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_invoice", "in_totalbill", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_invoice", "in_totalbill", c => c.Double());
        }
    }
}
