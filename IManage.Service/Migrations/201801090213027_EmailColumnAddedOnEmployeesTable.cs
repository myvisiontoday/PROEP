namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailColumnAddedOnEmployeesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Email");
        }
    }
}
