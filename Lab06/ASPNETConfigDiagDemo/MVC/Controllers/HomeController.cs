using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string email = ConfigurationManager.AppSettings["NotificationEmail"];
            bool enabled = Convert.ToBoolean(ConfigurationManager.AppSettings["NotificationEnabled"]);
            System.Drawing.Color c = MVC.Properties.Settings.Default.NotifyColor;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            HttpContext.Trace.Write("This is a sample trace message");
            HttpContext.Trace.Warn("This is a sample warning message");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            HttpContext.Trace.IsEnabled = false;

            return View();
        }
    }
}