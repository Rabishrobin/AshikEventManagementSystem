namespace OnlineEventManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserManagers", name: "UserID", newName: "User Id");
            RenameColumn(table: "dbo.UserManagers", name: "UserMailId", newName: "Mail Id");
            RenameColumn(table: "dbo.UserManagers", name: "UserPassword", newName: "Password");
            RenameColumn(table: "dbo.UserManagers", name: "UserFirstName", newName: "First Name");
            RenameColumn(table: "dbo.UserManagers", name: "UserLastName", newName: "Last Name");
            RenameColumn(table: "dbo.UserManagers", name: "UserMobileNumber", newName: "Mobile Number");
            RenameColumn(table: "dbo.UserManagers", name: "UserGender", newName: "Gender");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.UserManagers", name: "Gender", newName: "UserGender");
            RenameColumn(table: "dbo.UserManagers", name: "Mobile Number", newName: "UserMobileNumber");
            RenameColumn(table: "dbo.UserManagers", name: "Last Name", newName: "UserLastName");
            RenameColumn(table: "dbo.UserManagers", name: "First Name", newName: "UserFirstName");
            RenameColumn(table: "dbo.UserManagers", name: "Password", newName: "UserPassword");
            RenameColumn(table: "dbo.UserManagers", name: "Mail Id", newName: "UserMailId");
            RenameColumn(table: "dbo.UserManagers", name: "User Id", newName: "UserID");
        }
    }
}
