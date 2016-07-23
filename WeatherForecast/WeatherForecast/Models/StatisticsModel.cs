using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class StatisticsModel
    {
        [Key]
        public int StatisticsModelID { get; set; }
        public int CityID { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double windSpeed { get; set; }
        public double windDirection { get; set; }
        public int cloudiness { get; set; }
        public double? rain { get; set; }
        public double? snow { get; set; }
    }
}