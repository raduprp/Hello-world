using HelloWorldWeb.Controllers;
using HelloWorldWeb.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class WeatherControllerTests
    {
        [Fact]
        public void TestCheckingConversion()
        {
            //Assume

            string content = LoadJsonFromResource();
            var wheaterControllerSettingsMock = new Mock<IWeatherControllerSettings>();
            var weatherObject = wheaterControllerSettingsMock.Object;
            
            WeatherController weatherController = new WeatherController(weatherObject);
           //Act
           var result = weatherController.ConvertResponseToWeatherRecordList(content);

        //Assert

            Assert.Equal(7,result.Count());
            var firstDay = result.First();
            Assert.Equal(new DateTime(2021, 8, 12), firstDay.Day);
            Assert.Equal(DailyWeatherRecord.KelvinToCelsius(297.88f), firstDay.Temperature);
            Assert.Equal(WeatherType.FewClouds, firstDay.Type);

            
        }

        private string LoadJsonFromResource()
        {
            var resourceName = "HelloWorldWeb.Tests.TestData.ContentWeatherAPI.json";
            var assembly = this.GetType().Assembly;
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }

    }
}
