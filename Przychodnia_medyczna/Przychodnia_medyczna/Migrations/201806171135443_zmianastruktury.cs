namespace Przychodnia_medyczna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmianastruktury : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestUnits", "TestGroup_TestGroupId", "dbo.TestGroups");
            DropForeignKey("dbo.TestElements", "TestTypeId", "dbo.TestTypes");
            DropForeignKey("dbo.TestTypes", "TestId", "dbo.PatientTests");
            DropIndex("dbo.TestTypes", new[] { "TestId" });
            DropIndex("dbo.TestElements", new[] { "TestTypeId" });
            DropIndex("dbo.TestUnits", new[] { "TestGroup_TestGroupId" });
            CreateTable(
                "dbo.PatientRegisterModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PESEL = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ContactNumber = c.String(),
                        Role = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        Address_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            AddColumn("dbo.PatientTests", "CreateUser", c => c.String());
            AddColumn("dbo.PatientTests", "CreteDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PatientTests", "TestName");
            DropColumn("dbo.TestElements", "TestTypeId");
            DropTable("dbo.TestTypes");
            DropTable("dbo.TestUnits");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestUnits",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                        UnitLabel = c.String(),
                        MinValue = c.Single(nullable: false),
                        MaxValue = c.Single(nullable: false),
                        TestGroup_TestGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.UnitId);
            
            CreateTable(
                "dbo.TestTypes",
                c => new
                    {
                        TestTypeId = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TestTypeId);
            
            AddColumn("dbo.TestElements", "TestTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.PatientTests", "TestName", c => c.String());
            DropForeignKey("dbo.PatientRegisterModels", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.PatientRegisterModels", new[] { "Address_Id" });
            DropColumn("dbo.PatientTests", "CreteDate");
            DropColumn("dbo.PatientTests", "CreateUser");
            DropTable("dbo.PatientRegisterModels");
            CreateIndex("dbo.TestUnits", "TestGroup_TestGroupId");
            CreateIndex("dbo.TestElements", "TestTypeId");
            CreateIndex("dbo.TestTypes", "TestId");
            AddForeignKey("dbo.TestTypes", "TestId", "dbo.PatientTests", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.TestElements", "TestTypeId", "dbo.TestTypes", "TestTypeId", cascadeDelete: true);
            AddForeignKey("dbo.TestUnits", "TestGroup_TestGroupId", "dbo.TestGroups", "TestGroupId");
        }
    }
}
