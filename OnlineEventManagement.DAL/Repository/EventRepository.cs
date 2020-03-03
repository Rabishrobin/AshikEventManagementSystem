using OnlineEventManagement.DAL;
using OnlineEventManagementSystem.Entity;
using System.Linq;


namespace OnlineEventManagement.Repository.DAL
{
    public class EventRepository
    {
        static OnlineEventManagementDBContext context = new OnlineEventManagementDBContext();
        public static void AddEvent(Event newEvent)
        {
            context.EventDB.Add(newEvent);
            context.SaveChanges();
        }
    }
}
