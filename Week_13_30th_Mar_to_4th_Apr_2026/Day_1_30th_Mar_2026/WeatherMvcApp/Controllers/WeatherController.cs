using Microsoft.AspNetCore.Mvc;
using WeatherMvcApp.Models;
using System.Text.Json;

namespace WeatherMvcApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(IHttpClientFactory httpClientFactory, ILogger<WeatherController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        // GET: /Weather/Index
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("WeatherApi");
                var response = await client.GetAsync("weatherforecast");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(json, options);
                    return View(forecasts ?? new List<WeatherForecast>());
                }
                else
                {
                    ViewBag.Error = $"API returned status: {response.StatusCode}";
                    return View(new List<WeatherForecast>());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling WeatherApiDemo");
                ViewBag.Error = "Could not connect to WeatherApiDemo. Make sure it is running on http://localhost:5282";
                return View(new List<WeatherForecast>());
            }
        }
    }
}
