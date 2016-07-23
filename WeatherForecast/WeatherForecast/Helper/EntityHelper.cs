using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecast.Context;
using WeatherForecast.Models;

namespace WeatherForecast.Helper
{
    public class EntityHelper
    {
        public static void AddStatistics(List<StatisticsModel> model)
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                foreach (var _model in model)
                {
                    context.Statisctics.Add(_model);
                    context.SaveChanges();
                }
            }
        }


        public static List<City> GetCitiesForStatisticList()
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                var list = context.Statisctics.GroupBy(x => x.CityID).ToList() ;
                IEnumerable<StatisticsModel> temp = list.Select(x => x.First());
                List<City> cities = new List<City>();
                foreach (StatisticsModel _model in temp)
                {
                    
                    cities.Add(new City
                        {
                            id = _model.CityID,
                            name = _model.name
                        });
                }
                return cities;
            }
        }

        public static List<StatisticsModel> ShowCityStatistics(int id)
        {
            List<StatisticsModel> list = new List<StatisticsModel>();
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                var result = context.Statisctics.Where(x => x.CityID == id).Select(x => x).ToList();
                foreach (var item in result)
                {
                    list.Add(item);
                }
                return list;
            }
        }
        

        public static List<FavouritesModel> GetFavourites()
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
                FavouritesModel city = new FavouritesModel()
                {
                    ID = id,
                    Name = name,
                    IsDeleted = false
                };
                context.Favourites.Add(city);
                context.SaveChanges();
            }
        }

        public static void DeleteFavorite(List<FavouritesModel> list)
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                foreach (var city in list)
                {
                    FavouritesModel _city = context.Favourites.SingleOrDefault(x => x.ID == city.ID);
                    context.Favourites.Remove(_city);
                    context.SaveChanges();
                }
            }
        }

        public static void UpdateFavourite(List<FavouritesModel> list)
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