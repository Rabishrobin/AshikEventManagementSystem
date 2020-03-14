using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    public class ServiceController : Controller
    {
        [HttpGet]
        public ViewResult DisplaySerivce()
        {
            IEnumerable<Service> services = ServiceBL.DisplayServices();
            ViewBag.Services = services;
            return View();
        }
        [HttpGet]
        public ViewResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(ServiceModel newService)
        {
            if (ModelState.IsValid)
            {
                var addService = AutoMapper.Mapper.Map<ServiceModel, Service>(newService);      //Automapping service details from model to entity 
                if (ServiceBL.VerifyService(addService.ServiceID))
                {
                    ServiceBL.AddService(addService);                                                //Adding the service to the database
                    return RedirectToAction("DisplaySerivce");
                }
                TempData["Message"] = "Service already exists";
            }
            return View();
        }
        [HttpGet]
        public ViewResult UpdateService(string serviceId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateService()
        {
            return View();
        }
        [HttpGet]
        public ViewResult DeleteService(string serviceId)
        {
            ServiceBL.DeleteService(serviceId);
            TempData["Message"] = "Service deleted";
            return View();
        }
    }
}