using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class WeekModel
    {
        public City city { get; set; }
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

    public class WeekList
    {

        public int dt { get; set; }
        public DateTime date { get; set; }
        public Temp temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public List<Weather> weather { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public int clouds { get; set; }
        public double? rain { get; set; }
        public double? snow { get; set; }
    }
}