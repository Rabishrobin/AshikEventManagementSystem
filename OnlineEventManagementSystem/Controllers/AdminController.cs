using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.BL.Interface;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        IAccountBL accountBL;
        public AdminController()
        {
            accountBL = new AccountBL();
        }
        [HttpGet]
        public ViewResult DisplayCustomers()
        {
            IEnumerable<Account> customers = accountBL.GetCustomerList();                        //Getting the customer details from the database
            ViewBag.Customers = customers;
            return View();
        }
    }
}