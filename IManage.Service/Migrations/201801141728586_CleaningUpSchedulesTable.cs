namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CleaningUpSchedulesTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Schedules");
            Sql("DBCC CHECKIDENT('Schedules', RESEED, 0)");
        }

        public override void Down()
        {
        }
    }
}
