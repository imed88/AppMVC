namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Usines",
               c => new
               {
                   IdUsine = c.Int(nullable: false, identity: true),
                   UsineName = c.String(nullable: false),
               })
               .PrimaryKey(t => t.IdUsine);
        }
        
        public override void Down()
        {
            DropTable("dbo.Usines");
        }
    }
}
