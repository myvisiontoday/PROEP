namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchedulesTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekDay = c.Int(nullable: false),
                        WeekNumber = c.Int(nullable: false),
                        StartHour = c.DateTime(nullable: false),
                        EndHour = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schedules");
        }
    }
}
