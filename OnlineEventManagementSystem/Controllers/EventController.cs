using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
  
    public class EventController : Controller
    {
        [HttpGet]
        public ViewResult DispalyEvents()
        {
            IEnumerable<Event> events = EventBL.DisplayEvents();
            ViewBag.Events = events;
            return View();
        }
        [HttpGet]
        public ViewResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(EventModel newEvent)
        {
            if (ModelState.IsValid)
            {
                var addEvent = AutoMapper.Mapper.Map<EventModel, Event>(newEvent);      //Automapping event details from model to entity
                if (EventBL.VerifyEvent(addEvent.EventID))                              //Verifying the existance of event
                {
                    EventBL.AddEvent(addEvent);                                                //Adding the service to the database
                    return RedirectToAction("DispalyEvents");
                }
                TempData["Message"] = "Event already exists";
            }
            return View();
        }
        [HttpGet]
        public ViewResult UpdateEvent()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult UpdateEvent()
        //{
        //    return View();
        //}
        [HttpGet]
        public ViewResult DeleteEvent(string eventId)
        {

            return View();
        }
    }
}