namespace Przychodnia_medyczna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iuy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestTypes", "TestId", "dbo.PatientTests");
            DropForeignKey("dbo.TestValues", "TestId", "dbo.PatientTests");
            DropForeignKey("dbo.TestElements", "TestTypeId", "dbo.TestTypes");
            RenameColumn(table: "dbo.PatientTests", name: "Patient_PatientId", newName: "PatientId");
            RenameIndex(table: "dbo.PatientTests", name: "IX_Patient_PatientId", newName: "IX_PatientId");
            DropPrimaryKey("dbo.TestTypes");
            DropPrimaryKey("dbo.TestValues");
            AddColumn("dbo.TestTypes", "TestTypeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TestValues", "TestValueId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TestTypes", "TestTypeId");
            AddPrimaryKey("dbo.TestValues", "TestValueId");
            AddForeignKey("dbo.TestTypes", "TestId", "dbo.PatientTests", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.TestValues", "TestId", "dbo.PatientTests", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.TestElements", "TestTypeId", "dbo.TestTypes", "TestTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestElements", "TestTypeId", "dbo.TestTypes");
            DropForeignKey("dbo.TestValues", "TestId", "dbo.PatientTests");
            DropForeignKey("dbo.TestTypes", "TestId", "dbo.PatientTests");
            DropPrimaryKey("dbo.TestValues");
            DropPrimaryKey("dbo.TestTypes");
            DropColumn("dbo.TestValues", "TestValueId");
            DropColumn("dbo.TestTypes", "TestTypeId");
            AddPrimaryKey("dbo.TestValues", "TestId");
            AddPrimaryKey("dbo.TestTypes", "TestId");
            RenameIndex(table: "dbo.PatientTests", name: "IX_PatientId", newName: "IX_Patient_PatientId");
            RenameColumn(table: "dbo.PatientTests", name: "PatientId", newName: "Patient_PatientId");
            AddForeignKey("dbo.TestElements", "TestTypeId", "dbo.TestTypes", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.TestValues", "TestId", "dbo.PatientTests", "TestId");
            AddForeignKey("dbo.TestTypes", "TestId", "dbo.PatientTests", "TestId");
        }
    }
}
