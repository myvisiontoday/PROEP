namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeletedColumnAddedInEmployeesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsDeleted");
        }
    }
}
