using ASP_NET_MVC.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace ASP_NET_MVC.Controllers
{
    // Tên Controler
    // Nếu không gọi j thì gọi => controler Home -> Action :Index
    public class HomeController : Controller
    {
        [TempData]
        public string StatusMessage{set; get;}
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public string HiHome() => "Hoc Ve ASP NET MVC";

        public IActionResult Index()
        {
            return View();
        }

        // Tên Action
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