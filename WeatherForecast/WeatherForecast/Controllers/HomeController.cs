using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        //GET: /Home/Index
        public ActionResult Index()
        {
            return View();
        }
        //GET: /Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //GET: /Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Redirect(int count, string city)
        {
            switch (count)
            {
                case 8:
                    return RedirectToAction("SearchForecast", "DayForecast", new { city = city });
                case 3:
                    return RedirectToAction("SearchForecast", "WeekForecast", new { count = 3, city = city });
                case 7: return RedirectToAction("SearchForecast", "WeekForecast", new { count = 7, city = city });
                default: return RedirectToAction("Index");
                    
            }
        }
    }
}