namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserManagers", newName: "Accounts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Accounts", newName: "UserManagers");
        }
    }
}
