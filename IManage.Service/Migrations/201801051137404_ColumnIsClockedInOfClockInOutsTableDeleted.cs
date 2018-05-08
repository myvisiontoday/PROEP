namespace IManageService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnIsClockedInOfClockInOutsTableDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ClockInOuts", "IsClockedIn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClockInOuts", "IsClockedIn", c => c.Boolean(nullable: false));
        }
    }
}
