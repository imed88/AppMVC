namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifis3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "MatriculePatients", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "MatriculePatients");
        }
    }
}
