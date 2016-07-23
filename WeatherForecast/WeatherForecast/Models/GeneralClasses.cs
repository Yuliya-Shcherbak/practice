using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        [NotMapped]
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        [NotMapped]
        public Sys sys { get; set; }
    }
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Main
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

    public class Temp
    {
        public int TempID { get; set; }
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class Weather
    {
         [Key]
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
    public class Snow
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