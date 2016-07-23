using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class WeekModel
    {
        public int WeekModelID { get; set; }
        public City city { get; set; }
        [NotMapped]
        public string cod { get; set; }
        [NotMapped]
        public double message { get; set; }
        public int cnt { get; set; }
        public List<WeekList> list { get; set; }
        private IWeekManager weekManager;
            
        public WeekModel(IWeekManager manager)
        {
            weekManager = manager;
        }

        public WeekModel() { }

        public async Task<WeekModel> SearchForecast(int count, string city)
        {
            return await weekManager.GetWeekForecast(count, city);
        }
    }

    public class WeekList
    {
        public int WeekListID { get; set; }
        [NotMapped]
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