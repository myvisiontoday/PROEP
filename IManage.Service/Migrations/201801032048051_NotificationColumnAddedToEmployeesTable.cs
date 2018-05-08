namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificationColumnAddedToEmployeesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notifications", "EmployeeId");
            AddForeignKey("dbo.Notifications", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Notifications", new[] { "EmployeeId" });
            DropColumn("dbo.Notifications", "EmployeeId");
        }
    }
}
