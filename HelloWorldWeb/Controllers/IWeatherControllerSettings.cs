namespace HelloWorldWeb.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Latitude { get; }

        string Longitude { get; }

        string ApiKey { get; }
    }
}