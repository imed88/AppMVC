namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifOrderDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Comments", c => c.String());
            DropColumn("dbo.OrderDetails", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Comment", c => c.String());
            DropColumn("dbo.OrderDetails", "Comments");
        }
    }
}
