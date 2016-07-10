using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class WeekModel
    {
        public WeekCity city { get; set; }
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<WeekList> list { get; set; }
        private IWeekManager weekManager;

        public WeekModel(IWeekManager manager)
        {
            weekManager = manager;
        }

        public WeekModel SearchForecast(int count, string city)
        {
            return weekManager.GetWeekForecast(count, city);
        }
    }

    public class WeekCity
    {
        public int id { get; set; }
        public string name { get; set; }
        public WeekCoord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }
    public class WeekCoord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class WeekList
    {
        public int dt { get; set; }
        public DateTime date { get; set; }
        public WeekTemp temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public List<WeekWeather> weather { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public int clouds { get; set; }
        public double rain { get; set; }
        public double snow { get; set; }
    }

    public class WeekTemp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class WeekWeather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}