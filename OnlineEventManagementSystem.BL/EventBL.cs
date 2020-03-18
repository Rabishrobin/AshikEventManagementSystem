using OnlineEventManagement.Repository.DAL;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL
{
    public class EventBL
    {
        public static void AddEvent(Event newEvent)
        {
            EventRepository.AddEvent(newEvent);             //Adding new event to the database
        }
        public static Event GetEventById(string eventId)
        {
            return EventRepository.GetEventById(eventId);    //Getting a particular event
        }
        public static IEnumerable<Event> DisplayEvents()
        {
            return EventRepository.DisplayEvents();         //Getting the events as object in list from the database 
        }
        public static bool VerifyEvent(string eventId)
        {
            return EventRepository.VerifyEvent(eventId);        //Verifying the existance of the event
        }
        public static void DeleteEvent(string eventId)
        {
            EventRepository.DeleteEvent(eventId);           //Deleting an event from the database
        }
        public static void UpdateEvent(Event updatedEvent)
        {
            EventRepository.UpdateEvent(updatedEvent);      //Updating the event details in the database
        }
    }
}
