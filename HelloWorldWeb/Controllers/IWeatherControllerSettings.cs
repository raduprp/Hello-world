namespace HelloWorldWeb.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Latitude { set; get; }

        string Longitude { set; get; }

        string ApiKey { set; get; }
    }
}