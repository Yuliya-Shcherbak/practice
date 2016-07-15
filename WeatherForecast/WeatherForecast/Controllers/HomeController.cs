using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Models;


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

        //GET /Home/Favourites
        public ActionResult Favourites()
        {
            List<Favourite> list = Manager.Manager.GetFavourites();
            return View(list);
        }

        //GET /Home/AddFavourite
        public ActionResult AddFavourite(string name, int id)
        {
            Manager.Manager.AddFavourite(name, id);
            return RedirectToAction("Favourites"); ;
        }

        //GET /Home/UpdateFavourite
        public ActionResult UpdateFavourite(List<Favourite> list)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Manager.Manager.DeleteFavorite(list.Where(x => x.IsDeleted == true).ToList());
                    Manager.Manager.UpdateFavourite(list.Where(x => x.IsDeleted != true).ToList());
                    return RedirectToAction("Favourites");
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "An error occured");
                    return View("Favourites", Manager.Manager.GetFavourites());
                }
            }
            return View();
        }

        public ActionResult Statistics()
        {
            List<City> list = Manager.Manager.GetCitiesForStatistic();
            return View(list);
        }

        public ActionResult ShowStatistics(int id)
        {
            List<WeekModel> list = Manager.Manager.ShowCityStatistics(id);
            return View(list);
        }
    }
}