using OnlineEventManagement.Repository.DAL;
using OnlineEventManagement.DAL.Interface;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;
using OnlineEventManagementSystem.BL.Interface;

namespace OnlineEventManagementSystem.BL
{
    public class EventBL : IElementBL
    {
        IElementRepository eventRepository;
        public EventBL()
        {
            eventRepository = new EventRepository();
        }
        public void AddElement(object newEvent)
        {
            eventRepository.AddElement(newEvent);             //Adding new event to the database
        }
        public object GetElementById(int eventId)
        {
            return eventRepository.GetElementById(eventId);    //Getting a particular event
        }
        public IEnumerable<object> DisplayElements()
        {
            return eventRepository.DisplayElements();         //Getting the events as object in list from the database 
        }
        public int? VerifyExistance(string eventName)
        {
            return eventRepository.VerifyExistance(eventName);        //Verifying the existance of the event
        }
        public void DeleteElement(int eventId)
        {
            eventRepository.DeleteElement(eventId);           //Deleting an event from the database
        }
        public void UpdateElement(object updatedEvent)
        {
            eventRepository.UpdateElement(updatedEvent);      //Updating the event details in the database
        }
    }
}
