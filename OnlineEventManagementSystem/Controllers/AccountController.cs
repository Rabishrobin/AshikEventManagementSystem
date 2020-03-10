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
                var user = AutoMapper.Mapper.Map<SignUpViewModel, Account>(users);      //Automapping user details from model to entity 
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
            var account = AccountBL.ValidateLogIn(user.UserMailId, user.Password);
            if (account!=null)
            {
                return RedirectToAction("Dashboard",account);
            }
            return View();
        }

        public ActionResult Dashboard(Account user)
        {
            return View(user);
        }
    }
}