using Refit;

namespace Ly.Admin.Web.Clients
{
    public interface IWeatherForecastServiceClient
    {
        [Get("/WeatherForecast/HelloWorld")]
        Task<string> HelloWorld();

    }
}
