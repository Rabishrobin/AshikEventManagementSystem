namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniquekey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Accounts", "Mail Id", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "Mail Id" });
        }
    }
}
