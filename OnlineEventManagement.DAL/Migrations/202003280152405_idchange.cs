namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idchange : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.Services");
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Events", "Event Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Services", "Service Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Accounts", "User Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Events", "Event Id");
            AddPrimaryKey("dbo.Services", "Service Id");
            AddPrimaryKey("dbo.Accounts", "User Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Accounts");
            DropPrimaryKey("dbo.Services");
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Accounts", "User Id", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Services", "Service Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "Event Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Accounts", "User Id");
            AddPrimaryKey("dbo.Services", "Service Id");
            AddPrimaryKey("dbo.Events", "Event Id");
        }
    }
}
