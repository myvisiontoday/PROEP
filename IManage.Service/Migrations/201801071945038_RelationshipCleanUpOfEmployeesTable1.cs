namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipCleanUpOfEmployeesTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Notifications", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees");
            AlterColumn("dbo.Employees", "PinCode", c => c.String(maxLength: 4));
            AddForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Notifications", "EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Notifications", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees");
            AlterColumn("dbo.Employees", "PinCode", c => c.String(nullable: false, maxLength: 4));
            AddForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Notifications", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
