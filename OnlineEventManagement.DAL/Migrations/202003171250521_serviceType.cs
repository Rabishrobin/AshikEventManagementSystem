namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceType : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Services", name: "Service Type", newName: "Service Category");
            AddColumn("dbo.Services", "Event Type", c => c.String(nullable: false, maxLength: 20));
            DropStoredProcedure("dbo.Service_Insert");
            DropStoredProcedure("dbo.Service_Update");
            DropStoredProcedure("dbo.Service_Delete");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Event Type");
            RenameColumn(table: "dbo.Services", name: "Service Category", newName: "Service Type");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
