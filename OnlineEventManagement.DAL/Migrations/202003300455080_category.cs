namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.Services");
            CreateTable(
                "dbo.ServiceCategories",
                c => new
                    {
                        CategoryId = c.Int(name: "Category Id", nullable: false),
                        CategoryName = c.String(name: "Category Name", nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Services", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "Event Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Services", "Service Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Events", "Event Id");
            AddPrimaryKey("dbo.Services", "Service Id");
            CreateIndex("dbo.Services", "CategoryID");
            AddForeignKey("dbo.Services", "CategoryID", "dbo.ServiceCategories", "Category Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "CategoryID", "dbo.ServiceCategories");
            DropIndex("dbo.Services", new[] { "CategoryID" });
            DropPrimaryKey("dbo.Services");
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Services", "Service Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Events", "Event Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Services", "CategoryID");
            DropTable("dbo.ServiceCategories");
            AddPrimaryKey("dbo.Services", "Service Id");
            AddPrimaryKey("dbo.Events", "Event Id");
        }
    }
}
