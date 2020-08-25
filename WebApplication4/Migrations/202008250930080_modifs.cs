namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckBoxItems", "PatimedViewModel_id", "dbo.PatimedViewModels");
            DropIndex("dbo.CheckBoxItems", new[] { "PatimedViewModel_id" });
            DropTable("dbo.PatimedViewModels");
            DropTable("dbo.CheckBoxItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CheckBoxItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                        PatimedViewModel_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatimedViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.CheckBoxItems", "PatimedViewModel_id");
            AddForeignKey("dbo.CheckBoxItems", "PatimedViewModel_id", "dbo.PatimedViewModels", "id");
        }
    }
}
