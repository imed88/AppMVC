namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifOrderDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Comment");
        }
    }
}
