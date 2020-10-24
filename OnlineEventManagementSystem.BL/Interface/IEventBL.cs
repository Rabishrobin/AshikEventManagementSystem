using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL.Interface
{
    public interface IEventBL
    {
        void AddEvent(Event newEvent);
        void UpdateEvent(Event existingEvent);
        void DeleteEvent(int eventId);
        IEnumerable<Event> GetEventList();
        Event GetEventById(int eventId);
        bool VerifyEvent(string eventName);
        int GenerateEventID();
    }
}
