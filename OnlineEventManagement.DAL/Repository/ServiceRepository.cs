using OnlineEventManagement.DAL;
using OnlineEventManagementSystem.Entity;

namespace OnlineEventManagement.DAL.Repository
{
    public class ServiceRepository
    {
        static OnlineEventManagementDBContext context = new OnlineEventManagementDBContext();
        public static void AddService(Service newService)
        {
            context.Services.Add(newService);
            context.SaveChanges();
        }
    }
}
