using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ViewResult Index()
        {
            return View();
        }
        public ActionResult DisplayCustomers()
        {
            IEnumerable<Account> customers = AccountBL.DisplayCustomers();                        //Getting the customer details from the database
            ViewBag.Customers = customers;
            return View();
        }
    }
}