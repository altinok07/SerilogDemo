using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SerilogDemo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        //private readonly ILogger<WeatherForecastController> _logger;

        private readonly ILogger _logger;
        public WeatherForecastController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            _logger.Information("You requested the Get method");

            try
            {
                throw new Exception("This is our Demo Exception");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "I catch this exception in the Get method call");
            }



            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }



        [HttpGet("Test")]
        public int Test()
        {
            _logger.Information("You requested the Get method");


            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 56)
                    {
                        throw new Exception("This is my demo exception");
                    }
                    else
                    {
                        _logger.Information("The Value of i is: {i}", i);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "I catch this exception in the Get method call");
            }

            return 0;
        }
    }
}