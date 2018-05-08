namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnDataTypeOfNotificationTableIsUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "DeletedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "DeletedDate", c => c.DateTime(nullable: false));
        }
    }
}
