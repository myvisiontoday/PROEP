namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenameColumnNameIsDeletedOfNotificationsTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "IsResolved", c => c.Boolean(nullable: false));
            Sql("UPDATE Notifications SET IsResolved=IsDeleted");
            DropColumn("dbo.Notifications", "IsDeleted");
        }

        public override void Down()
        {
            AddColumn("dbo.Notifications", "IsDeleted", c => c.Boolean(nullable: false));
            Sql("UPDATE Notifications SET IsDeleted=IsResolved");
            DropColumn("dbo.Notifications", "IsResolved");
        }
    }
}
