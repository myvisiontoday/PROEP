namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigurationAddedOnNotificationsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "Message", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Notifications", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Notifications", "DeletedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Items", "Name", c => c.String());
            AlterColumn("dbo.Items", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Items", "DeletedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "DeletedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Items", "AddedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Notifications", "DeletedDate", c => c.DateTime());
            AlterColumn("dbo.Notifications", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "Message", c => c.String());
        }
    }
}
