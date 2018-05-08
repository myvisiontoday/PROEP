namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeIdColumnAddedToSchedulesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "EmployeeId");
            AddForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Schedules", new[] { "EmployeeId" });
            DropColumn("dbo.Schedules", "EmployeeId");
        }
    }
}
