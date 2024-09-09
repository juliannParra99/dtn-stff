using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace weatherForecast.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // Lista para almacenar los datos de previsión del tiempo
        private static readonly List<WeatherForecast> Forecasts = new List<WeatherForecast>
        {
            new WeatherForecast(1, DateOnly.FromDateTime(DateTime.Now.AddDays(1)), 10, "Chilly"),
            new WeatherForecast(2, DateOnly.FromDateTime(DateTime.Now.AddDays(2)), 15, "Cool"),
            new WeatherForecast(3, DateOnly.FromDateTime(DateTime.Now.AddDays(3)), 20, "Mild"),
            new WeatherForecast(4, DateOnly.FromDateTime(DateTime.Now.AddDays(4)), 25, "Warm"),
            new WeatherForecast(5, DateOnly.FromDateTime(DateTime.Now.AddDays(5)), 30, "Hot")
        };

        // Obtener todos los pronósticos
        [HttpGet]
        public IActionResult GetWeatherForecast()
        {
            return Ok(Forecasts);
        }

        // Agregar un nuevo pronóstico
        [HttpPost]
        public IActionResult AddWeatherForecast([FromBody] WeatherForecast newForecast)
        {
            if (newForecast == null)
            {
                return BadRequest("El pronóstico del tiempo no puede ser nulo.");
            }

            // Asignar un ID único al nuevo pronóstico
            newForecast.Id = Forecasts.Max(f => f.Id) + 1;
            Forecasts.Add(newForecast);
            return CreatedAtAction(nameof(GetWeatherForecast), new { id = newForecast.Id }, newForecast);
        }

        // Eliminar un pronóstico existente
        [HttpDelete("{id}")]
        public IActionResult DeleteWeatherForecast(int id)
        {
            var forecast = Forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
            {
                return NotFound();
            }

            Forecasts.Remove(forecast);
            return NoContent();
        }
    }

    public class WeatherForecast
    {
        public int Id { get; set; } // Identificador único
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }

        public WeatherForecast(int id, DateOnly date, int temperatureC, string summary)
        {
            Id = id;
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }
    }
}
