using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        [HttpGet]
        public ViewResult DisplaySerivces()
        {
            IEnumerable<Service> services = ServiceBL.DisplayServices();                        //Getting the services from the database

            ViewBag.Services = services;                                                        //Passing them to the view using view bag
            return View();
        }
        [HttpGet]
        public ViewResult AddService()
        {
            IEnumerable<ServiceCategory> categories = ServiceCategoryBL.DisplayCategory();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult AddService(ServiceModel newService)
        {
            if (ModelState.IsValid)
            {
                int? id = ServiceBL.VerifyService(newService.ServiceName);
                bool CanAddService = id != null;
                if (CanAddService)
                {
                    var service = AutoMapper.Mapper.Map<ServiceModel, Service>(newService);      //Automapping service details from model to entity
                    service.ServiceID = Service.GenerateServiceID(id.GetValueOrDefault());
                    ServiceBL.AddService(service);                                                //Adding the service to the database
                    return RedirectToAction("DisplayServices");                           //Redirecting after adding the service
                }
                TempData["Message"] = "Service already exists";
            }
            return View();
        }
        [HttpGet]
        public ViewResult UpdateService(int serviceId)
        {
            Service service = ServiceBL.GetServiceById(serviceId);                             //Getting the service details from database
            ServiceModel serviceModel = AutoMapper.Mapper.Map<Service, ServiceModel>(service);    //Mapping the service to the model to show the existing details
            return View(serviceModel);
        }
        [HttpPost]
        public ActionResult UpdateService([Bind(Include ="ServiceId, ServiceName, ServiceCategory, EventType")] ServiceModel serviceModel)
        {
            Service service = ServiceBL.GetServiceById(serviceModel.ServiceId);           //Getting the objecct of the service by using the service id from the database
            service.ServiceName = serviceModel.ServiceName;                           //Updating the service name if any changes made
            service.CategoryID = serviceModel.CategoryID;                           //Updating the service category if any changes made
            service.EventType = serviceModel.EventType;                           //Updating the event type if any changes made
            ServiceBL.UpdateService(service);                                          //Updating the database
            TempData["Message"] = "Service updated";
            return View();
        }
        [HttpGet]
        public ViewResult DeleteService(int serviceId)
        {
            ServiceBL.DeleteService(serviceId);
            //TempData["Message"] = "Service deleted";
            return View();
        }
    }
}