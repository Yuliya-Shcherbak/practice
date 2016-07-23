using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Helper;
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
        public async Task<ActionResult> Favourites()
        {
            List<FavouritesModel> list = await EntityHelper.GetFavourites();
            return View(list);
        }

        //GET /Home/AddFavourite
        public async Task<ActionResult> AddFavourite(string name, int id)
        {
            await EntityHelper.AddFavourite(name, id);
            return RedirectToAction("Favourites"); ;
        }

        //GET /Home/UpdateFavourite
        public async Task<ActionResult> UpdateFavourite(List<FavouritesModel> list)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await EntityHelper.DeleteFavorite(list.Where(x => x.IsDeleted == true).ToList());
                    await EntityHelper.UpdateFavourite(list.Where(x => x.IsDeleted != true).ToList());
                    return RedirectToAction("Favourites");
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "An error occured");
                    return View("Favourites", EntityHelper.GetFavourites());
                }
            }
            return View();
        }

        public async Task<ActionResult> Statistics()
        {
            List<City> list = await EntityHelper.GetCitiesForStatisticList();
            return View(list);
        }

        public async Task<ActionResult> ShowStatistics(int id)
        {
            List<StatisticsModel> list =await EntityHelper.ShowCityStatistics(id);
            return View(list);
        }
    }
}