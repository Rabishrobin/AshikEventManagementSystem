using OnlineEventManagement.Repository.DAL;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL
{
    public class EventBL
    {
        public static void AddEvent(Event newEvent)
        {
            EventRepository.AddEvent(newEvent);
        }
        public static IEnumerable<Event> DisplayEvents()
        {
            return EventRepository.DisplayEvents();
        }
        public static bool VerifyEvent(string eventId)
        {
            return EventRepository.VerifyEvent(eventId);
        }
    }
}
