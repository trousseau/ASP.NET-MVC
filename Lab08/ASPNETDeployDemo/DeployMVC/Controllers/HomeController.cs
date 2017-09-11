using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeployMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int i;
            long j = 25l;
            double x = 0;
            switch ("test")
            {
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}