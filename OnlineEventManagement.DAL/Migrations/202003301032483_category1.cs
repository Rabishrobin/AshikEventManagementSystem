namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "Service Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Service Category", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
