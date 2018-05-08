namespace IManageService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddClientTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(),
                    PassWord = c.String(),
                    IsLoggedIn = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Clients VALUES('admin','admin','false')");

        }

        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
