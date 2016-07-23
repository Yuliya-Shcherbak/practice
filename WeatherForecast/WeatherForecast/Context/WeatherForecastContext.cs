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
        public DbSet<FavouritesModel> Favourites { get; set; }

        public DbSet<StatisticsModel> Statisctics { get; set; }
    }
}