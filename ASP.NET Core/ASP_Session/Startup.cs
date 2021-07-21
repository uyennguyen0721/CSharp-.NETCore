using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Session
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.Cookie.Name = "Uyen Nguyen"; //Tên cookies gửi về Client là gì
                option.IdleTimeout = new TimeSpan(0, 30, 0); //Thiết lập cookies có thời hạn 30p
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*Khi httpContext đi qua thì dữ liệu của phiên làm việc sẽ được phục hồi vào một thuộc tính của httpContext
             Thuộc tính đó có thể truy cập thông qua HttpContext, có tên là Session
            Thông thường SessionMiddleware sẽ trả về một Cookies (ID Session), trình duyệt sẽ lưu lại cookies này thì lần 
            truy cập tiếp theo nó sẽ gửi cái cookies và căn cứ vào cái cookies này thì cái SessionMiddleware này sẽ phục 
            hồi lại dữ liệu mà nó lưu trữ trong bộ nhớ, dữ liệu được phục hồi nằm trong thuộc tính session*/

            app.UseSession(); //SessionMiddleware

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/readwritesession", async context =>
                {
                    // lưu dữ liệu đếm số lần truy cập

                    int? count; // được lưu trong session với key tên là count, nếu không có giá trị sẽ trả về null
                    count = context.Session.GetInt32("count"); //đọc session
                    if(count == null)
                    {
                        count = 0;
                    }

                    count += 1;
                    //Lưu trở lại session
                    context.Session.SetInt32("count", count.Value); //lưu session lại vào key "count" có giá trị là count.Value

                    //Ghi ra số lần truy cập
                    await context.Response.WriteAsync($"So lan truy cap vao trang readwritesession la: {count}");
                });
            });
        }
    }
}
