using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMVC.Models;


namespace ASPNETMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.Greeting = "Hello, world!";
            var list = Session["Employees"] as List<EmployeeInfo>;
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeInfo e)
        {
            var list = Session["Employees"] as List<EmployeeInfo>;
            if (list == null)
            {
                list = new List<EmployeeInfo>();
            }
            list.Add(e);
            Session["Employees"] = list;

            return RedirectToAction("Index");
        }

    }
}