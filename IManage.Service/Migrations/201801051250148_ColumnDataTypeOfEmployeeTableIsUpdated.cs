namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnDataTypeOfEmployeeTableIsUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "DateOfBirth", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
