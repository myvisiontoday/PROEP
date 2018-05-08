namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnDataTypeOfClockInOutsTableHasChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClockInOuts", "ClockInDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ClockInOuts", "ClockOutDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClockInOuts", "ClockOutDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ClockInOuts", "ClockInDateTime", c => c.DateTime(nullable: false));
        }
    }
}
