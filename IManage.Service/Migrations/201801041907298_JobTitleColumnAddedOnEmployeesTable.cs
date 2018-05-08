namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobTitleColumnAddedOnEmployeesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "JobTitle", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Employees", "JobTitle");
        }
    }
}
