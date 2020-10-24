using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.BL.Interface;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PackageController : Controller
    {
        IPackageBL packageDetails;
        IEventBL eventDetails;
        IServiceBL serviceDetails;
        public PackageController()
        {
            packageDetails = new PackageBL();
            eventDetails = new EventBL();
            serviceDetails = new ServiceBL();
        }

        [HttpGet]
        public ViewResult DisplayPackage()
        {
            IEnumerable<Package> package = packageDetails.GetPackageList();                        //Getting the packages from the database
            ViewBag.Packages = package;                                                        //Passing them to the view using view bag
            return View();
        }

        [HttpGet]
        public ViewResult AddPackage()
        {
            IEnumerable<Event> events = eventDetails.GetEventList();
            IEnumerable<Service> services = serviceDetails.GetServiceList();
            ViewBag.Events = events;
            ViewBag.Services = services;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPackage(PackageModel newPackage)
        {
            if (ModelState.IsValid)
            {
                bool CanAddPackage = packageDetails.VerifyPackage(newPackage.PackageName);
                if (CanAddPackage)
                {
                    var package = AutoMapper.Mapper.Map<PackageModel, Package>(newPackage);      //Automapping package details from model to entity
                    packageDetails.AddPackage(package);                                                //Adding the package to the database
                    return RedirectToAction("DisplayPackages");                           //Redirecting after adding the package
                }
                TempData["Message"] = "Package already exists!!";
            }
            return View();
        }

        [HttpGet]
        public ViewResult UpdatePackage(int id)
        {
            IEnumerable<Event> events = eventDetails.GetEventList();
            ViewBag.Events = events;
            IEnumerable<Service> services = serviceDetails.GetServiceList();
            ViewBag.Services = services;
            Package package = packageDetails.GetPackageById(id);                             //Getting the package details from database
            PackageModel packageModel = AutoMapper.Mapper.Map<Package, PackageModel>(package);    //Mapping the package to the model to show the existing details
            return View(packageModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePackage([Bind(Include = "PackageId, PackageName, EventName, ServiceName")] PackageModel packageModel)
        {
            if (ModelState.IsValid)
            {
                Package package = packageDetails.GetPackageById(packageModel.PackageId);           //Getting the objecct of the package by using the package id from the database
                package.PackageName = packageModel.PackageName;                           //Updating the package name if any changes made
                package.EventID = packageModel.EventID;                           //Updating the event id if any changes made
                package.SerivceID = packageModel.ServiceID;                           //Updating the serviuce id if any changes made
                packageDetails.UpdatePackage(package);                                          //Updating the database
                TempData["Message"] = "Package updated successfully!!";
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeletePackage(int id)
        {
            packageDetails.DeletePackage(id);
            return RedirectToAction("DisplayPackage");
        }
    }
}