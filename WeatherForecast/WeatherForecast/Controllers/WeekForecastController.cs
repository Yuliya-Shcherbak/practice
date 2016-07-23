using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Manager;
using System.Threading.Tasks;

namespace WeatherForecast.Controllers
{
    public class WeekForecastController : Controller
    {
        private IWeekManager weekManager;

        public WeekForecastController(IWeekManager manager)
        {
            weekManager = manager;
        }

        // GET: /WeekForecast/Index
        public ActionResult Index()
        {
            return View();
        }

        //GET: /WeekForecast/SearchForecast
        public async Task<ActionResult> SearchForecast(string city, int count)
        {
            WeekModel list = new WeekModel(weekManager);
            return View(await list.SearchForecast(count, city)); 
        }
    }
}