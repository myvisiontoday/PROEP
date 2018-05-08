namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DeletedAllRecordsOfClockInoutTables : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM ClockInOuts");
            Sql("DBCC CHECKIDENT('ClockInOuts', RESEED, 0)");
        }

        public override void Down()
        {
        }
    }
}
