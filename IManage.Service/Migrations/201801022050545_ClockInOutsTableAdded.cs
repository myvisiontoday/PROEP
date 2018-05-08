namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClockInOutsTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClockInOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsClockedIn = c.Boolean(nullable: false),
                        ClockInDateTime = c.DateTime(nullable: false),
                        ClockOutDateTime = c.DateTime(nullable: false),
                        TotalHoursWorked = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClockInOuts");
        }
    }
}
