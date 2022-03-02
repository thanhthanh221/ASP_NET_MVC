using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing.Constraints; // khống thể Route theo yêu cầu
using ASP_NET_MVC.Service;

namespace ASP_NET_MVC
{
    public class Startup
    {
        public static string? ContentRootPath{set;get;}
        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            // Đường dẫn của thư mục được lưu tại env.ContentRootPath Đường dẫn thực lưu dữ liệu trong máy tới dự án
            ContentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.(Thêm dịch vụ vào vùng chứa)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton<ProductService>(); // Thêm dịch vụ của sản phẩm vào dự án
            services.AddSingleton<PlanetService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.(Nơi chạy dự án )
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Lỗi(400->) sẽ chuyển về URL "Home/Index"
            app.UseStatusCodePagesWithRedirects("/Home/Index");            

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("Hello", async requestDelegate =>{
                    await requestDelegate.Response.WriteAsync($"Thời gian hiện tại là {DateTime.Now}");
                });
                endpoints.MapControllers();
                // Thiết lập controler ra URl => Tên Controler - Action - tên dữ liệu truyền tới (1 controller nên chỉ có 1 gt truyền tới )

                //endpoints.MapControllers(); => cấu hình tạo ra điểm enp => sau đó định nghĩa qua controller
                //endpoints.MapAreaControllerRoute(); tạo ra endp => controller ở trong mục riêng
                //endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(); // Phương thức chung nhất
                endpoints.MapControllerRoute(
                    name: "first",
                    pattern: "{url}/{id?}",
                    defaults: new{
                        controller= "First",
                        action= "Product_Return"
                    },
                    // URL -> /xemsanpham/id? => controller :First / Action: Product_Return
                    constraints: new {       // kiểm tra điều kiện ràng buộc của url
                        url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct))$"),
                        id = new RangeRouteConstraint(0,100)

                    }
                );
                endpoints.MapAreaControllerRoute(
                    name: "Product",
                    pattern: "{controller}/{action=Index}/{id?}",
                    areaName: "ProductManage"
                );
                endpoints.MapControllerRoute(
                    name: "Test1",     // Tên
                    pattern: "{controller=Home}/{action=Index}/{id?}"        // URL trỏ đến  ---- id? là có hay không đều được
                );
                // nếu không có thì mặc định là ntn
                /*
                endpoints.MapControllerRoute(
                    name: "default",   // tên 
                    pattern: "{controller=Home}/{action=Index}/{id?}" // Mẫu URL kiểm tra để xem
                    
                        Controller =>  Kiểm tra controller
                        Action =>  Kiểm tra Action
                        area => kiểm tra area
                    
                );
                */
            
                // Cho thêm tính năng của Razor Page (Trang của Razor Page)
                endpoints.MapRazorPages();
            });
        }
    }
}
