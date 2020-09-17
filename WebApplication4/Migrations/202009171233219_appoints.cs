namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appoints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointementModels", "Specialite_IdSpecialite", c => c.Int());
            CreateIndex("dbo.AppointementModels", "Specialite_IdSpecialite");
            AddForeignKey("dbo.AppointementModels", "Specialite_IdSpecialite", "dbo.Specialites", "IdSpecialite");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointementModels", "Specialite_IdSpecialite", "dbo.Specialites");
            DropIndex("dbo.AppointementModels", new[] { "Specialite_IdSpecialite" });
            DropColumn("dbo.AppointementModels", "Specialite_IdSpecialite");
        }
    }
}
