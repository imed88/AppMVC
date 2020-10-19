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
                "dbo.Usines",
                c => new
                    {
                        IdUsine = c.Int(nullable: false, identity: true),
                        UsineName = c.String(),
                    })
                .PrimaryKey(t => t.IdUsine);
            
            CreateTable(
                "dbo.ProductPurchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        PurchaseQuantity = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        pro_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.tbl_product", t => t.pro_id, cascadeDelete: true)
                .Index(t => t.pro_id);
            
            CreateTable(
                "dbo.tbl_product",
                c => new
                    {
                        pro_id = c.Int(nullable: false, identity: true),
                        pro_name = c.String(),
                        Quantity = c.Int(),
                        pro_desc = c.String(),
                        pro_image = c.String(),
                    })
                .PrimaryKey(t => t.pro_id);
            
            CreateTable(
                "dbo.tbl_order",
                c => new
                    {
                        o_id = c.Int(nullable: false, identity: true),
                        o_fk_pro = c.Int(),
                        o_fk_invoice = c.Int(),
                        o_date = c.DateTime(),
                        o_qty = c.Int(),
                        o_bill = c.Double(),
                        o_unitprice = c.Int(),
                        ConsultationID = c.Int(),
                        tbl_invoice_in_id = c.Int(),
                        tbl_product_pro_id = c.Int(),
                    })
                .PrimaryKey(t => t.o_id)
                .ForeignKey("dbo.Consultations", t => t.ConsultationID)
                .ForeignKey("dbo.tbl_invoice", t => t.tbl_invoice_in_id)
                .ForeignKey("dbo.tbl_product", t => t.tbl_product_pro_id)
                .Index(t => t.ConsultationID)
                .Index(t => t.tbl_invoice_in_id)
                .Index(t => t.tbl_product_pro_id);
            
            CreateTable(
                "dbo.tbl_invoice",
                c => new
                    {
                        in_id = c.Int(nullable: false, identity: true),
                        ConsultationID = c.Int(),
                        in_date = c.DateTime(),
                        in_totalbill = c.Double(),
                    })
                .PrimaryKey(t => t.in_id)
                .ForeignKey("dbo.Consultations", t => t.ConsultationID)
                .Index(t => t.ConsultationID);
            
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
            DropForeignKey("dbo.tbl_order", "tbl_product_pro_id", "dbo.tbl_product");
            DropForeignKey("dbo.tbl_order", "tbl_invoice_in_id", "dbo.tbl_invoice");
            DropForeignKey("dbo.tbl_invoice", "ConsultationID", "dbo.Consultations");
            DropForeignKey("dbo.tbl_order", "ConsultationID", "dbo.Consultations");
            DropForeignKey("dbo.ProductPurchases", "pro_id", "dbo.tbl_product");
            DropForeignKey("dbo.Patients", "IdUsine", "dbo.Usines");
            DropForeignKey("dbo.FileDetails", "IdPatients", "dbo.Patients");
            DropForeignKey("dbo.Consultations", "idPatients", "dbo.Patients");
            DropForeignKey("dbo.Consultations", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppointementModels", "idPatients", "dbo.Patients");
            DropForeignKey("dbo.MedecinConventionnes", "idSpecialite", "dbo.Specialites");
            DropForeignKey("dbo.AppointementModels", "idDoctors", "dbo.MedecinConventionnes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RDVs", new[] { "ConsultationID" });
            DropIndex("dbo.tbl_invoice", new[] { "ConsultationID" });
            DropIndex("dbo.tbl_order", new[] { "tbl_product_pro_id" });
            DropIndex("dbo.tbl_order", new[] { "tbl_invoice_in_id" });
            DropIndex("dbo.tbl_order", new[] { "ConsultationID" });
            DropIndex("dbo.ProductPurchases", new[] { "pro_id" });
            DropIndex("dbo.FileDetails", new[] { "IdPatients" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Consultations", new[] { "idPatients" });
            DropIndex("dbo.Consultations", new[] { "UserID" });
            DropIndex("dbo.Patients", new[] { "IdUsine" });
            DropIndex("dbo.MedecinConventionnes", new[] { "idSpecialite" });
            DropIndex("dbo.AppointementModels", new[] { "idPatients" });
            DropIndex("dbo.AppointementModels", new[] { "idDoctors" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RDVs");
            DropTable("dbo.tbl_invoice");
            DropTable("dbo.tbl_order");
            DropTable("dbo.tbl_product");
            DropTable("dbo.ProductPurchases");
            DropTable("dbo.Usines");
            DropTable("dbo.FileDetails");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Consultations");
            DropTable("dbo.Patients");
            DropTable("dbo.Specialites");
            DropTable("dbo.MedecinConventionnes");
            DropTable("dbo.AppointementModels");
        }
    }
}
