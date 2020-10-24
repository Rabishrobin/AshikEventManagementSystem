using OnlineEventManagement.Repository.DAL;
using OnlineEventManagement.DAL.Interface;
using System.Collections.Generic;
using OnlineEventManagementSystem.BL.Interface;
using OnlineEventManagementSystem.Entity;
using System;

namespace OnlineEventManagementSystem.BL
{
    public class EventBL : IEventBL
    {
        IEventRepository eventRepository;
        public EventBL()
        {
            eventRepository = new EventRepository();
        }
        public void AddEvent(Event newEvent)
        {
            eventRepository.AddEvent(newEvent);             //Adding new event to the database
        }
        public Event GetEventById(int eventId)
        {
            return eventRepository.GetEventById(eventId);    //Getting a particular event
        }
        public IEnumerable<Event> GetEventList()
        {
            return eventRepository.GetEventList();         //Getting the events as object in list from the database 
        }
        public bool VerifyEvent(string eventName)
        {
            return eventRepository.VerifyEvent(eventName);        //Verifying the existance of the event
        }
        public void DeleteEvent(int eventId)
        {
            eventRepository.DeleteEvent(eventId);           //Deleting an event from the database
        }
        public void UpdateEvent(Event updatedEvent)
        {
            eventRepository.UpdateEvent(updatedEvent);      //Updating the event details in the database
        }

        public int GenerateEventID()
        {
            return eventRepository.GenerateEventID();
        }
    }
}
