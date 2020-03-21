using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HqFilling.Helper;
using HqFilling.Model;
using HqFilling.Security;
using HqFilling.Security.Models;
using HqFilling.Biz;

namespace HqFilling.Controllers
{
    public class LoginController : Controller
    {
        private IMembershipService _MembershipService;
        private HqFormsAuthenticationService _HqFormsAuthenticationService;

        public LoginController()
        {
            _MembershipService = new HqFacadeBiz();
            _HqFormsAuthenticationService = new HqFormsAuthenticationService(_MembershipService);
        }

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            try
            {
                AuthStatus authStatus = _HqFormsAuthenticationService.SignIn(login.UserName, login.Password, false);
                if (authStatus.Code == AuthStatusCode.SUCCESS)
                {
                    List<UserModel> userModelList = new List<UserModel>() { authStatus.Data as UserModel };
                    ViewBag.UserName = login.UserName;
                    ViewBag.Password = login.Password;

                    SessionVars.CurrentLoggedInUser = (UserModel)authStatus.Data;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            catch (Exception)
            {
                //Elmah.ErrorSignal.FromCurrentContext();
            }
            // If we got this far, something failed, redisplay form
            return View(login);
        }

        public ActionResult Logout()
        {
            _HqFormsAuthenticationService.SignOut();
            return RedirectToAction("Login");
        }        
    }
}
