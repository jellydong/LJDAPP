namespace Ly.Admin.Web.Clients
{
    public class WeatherForecastServiceClient : LyAdminApiBaseServiceClient
    {
        public WeatherForecastServiceClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<string> HelloWorld()
        {
            return await GetAsync("/WeatherForecast/HelloWorld"); //这里使用相对路径来访问
        }
    }
}
