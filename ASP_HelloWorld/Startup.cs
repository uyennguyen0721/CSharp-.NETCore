using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP_HelloWorld
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        // Dùng để đăng ký các dịch vụ của ứng dụng, sử dụng các dịch vụ DI
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Dùng để xây dựng pipeline (những chuỗi Middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Nên viết middleware này ở đầu
            app.UseStaticFiles(); // cho phép truy cập các file mà chúng ta lưu trong thư mục mặc định wwwroot
                                 // vd truy cập .../1.txt, nó kiểm tra nếu có file 1.txt trong wwwroot thì nó sẽ trả về nd file đó
                                 // và request đó ko được đi tiếp trong pipeline nữa

            app.UseStatusCodePages(); // nếu địa chỉ nhập vô không được xử lý bằng các middleware khác (địa chỉ không tồn tại) thì nó sẽ trả về trang này

            app.UseRouting(); // điều hướng luồng đến một endpoint nhất định

            app.UseEndpoints(endpoints =>
            {
                //Truy cập với phương thức GET
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to Home Page!!!");
                });

                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync("Welcome to About Page!!!");
                });

                endpoints.MapGet("/contact", async context =>
                {
                    await context.Response.WriteAsync("Welcome to Contact Page!!!");
                });
            });

            app.Map("/abc", app1 =>
            {
                app1.Run(async context =>
                {
                    await context.Response.WriteAsync("Welcome to ABC page!!!");
                });
            });

            /* request đều đi qua middleware này, các request đi qua các middleware theo thứ tự từ trên xuống, nếu request
             đi các middleware trước middleware này mà không có địa chỉ tương ứng thì nó sẽ trả về middleware này mặc dù 
            dưới nó vẫn còn các middleware khác, thường sẽ ko sử dụng middleware này */
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello, this is my start page!!!");
            //});
        }
    }
}
