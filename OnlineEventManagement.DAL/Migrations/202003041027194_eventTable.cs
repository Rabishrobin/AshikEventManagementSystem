namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.String(name: "Event Id", nullable: false, maxLength: 128),
                        EventName = c.String(name: "Event Name", nullable: false, maxLength: 20),
                        EventType = c.String(name: "Event Type", nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
