using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Module_10.Models;

namespace Module_10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
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

        [HttpPost]
        [Route("customaction")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult CustomAction([FromBody]CustomModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(model.Name);
            //return NotFound();
        }

        /// <summary>
        /// Some comment here
        /// </summary>
        /// <param name="name">Nmae to update</param>
        /// <returns>Updated name.</returns>
        [HttpPut]
        [Route("swagger")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Swagger(SwaggerModel model)
        {
            if (model == null)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
            //return NotFound();
        }

        [HttpGet]
        public ActionResult Validate(string firstName, string lastName)
        {
            if ((firstName + lastName).Length > 16)
            {
                return new JsonResult("Error message");
            }
            return new JsonResult(true);
        }
    }
}
