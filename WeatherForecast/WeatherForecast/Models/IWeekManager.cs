﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public interface IWeekManager
    {
        Task<WeekModel> GetWeekForecast(int count, string city);
    }
}
