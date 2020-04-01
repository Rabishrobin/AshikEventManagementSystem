namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "User Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Accounts", "User Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "User Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Accounts", "User Id");
        }
    }
}
