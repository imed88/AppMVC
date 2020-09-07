namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modfis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EditProfileViewModels",
                c => new
                    {
                        IdProfile = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CurrentPassword = c.String(nullable: false, maxLength: 100),
                        NewPassword = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.IdProfile);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EditProfileViewModels");
        }
    }
}
