using OnlineEventManagement.DAL;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineEventManagement.Repository.DAL
{
    public class EventRepository
    {
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
                IsExist = (context.Events.Where(e => e.EventId == eventId).FirstOrDefault() == null);
            }
            return IsExist;
        }
        public static void AddEvent(Event newEvent)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Events.Add(newEvent);
                context.SaveChanges();

            }
        }
        public static Event GetEventById(string eventId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Events.Where(e => e.EventId == eventId).FirstOrDefault();
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
        public static void UpdateEvent(Event updatedEvent)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Entry(updatedEvent).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
