﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    public class DailyWeatherRecord
    {
      
        public DailyWeatherRecord(DateTime day, double temperature, WeatherType type)
        {
            Day = day;
            Temperature = temperature;
            Type = type;
        }

        public double Temperature { get; set; }

        public WeatherType Type { get; set; }

        public DateTime Day { get; set; }



    }
}
