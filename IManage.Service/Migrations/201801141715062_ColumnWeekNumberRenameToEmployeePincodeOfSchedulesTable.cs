namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ColumnWeekNumberRenameToEmployeePincodeOfSchedulesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "EmployeePinCode", c => c.String(nullable: false));
            Sql("UPDATE Schedules SET EmployeePinCode=WeekNumber");
            DropColumn("dbo.Schedules", "WeekNumber");
        }

        public override void Down()
        {
            AddColumn("dbo.Schedules", "WeekNumber", c => c.Int(nullable: false));
            Sql("UPDATE Schedules SET WeekNumber=EmployeePinCode");
            DropColumn("dbo.Schedules", "EmployeePinCode");
        }
    }
}
