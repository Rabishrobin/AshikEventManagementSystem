using OnlineEventManagement.DAL;
using OnlineEventManagement.DAL.Interface;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineEventManagement.Repository.DAL
{
    public class EventRepository : IElementRepository
    {
        public IEnumerable<object> DisplayElements()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Events.ToList();                         //Getting all the events from the database as a list
            }
        }
        public int? VerifyExistance(string eventName)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                int? id = null;
                if (context.Events.Where(u => u.EventName == eventName).FirstOrDefault() == null)
                {
                    IEnumerable<Event> events = context.Events.ToList();
                    id = events.Count() == 0 ? 0 : int.Parse(events.Last().EventId.ToString().Substring(4)) + 1;
                }
                return id;                   //Verifying user existance
            }
        }
        public void AddElement(object newEvent)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Events.Add((Event)newEvent);           //Adding the event details to the context
                context.SaveChanges();                  //Saving the changes to the database

            }
        }
        public object GetElementById(int eventId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Events.Where(e => e.EventId == eventId).FirstOrDefault();        //Getting the event details by passing the id 
            }
        }
        public void DeleteElement(int eventId)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Event existingEvent = (Event)GetElementById(eventId);                    //Getting the event object to be deleted
                context.Events.Attach(existingEvent);                           //Attaching the object to be removed
                context.Events.Remove(existingEvent);                           //Removing the event from the database
                context.SaveChanges();                                          //Saving the changes
            }
        }
        public void UpdateElement(object updatedEvent)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Entry((Event)updatedEvent).State = System.Data.Entity.EntityState.Modified;        //Updating the event details
                context.SaveChanges();                                                              //Saving the changes
            }
        }
    }
}
