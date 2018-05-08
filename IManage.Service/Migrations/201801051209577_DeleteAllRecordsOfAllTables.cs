namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DeleteAllRecordsOfAllTables : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM ClockInOuts");
            Sql("DELETE FROM Schedules");
            Sql("DELETE FROM Employees");
            Sql("DELETE FROM Items");
            Sql("DELETE FROM Clients");
            Sql("DBCC CHECKIDENT('ClockInOuts', RESEED, 0)");
            Sql("DBCC CHECKIDENT('Schedules', RESEED, 0)");
            Sql("DBCC CHECKIDENT('Employees', RESEED, 0)");
            Sql("DBCC CHECKIDENT('Items', RESEED, 0)");
            Sql("DBCC CHECKIDENT('Clients', RESEED, 0)");
        }

        public override void Down()
        {
        }
    }
}
