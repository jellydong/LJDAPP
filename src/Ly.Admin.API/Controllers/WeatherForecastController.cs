using Ly.Admin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ly.Admin.API.Controllers
{
    /// <summary>
    /// 天气接口
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILoginInfo _loginInfo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoginInfo loginInfo)
        {
            _logger = logger;
            _loginInfo = loginInfo;
        }
        /// <summary>
        /// 获取天气
        /// </summary>
        /// <returns>天气列表</returns>
        [HttpGet]
        [Route("Get")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            var id = _loginInfo.AccountId;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        /// <summary>
        /// 获取天气V2 
        /// </summary>
        /// <returns>天气列表</returns>
        [HttpGet]
        [Route("GetV2")]
        [ApiExplorerSettings(IgnoreApi = true)]//如果不想显示某些接口，直接在controller 上，或者action 上，增加特性
        public IEnumerable<WeatherForecast> GetV2()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        /// <summary>
        /// Hello World 
        /// </summary>
        /// <returns>Hello World</returns>
        [HttpGet]
        [Route("HelloWorld")]
        public string HelloWorld()
        {
            return "Hello World " + _loginInfo.AccountName;
        }



    }
}
