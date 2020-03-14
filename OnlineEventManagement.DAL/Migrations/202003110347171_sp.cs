namespace OnlineEventManagement.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class sp : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Service_Insert",
                p => new
                    {
                        ServiceId = p.String(name: "Service_Id", maxLength: 128),
                        ServiceName = p.String(name: "Service_Name", maxLength: 20),
                        ServiceType = p.String(name: "Service_Type", maxLength: 20),
                    },
                body:
                    @"INSERT [dbo].[Services]([Service Id], [Service Name], [Service Type])
                      VALUES (@Service_Id, @Service_Name, @Service_Type)"
            );
            
            CreateStoredProcedure(
                "dbo.Service_Update",
                p => new
                    {
                        ServiceId = p.String(name: "Service_Id", maxLength: 128),
                        ServiceName = p.String(name: "Service_Name", maxLength: 20),
                        ServiceType = p.String(name: "Service_Type", maxLength: 20),
                    },
                body:
                    @"UPDATE [dbo].[Services]
                      SET [Service Name] = @Service_Name, [Service Type] = @Service_Type
                      WHERE ([Service Id] = @Service_Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Service_Delete",
                p => new
                    {
                        ServiceId = p.String(name: "Service_Id", maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Services]
                      WHERE ([Service Id] = @Service_Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Service_Delete");
            DropStoredProcedure("dbo.Service_Update");
            DropStoredProcedure("dbo.Service_Insert");
        }
    }
}
