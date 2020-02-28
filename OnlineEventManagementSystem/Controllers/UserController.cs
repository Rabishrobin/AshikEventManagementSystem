using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpViewModel users)
        {
            if (ModelState.IsValid)
            {
                UserManager user = new UserManager();
                user.UserID = user.GenerateUserID(users.UserFirstName, users.UserMobileNumber);
                user.UserFirstName = users.UserFirstName;
                user.UserLastName = users.UserLastName;
                user.UserMailId = users.UserMailId;
                user.UserMobileNumber = users.UserMobileNumber;
                user.UserGender = users.UserGender;
                user.UserPassword = users.UserPassword;
                Account.AddUser(user);
                return RedirectToAction("SignIn");
            }

            return View();
        }
        public ActionResult SignIn(FormCollection form)
        {
            string mail_Id = Request.Form["Mail_ID"];
            string password = Request.Form["Password"];
            return View();
        }
    }
}