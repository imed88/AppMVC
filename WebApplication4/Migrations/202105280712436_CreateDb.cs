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
                        dateTime = c.DateTime(nullable: false),
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
                        nameDoctors = c.String(nullable: false),
                        emailDoctors = c.String(nullable: false),
                        phoneDoctors = c.String(nullable: false),
                        JourTravail1 = c.String(nullable: false),
                        TimeTravail1 = c.DateTime(nullable: false),
                        JourTravail2 = c.String(nullable: false),
                        TimeTravail2 = c.DateTime(nullable: false),
                        idSpecialite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDoctors)
                .ForeignKey("dbo.Specialites", t => t.idSpecialite, cascadeDelete: true)
                .Index(t => t.idSpecialite);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        ThemeColor = c.String(nullable: false),
                        idDoctors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.MedecinConventionnes", t => t.idDoctors, cascadeDelete: true)
                .Index(t => t.idDoctors);
            
            CreateTable(
                "dbo.Specialites",
                c => new
                    {
                        IdSpecialite = c.Int(nullable: false, identity: true),
                        SpecialiteName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdSpecialite);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        IdPatients = c.Int(nullable: false, identity: true),
                        MatriculePatients = c.String(nullable: false),
                        NomPatient = c.String(nullable: false),
                        PrenomPatient = c.String(nullable: false),
                        Gender = c.String(),
                        PhonePatients = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Parente = c.String(),
                        MaladieChronique = c.String(),
                        APCI = c.String(),
                        CodeAPCI = c.String(),
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
                        diagnostic = c.String(nullable: false),
                        UserID = c.String(maxLength: 128),
                        Username = c.String(),
                        idPatients = c.Int(nullable: false),
                        natureVisite = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ConduiteTenir = c.String(nullable: false),
                        CNAM = c.String(nullable: false),
                        PrescMed = c.Boolean(nullable: false),
                        ExplorRadio = c.Boolean(nullable: false),
                        ExplorRadioComment = c.String(),
                        ExplorBio = c.Boolean(nullable: false),
                        ExplorBioComment = c.String(),
                        Transfert = c.Boolean(nullable: false),
                        TransfertComment = c.String(),
                        Hospitalisation = c.Boolean(nullable: false),
                        HospitalComment = c.String(),
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
                "dbo.ConsultationDetails",
                c => new
                    {
                        ConsultDetailID = c.Int(nullable: false, identity: true),
                        ConsultationID = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        CNAM = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultDetailID)
                .ForeignKey("dbo.Consultations", t => t.ConsultationID, cascadeDelete: true)
                .Index(t => t.ConsultationID);
            
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(nullable: false),
                        Extension = c.String(),
                        IdPatients = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.IdPatients, cascadeDelete: true)
                .Index(t => t.IdPatients);
            
            CreateTable(
                "dbo.Usines",
                c => new
                    {
                        IdUsine = c.Int(nullable: false, identity: true),
                        UsineName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsine);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        MatriculePatients = c.String(nullable: false),
                        ConsultationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Consultations", t => t.ConsultationID, cascadeDelete: true)
                .Index(t => t.ConsultationID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        NameProduct = c.String(nullable: false),
                        Categorie = c.String(nullable: false),
                        DenominationCI = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.RDVs",
                c => new
                    {
                        ConsultRDVID = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
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
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ConsultationID", "dbo.Consultations");
            DropForeignKey("dbo.Patients", "IdUsine", "dbo.Usines");
            DropForeignKey("dbo.FileDetails", "IdPatients", "dbo.Patients");
            DropForeignKey("dbo.Consultations", "idPatients", "dbo.Patients");
            DropForeignKey("dbo.ConsultationDetails", "ConsultationID", "dbo.Consultations");
            DropForeignKey("dbo.Consultations", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppointementModels", "idPatients", "dbo.Patients");
            DropForeignKey("dbo.MedecinConventionnes", "idSpecialite", "dbo.Specialites");
            DropForeignKey("dbo.Events", "idDoctors", "dbo.MedecinConventionnes");
            DropForeignKey("dbo.AppointementModels", "idDoctors", "dbo.MedecinConventionnes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RDVs", new[] { "ConsultationID" });
            DropIndex("dbo.Orders", new[] { "ConsultationID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.FileDetails", new[] { "IdPatients" });
            DropIndex("dbo.ConsultationDetails", new[] { "ConsultationID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Consultations", new[] { "idPatients" });
            DropIndex("dbo.Consultations", new[] { "UserID" });
            DropIndex("dbo.Patients", new[] { "IdUsine" });
            DropIndex("dbo.Events", new[] { "idDoctors" });
            DropIndex("dbo.MedecinConventionnes", new[] { "idSpecialite" });
            DropIndex("dbo.AppointementModels", new[] { "idPatients" });
            DropIndex("dbo.AppointementModels", new[] { "idDoctors" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RDVs");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Usines");
            DropTable("dbo.FileDetails");
            DropTable("dbo.ConsultationDetails");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Consultations");
            DropTable("dbo.Patients");
            DropTable("dbo.Specialites");
            DropTable("dbo.Events");
            DropTable("dbo.MedecinConventionnes");
            DropTable("dbo.AppointementModels");
        }
    }
}
