namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigurationAddedOnclientsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "UserName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Clients", "PassWord", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "PassWord", c => c.String());
            AlterColumn("dbo.Clients", "UserName", c => c.String());
        }
    }
}
