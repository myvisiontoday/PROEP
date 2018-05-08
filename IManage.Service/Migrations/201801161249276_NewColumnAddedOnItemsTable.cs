namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnAddedOnItemsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "UpdateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "UpdateDate");
        }
    }
}
