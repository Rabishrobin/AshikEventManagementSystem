using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    public class ServiceController : Controller
    {
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(ServiceModel newService)
        {
            if (ModelState.IsValid)
            {
                var addService = AutoMapper.Mapper.Map<ServiceModel, Service>(newService);      //Automapping service details from model to entity 
                ServiceBL.AddService(addService);                                                //Adding the service to the database
            }
            return View();
        }
    }
}