namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LieuTravailModification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LieuTravails",
                c => new
                    {
                        LieuTravailId = c.Int(nullable: false, identity: true),
                        NomLieuTravail = c.String(),
                        IdUsine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LieuTravailId)
                .ForeignKey("dbo.Usines", t => t.IdUsine, cascadeDelete: true)
                .Index(t => t.IdUsine);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LieuTravails", "IdUsine", "dbo.Usines");
            DropIndex("dbo.LieuTravails", new[] { "IdUsine" });
            DropTable("dbo.LieuTravails");
        }
    }
}
