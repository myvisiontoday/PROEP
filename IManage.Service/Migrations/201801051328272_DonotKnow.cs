namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DonotKnow : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Items", "AddedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Items", "DeletedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "DeletedDate", c => c.DateTime());
            AlterColumn("dbo.Items", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Items", "Name", c => c.String());
        }
    }
}
