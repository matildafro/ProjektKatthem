using Microsoft.AspNetCore.Mvc;
using ProjektKatthem.Models;
using System.Diagnostics;

namespace ProjektKatthem.Controllers
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
            return View();
        }
        [Route("/om-oss")]
        public IActionResult About()
        {
            return View();
        }
        [Route("/stod-oss")]
        public IActionResult Support()
        {
            return View();
        }
        [Route("/kontakt")]
        public IActionResult Contact()
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