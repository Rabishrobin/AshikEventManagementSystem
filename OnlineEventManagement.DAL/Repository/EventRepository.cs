using OnlineEventManagement.DAL;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineEventManagement.Repository.DAL
{
    public class EventRepository
    {
        public static void AddEvent(Event newEvent)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Events.Add(newEvent);
                context.SaveChanges();

            }
        }
        public static IEnumerable<Event> DisplayEvents()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Events.ToList();
            }
        }
        public static bool VerifyEvent(string eventId)
        {
            bool IsExist = false;
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                IsExist = (context.Events.Where(e => e.EventID == eventId).FirstOrDefault() == null);
            }
            return IsExist;
        }
        public static Event GetEventById(string eventId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Events.Where(e => e.EventID == eventId).FirstOrDefault();
            }
        }
        public static void DeleteEvent(string eventId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Event existingEvent = GetEventById(eventId);
                context.Events.Attach(existingEvent);
                context.Events.Remove(existingEvent);
                context.SaveChanges();
            }
        }
    }
}
