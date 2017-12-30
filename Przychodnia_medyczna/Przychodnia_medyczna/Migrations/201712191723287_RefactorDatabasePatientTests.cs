namespace Przychodnia_medyczna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorDatabasePatientTests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Morfologias", "Morfology_Id", "dbo.Morfologias");
            DropForeignKey("dbo.TestResults", "Morfologia_Id", "dbo.Morfologias");
            DropForeignKey("dbo.TestResults", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.TestResults", new[] { "Morfologia_Id" });
            DropIndex("dbo.TestResults", new[] { "Patient_PatientId" });
            DropIndex("dbo.Morfologias", new[] { "Morfology_Id" });
            CreateTable(
                "dbo.PatientTests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        TestName = c.String(),
                        Patient_PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Patient_PatientId);
            
            CreateTable(
                "dbo.TestElements",
                c => new
                    {
                        TestElementId = c.Int(nullable: false, identity: true),
                        TestTypeId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestElementId)
                .ForeignKey("dbo.TestTypes", t => t.TestTypeId, cascadeDelete: true)
                .ForeignKey("dbo.TestUnits", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.TestTypeId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.TestTypes",
                c => new
                    {
                        TestId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.PatientTests", t => t.TestId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.TestUnits",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                        UnitLabel = c.String(),
                        MinValue = c.Single(nullable: false),
                        MaxValue = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.UnitId);
            
            CreateTable(
                "dbo.TestValues",
                c => new
                    {
                        TestId = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.PatientTests", t => t.TestId)
                .Index(t => t.TestId);
            
            DropTable("dbo.TestResults");
            DropTable("dbo.Morfologias");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.TestResultId);
            
            DropForeignKey("dbo.TestValues", "TestId", "dbo.PatientTests");
            DropForeignKey("dbo.TestElements", "UnitId", "dbo.TestUnits");
            DropForeignKey("dbo.TestElements", "TestTypeId", "dbo.TestTypes");
            DropForeignKey("dbo.TestTypes", "TestId", "dbo.PatientTests");
            DropForeignKey("dbo.PatientTests", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.TestValues", new[] { "TestId" });
            DropIndex("dbo.TestTypes", new[] { "TestId" });
            DropIndex("dbo.TestElements", new[] { "UnitId" });
            DropIndex("dbo.TestElements", new[] { "TestTypeId" });
            DropIndex("dbo.PatientTests", new[] { "Patient_PatientId" });
            DropTable("dbo.TestValues");
            DropTable("dbo.TestUnits");
            DropTable("dbo.TestTypes");
            DropTable("dbo.TestElements");
            DropTable("dbo.PatientTests");
            CreateIndex("dbo.Morfologias", "Morfology_Id");
            CreateIndex("dbo.TestResults", "Patient_PatientId");
            CreateIndex("dbo.TestResults", "Morfologia_Id");
            AddForeignKey("dbo.TestResults", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.TestResults", "Morfologia_Id", "dbo.Morfologias", "Id");
            AddForeignKey("dbo.Morfologias", "Morfology_Id", "dbo.Morfologias", "Id");
        }
    }
}
