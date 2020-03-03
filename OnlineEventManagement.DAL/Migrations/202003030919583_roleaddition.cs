namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleaddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Role", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Role");
        }
    }
}
