namespace Przychodnia_medyczna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.String(nullable: false, maxLength: 128),
                        PESEL = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.AspNetUsers", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.String(nullable: false, maxLength: 128),
                        LaboratoryId = c.String(),
                    })
                .PrimaryKey(t => t.ManagerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ManagerId)
                .Index(t => t.ManagerId);
            
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
                "dbo.TestResults",
                c => new
                    {
                        TestResultId = c.String(nullable: false, maxLength: 128),
                        TestType = c.String(),
                        ManagerId = c.String(nullable: false),
                        PatientPesel = c.String(nullable: false),
                        Date = c.DateTime(),
                        Morfologia_Id = c.String(maxLength: 128),
                        Patient_PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TestResultId)
                .ForeignKey("dbo.Morfologias", t => t.Morfologia_Id)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Morfologia_Id)
                .Index(t => t.Patient_PatientId);
            
            CreateTable(
                "dbo.Morfologias",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Monocyty = c.Double(nullable: false),
                        Eozynofile = c.Double(nullable: false),
                        Bazofile = c.Double(nullable: false),
                        TestResultId = c.String(),
                        Morfology_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Morfologias", t => t.Morfology_Id)
                .Index(t => t.Morfology_Id);
            
            CreateTable(
                "dbo.Laboratories",
                c => new
                    {
                        LaboratoryId = c.String(nullable: false, maxLength: 128),
                        LabolatoryName = c.String(),
                        Street = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.LaboratoryId);
            
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
            DropForeignKey("dbo.Addresses", "Id", "dbo.Patients");
            DropForeignKey("dbo.TestResults", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.TestResults", "Morfologia_Id", "dbo.Morfologias");
            DropForeignKey("dbo.Morfologias", "Morfology_Id", "dbo.Morfologias");
            DropForeignKey("dbo.Patients", "PatientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Managers", "ManagerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Morfologias", new[] { "Morfology_Id" });
            DropIndex("dbo.TestResults", new[] { "Patient_PatientId" });
            DropIndex("dbo.TestResults", new[] { "Morfologia_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Managers", new[] { "ManagerId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Patients", new[] { "PatientId" });
            DropIndex("dbo.Addresses", new[] { "Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Laboratories");
            DropTable("dbo.Morfologias");
            DropTable("dbo.TestResults");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Managers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Patients");
            DropTable("dbo.Addresses");
        }
    }
}
