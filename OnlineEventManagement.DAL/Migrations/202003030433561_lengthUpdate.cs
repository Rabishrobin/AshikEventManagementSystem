namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lengthUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Accounts", name: "UserDOB", newName: "Date of Birth");
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "User Id", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Accounts", "Mail Id", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Accounts", "First Name", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Accounts", "Last Name", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Accounts", "Gender", c => c.String(nullable: false, maxLength: 10));
            AddPrimaryKey("dbo.Accounts", "User Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Last Name", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "First Name", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Mail Id", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "User Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Accounts", "User Id");
            RenameColumn(table: "dbo.Accounts", name: "Date of Birth", newName: "UserDOB");
        }
    }
}
