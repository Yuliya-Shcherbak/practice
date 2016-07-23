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
    public class DayForecastController : AsyncController
    {
        private IDayManager dayManager;

        public DayForecastController(IDayManager manager)
        {
            dayManager = manager;
        }

        // GET: /DayForecast/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: /DayForecast/SearchForecast
        public async Task<ActionResult> SearchForecast(string city)
        {
            DayModel list = new DayModel(dayManager);
            return View(await list.SearchForecast(city));
        }
    }
}