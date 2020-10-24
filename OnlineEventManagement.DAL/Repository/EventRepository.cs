using OnlineEventManagement.DAL;
using OnlineEventManagement.DAL.Interface;
using OnlineEventManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineEventManagement.Repository.DAL
{
    public class EventRepository : IEventRepository
    {
        public void AddEvent(Event newEvent)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Events.Add(newEvent);           //Adding the event details to the context
                context.SaveChanges();                  //Saving the changes to the database
            }
        }
        public void DeleteEvent(int eventId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Event existingEvent = GetEventById(eventId);                    //Getting the event object to be deleted
                context.Events.Attach(existingEvent);                           //Attaching the object to be removed
                context.Events.Remove(existingEvent);                           //Removing the event from the database
                context.SaveChanges();                                          //Saving the changes
            }
        }
        public void UpdateEvent(Event updatedEvent)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Entry(updatedEvent).State = System.Data.Entity.EntityState.Modified;        //Updating the event details
                context.SaveChanges();                                                              //Saving the changes
            }
        }
        public IEnumerable<Event> GetEventList()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Events.ToList();                         //Getting all the events from the database as a list
            }
        }
        public bool VerifyEvent(string eventName)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                bool CanAddEvent = false;
                //Verifying the existance of the event
                if (context.Events.Where(u => u.EventName == eventName).FirstOrDefault() == null)
                {
                    CanAddEvent = true;
                }
                return CanAddEvent;
            }
        }
        public Event GetEventById(int eventId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Events.Where(e => e.EventId == eventId).FirstOrDefault();        //Getting the event details by passing the id 
            }
        }
        public int GenerateEventID()
        {
            int id = 0;
            int eventId;
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                //Getting the latest event id
                id = int.Parse(context.Events.ToList().Last().EventId.ToString().Substring(4))+1;
                //Generating event id
                eventId = int.Parse((int)'E' + DateTime.Now.Year.ToString().Substring(2, 2) + id.ToString().PadLeft(3, '0'));
            }
            return eventId;
        }
    }
}
