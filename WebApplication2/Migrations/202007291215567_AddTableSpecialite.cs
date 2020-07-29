namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableSpecialite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialites",
                c => new
                    {
                        IdSpecialite = c.Int(nullable: false, identity: true),
                        SpecialiteName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdSpecialite);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Specialites");
        }
    }
}
