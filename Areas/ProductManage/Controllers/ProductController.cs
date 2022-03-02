using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
