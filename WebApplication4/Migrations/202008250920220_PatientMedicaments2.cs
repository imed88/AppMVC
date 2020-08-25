namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientMedicaments2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatimedViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CheckBoxItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                        PatimedViewModel_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatimedViewModels", t => t.PatimedViewModel_id)
                .Index(t => t.PatimedViewModel_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckBoxItems", "PatimedViewModel_id", "dbo.PatimedViewModels");
            DropIndex("dbo.CheckBoxItems", new[] { "PatimedViewModel_id" });
            DropTable("dbo.CheckBoxItems");
            DropTable("dbo.PatimedViewModels");
        }
    }
}
