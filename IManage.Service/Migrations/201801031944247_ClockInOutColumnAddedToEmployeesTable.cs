namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClockInOutColumnAddedToEmployeesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClockInOuts", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Employees", "PinCode", c => c.String(nullable: false, maxLength: 4));
            CreateIndex("dbo.ClockInOuts", "EmployeeId");
            AddForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ClockInOuts", new[] { "EmployeeId" });
            AlterColumn("dbo.Employees", "PinCode", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            DropColumn("dbo.ClockInOuts", "EmployeeId");
        }
    }
}
