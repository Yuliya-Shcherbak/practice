using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using WeatherForecast.Models;
using WeatherForecast.Helper;

namespace WeatherForecast.Manager
{
    public class DayForecastManager : IDayManager
    {
        public DayModel GetDayForecast(string city)
        {
            string path = "http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&cnt=8&units=metric&APPID=74558106fbbccd5beb5db014a50cfe6a";
            
            WebRequest request = (HttpWebRequest)WebRequest.Create(path);

            using (WebResponse response = request.GetResponse())
            using (System.IO.StreamReader rd = new System.IO.StreamReader(response.GetResponseStream()))
            {
                var result = JsonConvert.DeserializeObject<DayModel>(rd.ReadToEnd());
                foreach (var item in result.list)
                {
                    item.date = Convert.ToDateTime(item.dt_txt);
                }
                EntityHelper.AddStatistics(ManagersHelper.ConvertDayModel(result));
                return result;
            }            
        }
    }
}