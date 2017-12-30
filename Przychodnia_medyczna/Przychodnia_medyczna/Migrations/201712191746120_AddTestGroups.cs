namespace Przychodnia_medyczna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestGroups : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestElements", "UnitId", "dbo.TestUnits");
            DropIndex("dbo.TestElements", new[] { "UnitId" });
            CreateTable(
                "dbo.TestGroups",
                c => new
                    {
                        TestGroupId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TestGroupId);
            
            AddColumn("dbo.TestElements", "TestGroupId", c => c.Int(nullable: false));
            AddColumn("dbo.TestUnits", "TestGroup_TestGroupId", c => c.Int());
            CreateIndex("dbo.TestElements", "TestGroupId");
            CreateIndex("dbo.TestUnits", "TestGroup_TestGroupId");
            AddForeignKey("dbo.TestUnits", "TestGroup_TestGroupId", "dbo.TestGroups", "TestGroupId");
            AddForeignKey("dbo.TestElements", "TestGroupId", "dbo.TestGroups", "TestGroupId", cascadeDelete: true);
            DropColumn("dbo.TestElements", "UnitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestElements", "UnitId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TestElements", "TestGroupId", "dbo.TestGroups");
            DropForeignKey("dbo.TestUnits", "TestGroup_TestGroupId", "dbo.TestGroups");
            DropIndex("dbo.TestUnits", new[] { "TestGroup_TestGroupId" });
            DropIndex("dbo.TestElements", new[] { "TestGroupId" });
            DropColumn("dbo.TestUnits", "TestGroup_TestGroupId");
            DropColumn("dbo.TestElements", "TestGroupId");
            DropTable("dbo.TestGroups");
            CreateIndex("dbo.TestElements", "UnitId");
            AddForeignKey("dbo.TestElements", "UnitId", "dbo.TestUnits", "UnitId", cascadeDelete: true);
        }
    }
}
