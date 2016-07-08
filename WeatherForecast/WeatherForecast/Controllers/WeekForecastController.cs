﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Manager;

namespace WeatherForecast.Controllers
{
    public class WeekForecastController : Controller
    {

        // GET: /WeekForecast/Index
        public ActionResult Index()
        {
            return View();
        }

        //GET: /WeekForecast/SearchForecast
        public ActionResult SearchForecast(string city, int count)
        {
            WeekModel list = WeekForecastManager.GetWeekForecast(count, city);
            return View(list); 
        }
    }
}