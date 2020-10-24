using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.BL.Interface;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        IServiceBL serviceDetails;
        IServiceCategoryBL categoryDetails;
        public ServiceController()
        {
            serviceDetails = new ServiceBL();
            categoryDetails = new ServiceCategoryBL();
        }

        [HttpGet]
        public ViewResult DisplayServices()
        {
            IEnumerable<Service> services = serviceDetails.GetServiceList();                        //Getting the services from the database
            ViewBag.Services = services;                                                        //Passing them to the view using view bag
            return View();
        }

        [HttpGet]
        public ViewResult AddService()
        {
            IEnumerable<ServiceCategory> categories = categoryDetails.GetCategoryList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddService(ServiceModel newService)
        {
            if (ModelState.IsValid)
            {
                bool CanAddService = serviceDetails.VerifyService(newService.ServiceName);
                if (CanAddService)
                {
                    var service = AutoMapper.Mapper.Map<ServiceModel, Service>(newService);      //Automapping service details from model to entity
                    serviceDetails.AddService(service);                                                //Adding the service to the database
                    return RedirectToAction("DisplayServices");                           //Redirecting after adding the service
                }
                TempData["Message"] = "Service already exists!!";
            }
            return View();
        }

        [HttpGet]
        public ViewResult UpdateService(int id)
        {
            IEnumerable<ServiceCategory> categories = categoryDetails.GetCategoryList();
            ViewBag.Categories = categories;
            Service service = serviceDetails.GetServiceById(id);                             //Getting the service details from database
            ServiceModel serviceModel = AutoMapper.Mapper.Map<Service, ServiceModel>(service);    //Mapping the service to the model to show the existing details
            return View(serviceModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateService([Bind(Include ="ServiceId, ServiceName, ServiceCategory, EventType")] ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                Service service = serviceDetails.GetServiceById(serviceModel.ServiceId);           //Getting the objecct of the service by using the service id from the database
                service.ServiceName = serviceModel.ServiceName;                           //Updating the service name if any changes made
                service.CategoryID = serviceModel.CategoryID;                           //Updating the service category if any changes made
                service.EventType = serviceModel.EventType;                           //Updating the event type if any changes made
                serviceDetails.UpdateService(service);                                          //Updating the database
                TempData["Message"] = "Service updated successfully!!";
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteService(int id)
        {
            serviceDetails.DeleteService(id);
            return RedirectToAction("DisplayServices");
        }
    }
}