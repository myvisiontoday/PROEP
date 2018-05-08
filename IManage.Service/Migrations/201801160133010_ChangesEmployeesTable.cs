namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesEmployeesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsClocked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsClocked");
        }
    }
}
