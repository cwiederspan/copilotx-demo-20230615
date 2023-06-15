using Microsoft.AspNetCore.Mvc;

namespace MyApplication.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase {

        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> Logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger) {
            this.Logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() {

            this.Logger.Log(LogLevel.Information, "WeatherForecastController.Get has been called");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}