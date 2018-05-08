namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangesCockInOutsTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM ClockInOuts");
            Sql("DBCC CHECKIDENT('Schedules', RESEED, 0)");

            AddColumn("dbo.ClockInOuts", "EmployeePinCode", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.ClockInOuts", "ClockInDateTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ClockInOuts", "ClockOutDateTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }

        public override void Down()
        {
            AlterColumn("dbo.ClockInOuts", "ClockOutDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ClockInOuts", "ClockInDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.ClockInOuts", "EmployeePinCode");
        }
    }
}
