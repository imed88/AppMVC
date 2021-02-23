namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecialiteDoctorsViewModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Events");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        ThemeColor = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
        }
    }
}
