using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class DayModel
    {
        public string cod { get; set; }     
        public double message { get; set; }
        public City city { get; set; }
        public int cnt { get; set; }
        public List<DayList> list { get; set; }
        private IDayManager dayManager;

        public DayModel(IDayManager model)
        {
            dayManager = model;
        }

        public DayModel SearchForecast(string city)
        {
            return dayManager.GetDayForecast(city);
        }
    }
    public class DayList
    {
        public int dt { get; set; }
        public DateTime date { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys2 sys { get; set; }
        public string dt_txt { get; set; }
        public Rain rain { get; set; }
        public Snow snow { get; set; }
    }
}