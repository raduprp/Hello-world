// <copyright file="Startup.cs" company="Principal 33 Solutions">
// Copyright (c) Principal 33 Solutions. All rights reserved.
// </copyright>


using HelloWorldWeb.Controllers;

namespace HelloWorldWeb
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public string Longitude => throw new System.NotImplementedException();

        public string Latitude=> throw new System.NotImplementedException();

        public string ApiKey => throw new System.NotImplementedException();
    }
}