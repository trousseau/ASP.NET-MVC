using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVCRouting.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Route("WeatherForecast/{zip:int:length(5)}")]
        public string Weather(string zip)
        {
            return "Weather forecast for " + zip;
        }
    }
}