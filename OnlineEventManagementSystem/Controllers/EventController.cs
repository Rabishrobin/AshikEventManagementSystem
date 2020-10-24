using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.BL.Interface;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class EventController : Controller
    {
        IEventBL eventDetails;
        public EventController()
        {
            eventDetails = new EventBL();
        }

        [HttpGet]
        public ViewResult DisplayEvents()
        {
            IEnumerable<Event> events = eventDetails.GetEventList();                //Getting the events from the database as object in list
            ViewBag.Events = events;                                            //Passing the list from the controller to view using viewbag
            return View();
        }

        [HttpGet]
        public ViewResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEvent(EventModel newEvent)
        {
            if (ModelState.IsValid)
            {
                bool CanAddEvent = eventDetails.VerifyEvent(newEvent.EventName);
                if (CanAddEvent)
                {
                    var addEvent = AutoMapper.Mapper.Map<EventModel, Event>(newEvent);      //Automapping event details from model to entity
                    eventDetails.AddEvent(addEvent);                                                //Adding the service to the database
                    return RedirectToAction("DisplayEvents");                           //Redirecting after adding the event
                }
                TempData["Message"] = "Event already exists!!";                           //Displaying error message if the event already is added
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateEvent(int id)
        {
            Event existingEvent = eventDetails.GetEventById(id);                             //Getting the event details from database
            EventModel eventModel = AutoMapper.Mapper.Map<Event, EventModel>(existingEvent);    //Mapping the details to the model to show the existing details
            return View(eventModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEvent([Bind(Include = "EventId, EventName, EventType")] EventModel existingEvent)
        {
            if (ModelState.IsValid)
            {
                Event updatedEvent = eventDetails.GetEventById(existingEvent.EventId);           //Getting the objecct of the event by using the event id from the database
                updatedEvent.EventName = existingEvent.EventName;                           //Updating the event name if any changes made
                updatedEvent.EventType = existingEvent.EventType;                           //Updating the event type if any changes made
                eventDetails.UpdateEvent(updatedEvent);                                          //Updating the database
                TempData["Message"] = "Event updated successfully!!";
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
            eventDetails.DeleteEvent(id);                                                  //Deleting the details from the database
            return RedirectToAction("DisplayEvents");
        }
    }
}