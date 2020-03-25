namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Roles", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Accounts", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Role", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Accounts", "Roles");
        }
    }
}
