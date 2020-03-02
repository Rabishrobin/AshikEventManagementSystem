using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: User
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
                Account user = new Account();
                user.UserID = user.GenerateUserID(users.UserFirstName, users.UserMobileNumber);
                user.UserFirstName = users.UserFirstName;
                user.UserLastName = users.UserLastName;
                user.UserMailId = users.UserMailId;
                user.UserMobileNumber = users.UserMobileNumber;
                user.UserGender = users.UserGender;
                user.UserDOB = users.UserDOB.Date;
                user.UserPassword = users.UserPassword;
                AccountBL.AddUser(user);
                return RedirectToAction("SignIn");
            }

            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel user)
        {
            string mail_Id = user.UserMailId;
            string password = user.Password;
            if (AccountBL.ValidateLogIn(mail_Id, password)==null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}