namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwoNewColumnSubscriptionsStartAndEndDateAddedInClientsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "SubscriptionsStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "SubscriptionsEndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "SubscriptionsEndDate");
            DropColumn("dbo.Clients", "SubscriptionsStartDate");
        }
    }
}
