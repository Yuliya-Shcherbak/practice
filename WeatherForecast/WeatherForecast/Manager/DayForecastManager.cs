using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using WeatherForecast.Models;
using WeatherForecast.Helper;
using System.Threading.Tasks;
using System.Net.Http;

namespace WeatherForecast.Manager
{
    public class DayForecastManager : IDayManager
    {
        public async Task<DayModel> GetDayForecast(string city)
        {
            string path = "http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&cnt=8&units=metric&APPID=74558106fbbccd5beb5db014a50cfe6a";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(path);
                var response = await client.GetStringAsync(path);
                var result = JsonConvert.DeserializeObject<DayModel>(response);
                foreach (var item in result.list)
                {
                    item.date = Convert.ToDateTime(item.dt_txt);
                }
                await EntityHelper.AddStatistics(ManagersHelper.ConvertDayModel(result));
                return result;
            }            
        }
    }
}