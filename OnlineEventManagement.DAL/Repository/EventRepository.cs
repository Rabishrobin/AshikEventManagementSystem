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
                return context.Events.ToList();                         //Getting all the events from the database as a list
            }
        }
        public static bool VerifyEvent(string eventId)
        {
            bool IsExist = false;
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                IsExist = (context.Events.Where(e => e.EventId == eventId).FirstOrDefault() == null);           //Verifying the existance of the event
            }
            return IsExist;
        }
        public static void AddEvent(Event newEvent)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Events.Add(newEvent);           //Adding the event details to the context
                context.SaveChanges();                  //Saving the changes to the database

            }
        }
        public static Event GetEventById(string eventId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Events.Where(e => e.EventId == eventId).FirstOrDefault();        //Getting the event details by passing the id 
            }
        }
        public static void DeleteEvent(string eventId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Event existingEvent = GetEventById(eventId);                    //Getting the event object to be deleted
                context.Events.Attach(existingEvent);                           //Attaching the object to be removed
                context.Events.Remove(existingEvent);                           //Removing the event from the database
                context.SaveChanges();                                          //Saving the changes
            }
        }
        public static void UpdateEvent(Event updatedEvent)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Entry(updatedEvent).State = System.Data.Entity.EntityState.Modified;        //Updating the event details
                context.SaveChanges();                                                              //Saving the changes
            }
        }
    }
}
