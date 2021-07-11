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
                            new object[] {
                                new
                                {
                                    url = "/abc",
                                    label = "Menu Abc"
                                },
                                new
                                {
                                    url = "/xyz",
                                    label = "Menu Xyz"
                                }
                            }, context.Request
                        );

                    var html = HtmlHelper.HtmlDocument("XIN CHÀO", menu + HtmlHelper.HtmlTrangchu());
                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/RequestInfo", async context =>
                {
                    await context.Response.WriteAsync("RequestInfo");
                });

                endpoints.MapGet("/EndCoding", async context =>
                {
                    await context.Response.WriteAsync("EndCoding");
                });

                endpoints.MapGet("/Cookies", async context =>
                {
                    await context.Response.WriteAsync("Cookies");
                });

                endpoints.MapGet("/Json", async context =>
                {
                    await context.Response.WriteAsync("Json");
                });

                endpoints.MapGet("/Form", async context =>
                {
                    await context.Response.WriteAsync("Form");
                });
            });
        }
    }
}
