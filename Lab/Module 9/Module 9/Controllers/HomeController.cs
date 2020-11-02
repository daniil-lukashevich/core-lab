using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Module_9.Filters;
using Module_9.Models;

namespace Module_9.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [IEFilter]
        public IActionResult RecourseFilter()
        {
            return new JsonResult("recourse filter");
        }

        [IdApgrade]
        public IActionResult ActionFilter(string id)
        {
            return new JsonResult($"action filter. ID: {id}");
        }

        [CustomHeader]
        public IActionResult ResultFilter()
        {
            return new JsonResult("result filter");
        }

        [CustomException]
        public IActionResult ExceptionFilter()
        {
            var zero = 0;
            var x = 8 / zero;
            return new JsonResult("exception filter");
        }
    }
}
