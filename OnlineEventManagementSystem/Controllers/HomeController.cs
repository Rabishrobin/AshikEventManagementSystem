using OnlineEventManagementSystem.Models;
using System;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    [CustomExceptionFilter]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult Event()
        {
            //IEnumerable<Event> events= EventBL.DisplayEvents();                  //Getting the events from the database as object
            //ViewBag.Events = events;                                            //Passing the list from the controller to view using viewbag
            return View();
        }
        public ViewResult Service()
        {
            //IEnumerable<Service> services = ServiceBL.DisplayServices();             //Getting the services from the database as object
            //ViewBag.Services = services;                                            //Passing the list from the controller to view using viewbag
            return View();
        }
        public ViewResult Gallery()
        {
            return View();
        }
    }
}