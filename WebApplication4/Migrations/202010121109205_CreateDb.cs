namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointementModels",
                c => new
                    {
                        AppointmentID = c.Int(nullable: false, identity: true),
                        idDoctors = c.Int(nullable: false),
                        DtEdit = c.DateTime(nullable: false),
                        idPatients = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentID)
                .ForeignKey("dbo.MedecinConventionnes", t => t.idDoctors, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.idPatients, cascadeDelete: true)
                .Index(t => t.idDoctors)
                .Index(t => t.idPatients);
            
            CreateTable(
                "dbo.MedecinConventionnes",
                c => new
                    {
                        idDoctors = c.Int(nullable: false, identity: true),
                        nameDoctors = c.String(),
                        emailDoctors = c.String(),
                        phoneDoctors = c.String(),
                        idSpecialite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDoctors)
                .ForeignKey("dbo.Specialites", t => t.idSpecialite, cascadeDelete: true)
                .Index(t => t.idSpecialite);
            
            CreateTable(
                "dbo.Specialites",
                c => new
                    {
                        IdSpecialite = c.Int(nullable: false, identity: true),
                        SpecialiteName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdSpecialite);
            
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        MedID = c.Int(nullable: false, identity: true),
                        PID = c.Int(nullable: false),
                        PName = c.String(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitsInStock = c.Int(nullable: false),
                        idSpecialite = c.String(nullable: false),
                        Specialites_IdSpecialite = c.Int(),
                    })
                .PrimaryKey(t => t.MedID)
                .ForeignKey("dbo.Specialites", t => t.Specialites_IdSpecialite)
                .Index(t => t.Specialites_IdSpecialite);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        IdPatients = c.Int(nullable: false, identity: true),
                        MatriculePatients = c.String(),
                        NomPatient = c.String(),
                        PrenomPatient = c.String(),
                        Gender = c.String(),
                        PhonePatients = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Parente = c.String(),
                        IdUsine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPatients)
                .ForeignKey("dbo.Usines", t => t.IdUsine, cascadeDelete: true)
                .Index(t => t.IdUsine);
            
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ConsultationID = c.Int(nullable: false, identity: true),
                        diagnostic = c.String(),
                        traitement = c.String(),
                        UserID = c.String(maxLength: 128),
                        idPatients = c.Int(nullable: false),
                        natureVisite = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultationID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Patients", t => t.idPatients, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.idPatients);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserType = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        IdPatients = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.IdPatients, cascadeDelete: true)
                .Index(t => t.IdPatients);
            
            CreateTable(
                "dbo.MedicamentOrders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        idPatients = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Patients", t => t.idPatients, cascadeDelete: true)
                .Index(t => t.idPatients);
            
            CreateTable(
                "dbo.Order_Products",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        PID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        TotalSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_OrderID = c.Int(),
                        Product_MedID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.MedicamentOrders", t => t.Order_OrderID)
                .ForeignKey("dbo.Medicaments", t => t.Product_MedID)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Product_MedID);
            
            CreateTable(
                "dbo.Usines",
                c => new
                    {
                        IdUsine = c.Int(nullable: false, identity: true),
                        UsineName = c.String(),
                    })
                .PrimaryKey(t => t.IdUsine);
            
            CreateTable(
                "dbo.RDVs",
                c => new
                    {
                        ConsultRDVID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        ConsultationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultRDVID)
                .ForeignKey("dbo.Consultations", t => t.ConsultationID, cascadeDelete: true)
                .Index(t => t.ConsultationID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RDVs", "ConsultationID", "dbo.Consultations");
            DropForeignKey("dbo.Patients", "IdUsine", "dbo.Usines");
            DropForeignKey("dbo.MedicamentOrders", "idPatients", "dbo.Patients");
            DropForeignKey("dbo.Order_Products", "Product_MedID", "dbo.Medicaments");
            DropForeignKey("dbo.Order_Products", "Order_OrderID", "dbo.MedicamentOrders");
            DropForeignKey("dbo.FileDetails", "IdPatients", "dbo.Patients");
            DropForeignKey("dbo.Consultations", "idPatients", "dbo.Patients");
            DropForeignKey("dbo.Consultations", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppointementModels", "idPatients", "dbo.Patients");
            DropForeignKey("dbo.Medicaments", "Specialites_IdSpecialite", "dbo.Specialites");
            DropForeignKey("dbo.MedecinConventionnes", "idSpecialite", "dbo.Specialites");
            DropForeignKey("dbo.AppointementModels", "idDoctors", "dbo.MedecinConventionnes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RDVs", new[] { "ConsultationID" });
            DropIndex("dbo.Order_Products", new[] { "Product_MedID" });
            DropIndex("dbo.Order_Products", new[] { "Order_OrderID" });
            DropIndex("dbo.MedicamentOrders", new[] { "idPatients" });
            DropIndex("dbo.FileDetails", new[] { "IdPatients" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Consultations", new[] { "idPatients" });
            DropIndex("dbo.Consultations", new[] { "UserID" });
            DropIndex("dbo.Patients", new[] { "IdUsine" });
            DropIndex("dbo.Medicaments", new[] { "Specialites_IdSpecialite" });
            DropIndex("dbo.MedecinConventionnes", new[] { "idSpecialite" });
            DropIndex("dbo.AppointementModels", new[] { "idPatients" });
            DropIndex("dbo.AppointementModels", new[] { "idDoctors" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RDVs");
            DropTable("dbo.Usines");
            DropTable("dbo.Order_Products");
            DropTable("dbo.MedicamentOrders");
            DropTable("dbo.FileDetails");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Consultations");
            DropTable("dbo.Patients");
            DropTable("dbo.Medicaments");
            DropTable("dbo.Specialites");
            DropTable("dbo.MedecinConventionnes");
            DropTable("dbo.AppointementModels");
        }
    }
}
