namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CleaningUpClockInOutsTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT('ClockInOuts', RESEED, 0)");
            Sql("DELETE FROM ClockInOuts");
        }

        public override void Down()
        {
        }
    }
}
