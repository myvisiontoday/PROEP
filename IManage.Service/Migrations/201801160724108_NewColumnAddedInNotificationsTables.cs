namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class NewColumnAddedInNotificationsTables : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT('Notifications', RESEED, 0)");
            Sql("DELETE FROM Notifications");

            AddColumn("dbo.Notifications", "EmployeePinCode", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Notifications", "EmployeePinCode");
        }
    }
}
