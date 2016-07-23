using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using WeatherForecast.Models;
using WeatherForecast.Helper;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecast.Manager
{
    public class WeekForecastManager : IWeekManager
    {
        public async Task<WeekModel> GetWeekForecast(int count, string city)
        {
            string path = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + city + "&cnt=" + count + "&units=metric&APPID=74558106fbbccd5beb5db014a50cfe6a";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(path);
                var response = await client.GetStringAsync(path);
                var result = JsonConvert.DeserializeObject<WeekModel>(response);                
                foreach(var item in result.list)
                {
                    item.date = new DateTime(1970, 1, 1).AddSeconds(item.dt);
                }
                await EntityHelper.AddStatistics(ManagersHelper.ConvertWeekModel(result));
                return result;
            }            
        }
    }
}