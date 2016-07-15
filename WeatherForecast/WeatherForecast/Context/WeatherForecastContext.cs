using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WeatherForecast.Models;

namespace WeatherForecast.Context
{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Favourite> Favourites { get; set; }

        public DbSet<WeekModel> Statisctics { get; set; }
        public DbSet<WeekList> Lists { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Temp> Temperatures { get; set; }
        public DbSet<Weather> Weathers { get; set; }
    }
}