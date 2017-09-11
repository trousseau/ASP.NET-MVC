using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMVCForm.Models;

namespace ASPNETMVCForm.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        private SelectListItem[] GetDepartments()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Accounting",
                Value = "101",
                Selected = true
            });
            list.Add(new SelectListItem()
            {
                Text = "Human Resources",
                Value = "105"
            });
            list.Add(new SelectListItem()
            {
                Text = "Information Technology",
                Value = "110"
            });
            list.Add(new SelectListItem()
            {
                Text = "Executive",
                Value = "115"
            });
            return list.ToArray();
        }

        public ActionResult Create()
        {
            ViewData["Departments"] = GetDepartments();
            return View(new Models.EmployeeInfo());
        }

        [HttpPost]
        public ActionResult Create(EmployeeInfo e)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SaveEmployeeToDatabase(e);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewData["Departments"] = GetDepartments();
            return View(e);
        }

        private void SaveEmployeeToDatabase(EmployeeInfo e)
        {
            throw new ApplicationException("Could not save employee to database");
        }
    }
}