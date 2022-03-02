using Microsoft.AspNetCore.Mvc;
using ASP_NET_MVC.Service;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers
{
    // Để coi là controler  thì phải kế thừa từ Controler
    public class FirstController : Controller
    {
        // Đăng Kí log vào ứng dụng
        public readonly ILogger<FirstController> logger;
        public FirstController(ILogger<FirstController> logger){
            this.logger = logger;
        }
        [TempData]
        public string StatusMessage{set; get;}
        public string Index()
        {
            logger.LogInformation("Đây là thông tin đầu tiên của Log");
            return "Controler đầu tiên";
        }
        public IActionResult IMG_Y(){
            // Đường dẫn thực tế của File    
            string img = Path.Combine(ASP_NET_MVC.Startup.ContentRootPath,"wwwroot","img","75c2f0bf603c14b3b4446b193e632cd2.jpg");
            // đọc file bằng phương thức ReadAllBytes -ReadAllByteAsync
            byte[] bytes = System.IO.File.ReadAllBytes(img);
            return File(bytes,"image/jpg"); // Gồm 1 mảng bytes và kiểu dữ file
        }
        // Khá quan trọng khi dùng trong API
        public IActionResult Json_Return(){
            return Json(
                new{
                    Product_Name = "Iphone",
                    Price = 10000
                }
            );
        }
        // Trả về URL
        public IActionResult URL_Return(){
            // Phương thức Url.Action => tham số là :  tên Action - Tên controller 
            var url = Url.Action("Privacy","Home");
            // return RedirectToAction(url); => chỉ trả về Action khi cùng controller
            logger.LogInformation("Trả về URL :"+ url);
            return Redirect(url);
        }
        // ViewResult => trả về View
        // khi return View("Đường dẫn tuyệt đối", dữ liệu truyền đến cho View);
        // Khi tìm View => -> View/"Tên controller"/"Tên Action" nếu gán trong View("Tên xxx") => Tên Action sẽ thay bằng tên View
        public IActionResult Test1(){
            string News = string.Empty;
            News = "Bùi Việt Quang";

            return View((Object)News);
        }
        // ViewData["xxx"] => Dữ Liệu sẽ lưu trong để controller tạo và View có thể dùng được
        // ViewBag => Thiết lập thuộc tính lúc thực thi(Dữ liệu chung ở ViewBag) VỉewBag.(Dữ liệu muốn lưu)
        // Nếu muốn truyền dữ liệu giữa các trang thì có thê dùng TeampData["xxxxxxxxxxxx] =      .... Lưu trong ss dự án


        // Trong MVC dữ liệu : Nguồn dữ liệu => Model => Service => Đăng kí dịch vụ này vào(Kiểu SG) => Controller lấy dữ liệu dừ Service => Truyền qua View(Có thể trả về Json nếu dùng API)

        public IActionResult Product_Return(int? id){
            if(id == null){
                StatusMessage ="Không tìm thấy ID của sản phẩm";
                return Redirect(Url.Action("Index","Home"));
            }
            ProductService productService = new ProductService();

            List<Models.Product> products = productService.products;
            if(products.Count() == 0){
                return NotFound("Không có sản phẩm nào");                
            }
            // Không thể Null được -,-
            Models.Product? product = products.Where(p => p.ID == id).FirstOrDefault();
            if(product == null){
                return NotFound("Không tìm thấy sản phẩm có ID = ID");
            }
            
            return View((object)product);
        }
    }
}
