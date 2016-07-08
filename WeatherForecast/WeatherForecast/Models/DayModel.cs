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
        public DayCity city { get; set; }
        public int cnt { get; set; }
        public List<DayList> list { get; set; }        
    }

    public class DayCity
    {
        public int id { get; set; }
        public string name { get; set; }
        public DayCoord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public Sys sys { get; set; }
    }
    public class DayCoord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class DayList
    {
        public int dt { get; set; }
        public DateTime date { get; set; }
        public DayMain main { get; set; }
        public List<DayWeather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public SnowInfo snow { get; set; }
        public Sys2 sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class DayMain
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class DayWeather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }
    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }
    public class Rain
    {
        public double rain { get; set; }
    }
    public class SnowInfo
    {
        public double snow { get; set; }
    }

    public class Sys
    {
        public int population { get; set; }
    }
    public class Sys2
    {
        public string pod { get; set; }
    }
}