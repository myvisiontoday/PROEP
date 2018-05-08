namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemsTableAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ClockInOuts", new[] { "EmployeeId" });
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "PinCode", c => c.String());
            //DropTable("dbo.ClockInOuts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClockInOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClockInDateTime = c.DateTime(nullable: false),
                        ClockOutDateTime = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Employees", "PinCode", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 65));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 65));
            DropTable("dbo.Items");
            CreateIndex("dbo.ClockInOuts", "EmployeeId");
            AddForeignKey("dbo.ClockInOuts", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
