namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IClockedInColumnDeletedFromEmployeesTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "IsClockedIn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "IsClockedIn", c => c.Boolean(nullable: false));
        }
    }
}
