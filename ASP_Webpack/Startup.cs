using ASP_Webpack.mylib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Webpack
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var menu = HtmlHelper.MenuTop(
                            HtmlHelper.DefaultMenuTopItems(), context.Request
                        );
                    var info = HomePages.HtmlTrangchu();

                    var html = HtmlHelper.HtmlDocument("Uyen's Blog", menu + info);
                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/code-stories", async context =>
                {
                    var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);

                    var info = StoriesOfCode.Stories();

                    var html = HtmlHelper.HtmlDocument("Chuyện của Code ", menu + info);
                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/posts", async context =>
                {
                    await context.Response.WriteAsync("Bài viết");
                });

                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync("Hòa mình cùng Uyên Uyên");
                });

                endpoints.MapGet("/coding", async context =>
                {
                    await context.Response.WriteAsync("Nghề coding");
                });

                endpoints.MapGet("/moment", async context =>
                {
                    await context.Response.WriteAsync("Bắt nhịp khoảnh khắc");
                });
            });
        }
    }
}
