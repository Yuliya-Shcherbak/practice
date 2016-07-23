using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using WeatherForecast.Context;
using WeatherForecast.Models;

namespace WeatherForecast.Helper
{
    public class EntityHelper
    {
        public static async Task AddStatistics(List<StatisticsModel> model)
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                foreach (var _model in model)
                {
                    context.Statisctics.Add(_model);
                    await context.SaveChangesAsync();
                }
            }
        }


        public static async Task<List<City>> GetCitiesForStatisticList()
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                var list = await context.Statisctics.GroupBy(x => x.CityID).ToListAsync() ;
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

        public static async Task<List<StatisticsModel>> ShowCityStatistics(int id)
        {
            List<StatisticsModel> list = new List<StatisticsModel>();
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                var result = await context.Statisctics.Where(x => x.CityID == id).Select(x => x).ToListAsync();
                foreach (var item in result)
                {
                    list.Add(item);
                }
                return list;
            }
        }
        

        public static async Task<List<FavouritesModel>> GetFavourites()
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                var result = await context.Favourites.ToListAsync();
                return result;
            }
        }

        public static async Task AddFavourite(string name, int id)
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
                await context.SaveChangesAsync();
            }
        }

        public static async Task DeleteFavorite(List<FavouritesModel> list)
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                foreach (var city in list)
                {
                    FavouritesModel _city = await context.Favourites.SingleOrDefaultAsync(x => x.ID == city.ID);
                    context.Favourites.Remove(_city);
                    await context.SaveChangesAsync();
                }
            }
        }

        public static async Task UpdateFavourite(List<FavouritesModel> list)
        {
            using (WeatherForecastContext context = new WeatherForecastContext())
            {
                foreach (var city in list)
                {
                    var fav = await context.Favourites.Where(x => x.ID == city.ID).SingleOrDefaultAsync();
                    if (city.Name != null)
                        fav.Name = city.Name;
                }
                await context.SaveChangesAsync();
            }
        }
    }
}