namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PinCodeColumnAddedInEmployeesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PinCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "PinCode");
        }
    }
}
