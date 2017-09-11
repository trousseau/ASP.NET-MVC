using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETMVCAjax.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetCurrentDateTime()
        {
            System.Threading.Thread.Sleep(3000);
            return PartialView();
        }

        public ActionResult JsonDemo()
        {
            return View();
        }

        private static string[] _makes = new string[] {
                "Acura",
                "Alfa Romeo",
                "Aston Martin",
                "Audi",
                "Bentley",
                "BMW",
                "Buick",
                "Cadillac",
                "Chevrolet",
                "Chrysler",
                "Dodge",
                "Ferrari",
                "FIAT",
                "Ford",
                "Freightliner",
                "Genesis",
                "GMC",
                "Honda",
                "Hyundai",
                "Infiniti",
                "Jaguar",
                "Jeep",
                "Kia",
                "Lamborghini",
                "Land Rover",
                "Lexus",
                "Lincoln",
                "Maserati",
                "Mazda",
                "McLaren",
                "Mercedes-Benz",
                "MINI",
                "Mitsubishi",
                "Nissan",
                "Porsche",
                "Ram",
                "Rolls-Royce",
                "Scion",
                "smart",
                "Subaru",
                "Tesla",
                "Toyota",
                "Volkswagen",
                "Volvo"
        };

        public JsonResult Make(string term)
        {
            return Json(_makes.Where(x => x.ToLower().Contains(term)).ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}