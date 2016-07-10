using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public interface IDayManager
    {
        DayModel GetDayForecast(string city);
    }
}
