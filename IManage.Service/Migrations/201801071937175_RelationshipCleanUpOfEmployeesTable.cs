namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipCleanUpOfEmployeesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Notifications", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees");
            AddForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Notifications", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Notifications", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees");
            AddForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Notifications", "EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
