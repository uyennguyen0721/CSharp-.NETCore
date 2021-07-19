using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Razor_Init
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.RootDirectory = "/Pages"; //Thay đổi tên thư mục gốc chứa các file cshtml (mặc định có tên là Pages)
                options.Conventions.AddPageRoute("/FirstPage", "trang-dau-tien.html"); //Thay đổi địa chỉ URL của các Razor Page
            });

            services.Configure<RouteOptions>(routeOptions =>
            {
                routeOptions.LowercaseUrls = true; //chuyển các URL thành chữ thường
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapRazorPages(); //Tìm trên toàn bộ các mã nguồn những trang razor page (cshtml) và sử dụng những trang này như mọt endpoints
                //FirstPage.cshtml => URL = /FirstPage

            });
        }
    }
}
