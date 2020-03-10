namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.String(name: "Service Id", nullable: false, maxLength: 128),
                        ServiceName = c.String(name: "Service Name", nullable: false, maxLength: 20),
                        ServiceType = c.String(name: "Service Type", nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
        }
    }
}
