namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserManagers",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        UserMailId = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                        UserFirstName = c.String(nullable: false),
                        UserLastName = c.String(nullable: false),
                        UserMobileNumber = c.Long(nullable: false),
                        UserGender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserManagers");
        }
    }
}
