using Microsoft.AspNetCore.Mvc;
using ASP_NET_MVC.Service;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers{
    [Route("HeMatTroi/[action]")]  // Phải thiết lập action không thì lỗi
    public class PlanetController :Controller{
        public readonly ILogger<PlanetController> logger;
        public readonly PlanetService planetService;
        
        public PlanetController(ILogger<PlanetController> logger, PlanetService planetService)
        {
            this.logger = logger;
            this.planetService = planetService;
        }
        [Route("DanhSachHanhTinh")]
        public IActionResult Index(){
            return View();
        }
        [BindProperty(SupportsGet = true, Name = "Action")]
        public string Name{set; get;}
        public IActionResult Mercury(){
            PlanetModel? planetModel =  planetService.Where(p => p.name.Equals(Name)).FirstOrDefault();

            return View("Detail", planetModel);
        }
        public IActionResult Earth(){
            PlanetModel? planetModel =  planetService.Where(p => p.name.Equals(Name)).FirstOrDefault();
            
            return View("Detail", planetModel);
        }
        [HttpGet] // Chỉ truy cập bằng phương thức get
        // [HttpPost] // chỉ truy cập bằng phương thức post
        public IActionResult Jupiter(){
            PlanetModel? planetModel =  planetService.Where(p => p.name.Equals(Name)).FirstOrDefault();
            
            return View("Detail", planetModel);
        }
        public IActionResult Mars(){
            PlanetModel? planetModel =  planetService.Where(p => p.name.Equals(Name)).FirstOrDefault();
            
            return View("Detail", planetModel);
        }
        public IActionResult Uranus(){
            PlanetModel? planetModel =  planetService.Where(p => p.name.Equals(Name)).FirstOrDefault();
            
            return View("Detail", planetModel);
        }
        public IActionResult Venus(){
            PlanetModel? planetModel =  planetService.Where(p => p.name.Equals(Name)).FirstOrDefault();
            
            return View("Detail", planetModel);
        }
        public IActionResult Saturn(){
            PlanetModel? planetModel =  planetService.Where(p => p.name.Equals(Name)).FirstOrDefault();
            
            return View("Detail", planetModel);
        }
        [Route("Sao/[controller]/[action]", Order = 1)]  // => thứ tự ưu tiên là 1
        [Route("Sao/[action]")]

        public IActionResult Neptune(){
            PlanetModel? planetModel =  planetService.Where(p => p.name.Equals(Name)).FirstOrDefault();
            
            return View("Detail", planetModel);
        }
        // controller , action, area => [controller] [action] [area]
        [Route("HanhTinh/{id:int}")]  // Gạch đầu có dấu chéo thì không quan tâm đến controller "/HanhTinh"
        public IActionResult Planet(int? id){
            if(id == null){
                return NotFound("Không có ID để tìm kiếm");
            }
            PlanetModel? planetModel =  planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail",planetModel);
        }
    }
}