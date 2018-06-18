 namespace Przychodnia_medyczna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestValues", "TestId", "dbo.PatientTests");
            DropIndex("dbo.TestValues", new[] { "TestId" });
            CreateTable(
                "dbo.PatientTestValues",
                c => new
                    {
                        TestValueId = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        TeElementId = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TestValueId)
                .ForeignKey("dbo.PatientTests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.TestUnits",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                    })
                .PrimaryKey(t => t.UnitId);
            
            AddColumn("dbo.TestElements", "UnitId", c => c.Int(nullable: false));
            AddColumn("dbo.TestElements", "MinValue", c => c.Single(nullable: false));
            AddColumn("dbo.TestElements", "MaxValue", c => c.Single(nullable: false));
            AddColumn("dbo.TestElements", "PateintTestValue_TestValueId", c => c.Int());
            AddColumn("dbo.TestGroups", "GroupName", c => c.String());
            CreateIndex("dbo.TestElements", "UnitId");
            CreateIndex("dbo.TestElements", "PateintTestValue_TestValueId");
            AddForeignKey("dbo.TestElements", "UnitId", "dbo.TestUnits", "UnitId", cascadeDelete: true);
            AddForeignKey("dbo.TestElements", "PateintTestValue_TestValueId", "dbo.PatientTestValues", "TestValueId");
            DropTable("dbo.TestValues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestValues",
                c => new
                    {
                        TestValueId = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TestValueId);
            
            DropForeignKey("dbo.TestElements", "PateintTestValue_TestValueId", "dbo.PatientTestValues");
            DropForeignKey("dbo.TestElements", "UnitId", "dbo.TestUnits");
            DropForeignKey("dbo.PatientTestValues", "TestId", "dbo.PatientTests");
            DropIndex("dbo.TestElements", new[] { "PateintTestValue_TestValueId" });
            DropIndex("dbo.TestElements", new[] { "UnitId" });
            DropIndex("dbo.PatientTestValues", new[] { "TestId" });
            DropColumn("dbo.TestGroups", "GroupName");
            DropColumn("dbo.TestElements", "PateintTestValue_TestValueId");
            DropColumn("dbo.TestElements", "MaxValue");
            DropColumn("dbo.TestElements", "MinValue");
            DropColumn("dbo.TestElements", "UnitId");
            DropTable("dbo.TestUnits");
            DropTable("dbo.PatientTestValues");
            CreateIndex("dbo.TestValues", "TestId");
            AddForeignKey("dbo.TestValues", "TestId", "dbo.PatientTests", "TestId", cascadeDelete: true);
        }
    }
}
