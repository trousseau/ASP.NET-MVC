using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVCRouting.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index(int year, int month, string day)
        {
            ViewBag.Year = year.ToString();
            ViewBag.Month = month.ToString();
            ViewBag.Day = day;
            return View();
        }
    }
}