using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SeriLog.Sinks.SeqExample.Models;

namespace SeriLog.Sinks.SeqExample.Controllers
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
            var max = 30;
            var numbers = new { num1 = 10, num2 = 12 };
            var sum = numbers.num1 + numbers.num2;
            _logger.LogWarning("numbers are @{numbers} and sum is: {sum}", numbers, sum);
            if (max > sum) _logger.LogError("max is bigger than {sum}", sum);
            _logger.LogWarning("this is a warning");
            _logger.LogError("this is an error");
            _logger.LogCritical("this is a Critical");
            _logger.LogInformation("this is a Information");
            _logger.LogDebug("this is a Debug log");
            return View();
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
