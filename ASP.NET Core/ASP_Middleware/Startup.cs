using ASP_Middleware.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SecondMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseFirstMiddleware(); // Đưa vào pipeline FirstMiddleware

            //app.UseMiddleware<SecondMiddleware>();
            app.UseSecondMiddleware();

            app.UseRouting(); // EndPointsRoutingMiddleware

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

            // Rẽ nhánh trên pipeline
            app.Map("/admin", app1 =>
            {
                // Tạo middleware của nhánh

                app1.UseRouting();

                app1.UseEndpoints(endpoints =>
                {
                    //Truy cập với phương thức GET
                    endpoints.MapGet("/user", async context =>
                    {
                        await context.Response.WriteAsync("Welcome to User Page!!!");
                    });

                    endpoints.MapGet("/product", async context =>
                    {
                        await context.Response.WriteAsync("Welcome to Product Page!!!");
                    });

                    endpoints.MapGet("/category", async context =>
                    {
                        await context.Response.WriteAsync("Welcome to Category Page!!!");
                    });
                });

                app1.Run(async context =>
                {
                    await context.Response.WriteAsync("Welcome to Admin page!!!");
                });
            });

            // Terminal Middleware M1
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Xin chào ASP.NET Core!");
            });
        }
    }
}

/*
 HttpContext
    pipline: FirstMiddleware - SecondMiddleware - M1
 */
