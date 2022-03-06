using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_NET_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_MVC.Controllers
{
    [Area("Database")]
    [Route("/DbManage/[action]")]
    public class DbManageController : Controller
    {
        private readonly Context context;
        [TempData]
        public string StatusMessage{get; set;}

        public DbManageController(Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeleteDb(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync(){
            Boolean kq = await context.Database.EnsureDeletedAsync(); // Phương thức xóa CSDL
            if(kq){
                StatusMessage = " Xóa thành công cơ sở dữ liệu";
                return RedirectToAction("Index", "DbManage");
            }

            StatusMessage = "Không xóa được";
            return RedirectToAction("Index", "DbManage");
        }
        [HttpPost]
        public async Task<IActionResult> MigrateAsync(){
            await context.Database.MigrateAsync();

            StatusMessage = "Đã cập nhật Cơ sở dữ liệu";
            return RedirectToAction(nameof(Index));
        }

    }
}