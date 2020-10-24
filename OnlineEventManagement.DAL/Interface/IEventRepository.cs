using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagement.DAL.Interface
{
    public interface IEventRepository
    {
        void AddEvent(Event newEvent);
        void UpdateEvent(Event updateEvent);
        void DeleteEvent(int eventId);
        IEnumerable<Event> GetEventList();
        Event GetEventById(int eventId);
        bool VerifyEvent(string eventName);
        int GenerateEventID();
    }
}
