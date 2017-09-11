using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace IdentityMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(FormCollection frm)
        {
            if (frm["Password1"] != frm["Password2"])
            {
                ViewBag.StatusMessage = "Passwords do not match";
            }
            else
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = new IdentityUser() { UserName = frm["EmailAddress"] };
                IdentityResult result = userManager.Create(user, frm["Password1"]);

                if (result.Succeeded)
                {
                    ViewBag.StatusMessage = string.Format("User '{0}' was created successfully", user.UserName);
                }
                else
                {
                    ViewBag.StatusMessage = result.Errors.FirstOrDefault();
                }
            }

            return View();
        }

        public ActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                ViewBag.Authenticated = true;
                ViewBag.Greeting = string.Format("Welcome, {0}!", this.User.Identity.GetUserName());
            }
            else
            {
                ViewBag.Authenticated = false;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var authMgr = HttpContext.GetOwinContext().Authentication;
                authMgr.SignOut();
                ViewBag.Authenticated = false;
            }
            else
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = userManager.Find(frm["UserName"], frm["Password"]);

                if (user != null)
                {
                    var authMgr = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authMgr.SignIn(new AuthenticationProperties() { IsPersistent = true }, userIdentity);
                    var returnUrl = Request.QueryString["ReturnUrl"];
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    ViewBag.Authenticated = true;
                    ViewBag.Greeting = string.Format("Welcome, {0}!", frm["UserName"]);
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid username or password.";
                    ViewBag.Authenticated = false;
                }
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyAccount()
        {
            return View();
        }
    }
}