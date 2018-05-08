namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangesEmployeesTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ClockInOutId", c => c.Int(nullable: true));
        }

        public override void Down()
        {
            DropColumn("dbo.Employees", "ClockInOutId");
        }
    }
}
