namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnDataTypeOfDateTimeSchedulesTableIsChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "StartHour", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Schedules", "EndHour", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            //AlterColumn("dbo.Schedules", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Schedules", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Schedules", "DeletedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "DeletedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "EndHour", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "StartHour", c => c.DateTime(nullable: false));
        }
    }
}
