namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnNameCreateDateoOfScheduleTableIsRenamed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Schedules", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Schedules", "CreatedDate");
        }
    }
}
