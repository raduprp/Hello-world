using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    public class DailyWeatherRecord
    {
        public const float KELVIN_CONST = 273.15f;
      
        public DailyWeatherRecord(DateTime day, double temperature, WeatherType type)
        {
            Day = day;
            Temperature = temperature;
            Type = type;
        }

        public double Temperature { get; set; }

        public WeatherType Type { get; set; }

        public DateTime Day { get; set; }

        public static float KelvinToCelsius(float kelvinVal)
        {
            return kelvinVal - KELVIN_CONST;
        }



    }
}
