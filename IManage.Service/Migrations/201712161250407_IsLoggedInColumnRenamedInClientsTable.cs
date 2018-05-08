namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class IsLoggedInColumnRenamedInClientsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "IsSubscriptionsExpired", c => c.Boolean(nullable: false));
            Sql("UPDATE Clients SET IsLoggedIn=IsSubscriptionsExpired");
            DropColumn("dbo.Clients", "IsLoggedIn");
        }

        public override void Down()
        {
            AddColumn("dbo.Clients", "IsLoggedIn", c => c.Boolean(nullable: false));
            Sql("UPDATE Clients SET IsSubscriptionsExpired=IsLoggedIn");
            DropColumn("dbo.Clients", "IsSubscriptionsExpired");
        }
    }
}
