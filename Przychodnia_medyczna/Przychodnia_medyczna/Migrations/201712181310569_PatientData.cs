namespace Przychodnia_medyczna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Name", c => c.String());
            AddColumn("dbo.Patients", "LastName", c => c.String());
            AlterColumn("dbo.Patients", "PESEL", c => c.String());
            DropColumn("dbo.Managers", "LaboratoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Managers", "LaboratoryId", c => c.String());
            AlterColumn("dbo.Patients", "PESEL", c => c.String(nullable: false, maxLength: 11));
            DropColumn("dbo.Patients", "LastName");
            DropColumn("dbo.Patients", "Name");
        }
    }
}
