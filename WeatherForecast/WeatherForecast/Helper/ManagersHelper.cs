using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecast.Models;

namespace WeatherForecast.Helper
{
    public class ManagersHelper
    {
        public static List<StatisticsModel> ConvertDayModel(DayModel dayModel)
        {
            List<StatisticsModel> statisticsModel = new List<StatisticsModel>();

            foreach (var item in dayModel.list)
            {
                statisticsModel.Add(new StatisticsModel()
                {
                    CityID = dayModel.city.id,
                    name = dayModel.city.name,
                    date = item.date,
                    temp_min = item.main.temp_min,
                    temp_max = item.main.temp_max,
                    icon = item.weather.SingleOrDefault().icon,
                    description = item.weather.SingleOrDefault().description,
                    pressure = item.main.pressure,
                    humidity = item.main.humidity,
                    windSpeed = item.wind.speed,
                    windDirection = (int)item.wind.deg,
                    cloudiness = item.clouds.all,
                    rain = (item.rain != null) ? item.rain.rain : 0,
                    snow = (item.snow != null) ? item.snow.snow : 0
                });
            }
            return statisticsModel;
        }

        public static List<StatisticsModel> ConvertWeekModel(WeekModel weekModel)
        {
            List<StatisticsModel> statisticsModel = new List<StatisticsModel>();

            foreach (var item in weekModel.list)
            {
                statisticsModel.Add(new StatisticsModel()
                {
                    CityID = weekModel.city.id,
                    name = weekModel.city.name,
                    date = item.date,
                    temp_min = item.temp.min,
                    temp_max = item.temp.max,
                    icon = item.weather.SingleOrDefault().icon,
                    description = item.weather.SingleOrDefault().description,
                    pressure = item.pressure,
                    humidity = item.humidity,
                    windSpeed = item.speed,
                    windDirection = (int)item.deg,
                    cloudiness = item.clouds,
                    rain = (item.rain != null) ? item.rain : 0,
                    snow = (item.snow != null) ? item.snow : 0
                });
            }
            return statisticsModel;
        }
    }
}