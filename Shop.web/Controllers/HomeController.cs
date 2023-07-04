using Shop.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Shop.web.Controllers
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
            //top ten customer within 20 days
            _logger.LogInformation("home/Index action was called.");

            return View();
        }

        public IActionResult Privacy()
        {
            //
            _logger.LogInformation("home/Privacy action was called.");
            return View();
        }
        public IActionResult UserPage()
        {
            _logger.LogInformation("home/UserPage action was called.");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogInformation("home/Error action was called.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}