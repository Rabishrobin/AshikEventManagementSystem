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
            IEnumerable<Service> services = ServiceBL.DisplayServices();                        //Getting the services from the database
            ViewBag.Services = services;                                                        //Passing them to the view using view bag
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
            Service service = ServiceBL.GetServiceById(serviceId);                             //Getting the service details from database
            ServiceModel serviceModel = AutoMapper.Mapper.Map<Service, ServiceModel>(service);    //Mapping the service to the model to show the existing details
            return View(serviceModel);
        }
        [HttpPost]
        public ActionResult UpdateService([Bind(Include ="ServiceId, ServiceName, ServiceCategory, EventType")] ServiceModel serviceModel)
        {
            Service service = ServiceBL.GetServiceById(serviceModel.ServiceId);           //Getting the objecct of the service by using the event id from the database
            service.ServiceName = serviceModel.ServiceName;                           //Updating the service name if any changes made
            service.ServiceCategory = serviceModel.ServiceCategory;                           //Updating the service category if any changes made
            service.EventType = serviceModel.EventType;                           //Updating the event type if any changes made
            ServiceBL.UpdateService(service);                                          //Updating the database
            TempData["Message"] = "Service updated";
            return View();
        }
        [HttpGet]
        public ViewResult DeleteService(string serviceId)
        {
            ServiceBL.DeleteService(serviceId);
            //TempData["Message"] = "Service deleted";
            return View();
        }
    }
}