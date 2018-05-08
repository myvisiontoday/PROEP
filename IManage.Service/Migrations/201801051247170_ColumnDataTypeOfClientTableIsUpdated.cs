namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnDataTypeOfClientTableIsUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "SubscriptionsStartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Clients", "SubscriptionsEndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "SubscriptionsEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "SubscriptionsStartDate", c => c.DateTime(nullable: false));
        }
    }
}
