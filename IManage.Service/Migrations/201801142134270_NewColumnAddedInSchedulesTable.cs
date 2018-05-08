namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class NewColumnAddedInSchedulesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "WeekNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "IsDeleted", c => c.Boolean(nullable: false));
            Sql("DELETE FROM Schedules");
            Sql("DBCC CHECKIDENT('Schedules', RESEED, 0)");
        }

        public override void Down()
        {
            DropColumn("dbo.Schedules", "IsDeleted");
            DropColumn("dbo.Schedules", "WeekNumber");
        }
    }
}
