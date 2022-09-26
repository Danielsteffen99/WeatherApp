using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpClient client = new();
            string api = ("https://api.openweathermap.org/data/2.5/weather?lat=30.3894007&lon=69.3532207&appid=3f613cb112fb249d83a948820bdbd917");
            var result = client.GetFromJsonAsync<WeatherForecast.Root>(api);
            
            return View(result.Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}