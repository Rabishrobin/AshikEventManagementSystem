using OnlineEventManagement.Repository.DAL;
using OnlineEventManagementSystem.Entity;

namespace OnlineEventManagementSystem.BL
{
    public class EventBL
    {
        public static void AddEvent(Event newEvent)
        {
            EventRepository.AddEvent(newEvent);
        }
    }
}
