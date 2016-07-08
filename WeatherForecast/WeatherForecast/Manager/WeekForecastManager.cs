using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using WeatherForecast.Models;

namespace WeatherForecast.Manager
{
    public class WeekForecastManager
    {
        public static WeekModel GetWeekForecast(int count, string city)
        {
            string path = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + city + "&cnt=" + count + "&units=metric&APPID=74558106fbbccd5beb5db014a50cfe6a";
            WeekModel result = new WeekModel();
            WebRequest request = (HttpWebRequest)WebRequest.Create(path);

            using (WebResponse response = request.GetResponse())
            using (System.IO.StreamReader rd = new System.IO.StreamReader(response.GetResponseStream()))
            {
                string answer = rd.ReadToEnd();                
                result = JsonConvert.DeserializeObject<WeekModel>(answer);
                foreach(var item in result.list)
                {
                    item.date = new DateTime(1970, 1, 1).AddSeconds(item.dt);
                }
            }
            return result;
        }
    }
}