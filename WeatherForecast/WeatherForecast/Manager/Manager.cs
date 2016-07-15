using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecast.Models;
using WeatherForecast.Context;

namespace WeatherForecast.Manager
{
    public class Manager
    {
        public static WeekModel ConvertModel(DayModel dayModel)
        {
            List<WeekList> _list = new List<WeekList>();

            foreach (var item in dayModel.list)
            {
                Temp _temp = new Temp()
                {
                    max = item.main.temp_max,
                    min = item.main.temp_min,
                    day = item.main.temp,
                    eve = 0,
                    morn = 0,
                    night = 0
                };
                _list.Add(new WeekList()
                {
                    date = item.date,
                    temp = _temp,
                    pressure = item.main.pressure,
                    humidity = item.main.humidity,
                    weather = item.weather,
                    speed = item.wind.speed,
                    deg = (int)item.wind.deg,
                    clouds = item.clouds.all,
                    rain = (item.rain != null) ? item.rain.rain : 0,
                    snow = (item.snow != null) ? item.snow.snow : 0
                });
            }
            WeekModel weekModel = new WeekModel()
            {
                city = dayModel.city,
                list = _list
            };
            return weekModel;
        }

        public static List<City> GetCitiesForStatistic()
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                IQueryable<IGrouping<int, WeatherForecast.Models.City>> list = context.Statisctics.Select(x => x.city).GroupBy(x => x.id);
                IEnumerable<City> temp = list.SelectMany(group => group);
                List<City> cities = temp.ToList();
                return cities;
            }
        }

        public static List<WeekModel> ShowCityStatistics(int id)
        {
            List<WeekModel> list = new List<WeekModel>();
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                var result = context.Statisctics
                    .Include("list")
                    .Include("city")
                    .Include("list.temp")
                    .Include("list.weather")
                    .Where(x => x.city.id == id).Select(x => x).ToList();
                foreach (var item in result)
                {
                    list.Add(item);
                }
                return list;
            }
        }
        public static void AddStatistics(WeekModel model)
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                context.Statisctics.Add(model);
                context.SaveChanges();
            }
        }

        public static List<Favourite> GetFavourites()
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                var result = context.Favourites.ToList();
                return result;
            }
        }

        public static void AddFavourite(string name, int id)
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                Favourite city = new Favourite()
                {
                    ID = id,
                    Name = name,
                    IsDeleted = false
                };
                context.Favourites.Add(city);
                context.SaveChanges();
            }
        }

        public static void DeleteFavorite(List<Favourite> list)
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                foreach (var city in list)
                {
                    Favourite _city = context.Favourites.Where(x => x.ID == city.ID).SingleOrDefault();
                    context.Favourites.Remove(_city);
                    context.SaveChanges();
                }
            }
        }

        public static void UpdateFavourite(List<Favourite> list)
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                foreach (var city in list)
                {
                    var fav = context.Favourites.Where(x => x.ID == city.ID).SingleOrDefault();
                    if (city.Name != null)
                        fav.Name = city.Name;
                }
                context.SaveChanges();
            }
        }
    }
}