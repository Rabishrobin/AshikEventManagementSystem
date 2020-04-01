using OnlineEventManagementSystem.BL;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        public ActionResult SignUp(SignUpModel userModel)
        {
            int? id = AccountBL.VerifyMailId(userModel.UserMailId);
            bool CanAddUser = id!=null;
            if (CanAddUser)
            {
                var user = AutoMapper.Mapper.Map<SignUpModel, Account>(userModel);      //Automapping user details from model to entity 
                user.UserID = Account.GenerateUserID(id.GetValueOrDefault());           //Generating user id
                AccountBL.AddUser(user);                                                //Adding the user details to the database
                return RedirectToAction("Login","Account");                                      //Redirecting to the login page
            }
            else
            {
                ModelState.AddModelError("SignUpError", "User already exist");               //Passing login error to the view
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user = AccountBL.ValidateLogin(model.UserMailId, model.Password);      //Verifying the user mail id and password
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserMailId, false);

                var authTicket = new FormsAuthenticationTicket(1, user.UserMailId, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("LoginError", "Invalid login attempt!!");               //Passing login error to the view
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();          //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Dashboard(Account user)
        {
            return View(user);
        }
    }
}