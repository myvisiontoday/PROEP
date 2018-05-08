namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTablesSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        IsClockedIn = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        BsnNumber = c.Int(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
