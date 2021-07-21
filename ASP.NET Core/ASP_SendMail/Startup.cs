using ASP_SendMail.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_SendMail
{
    public class Startup
    {
        IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            var mailsetting = _configuration.GetSection("MailSetting");
            services.Configure<MailSetting>(mailsetting);

            services.AddTransient<SendMailServices>();
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

                endpoints.MapGet("/TestSendMail", async context =>
                {
                    var message = MailUtils.MailUtils.SendMail("uyennguyen0721@gmail.com", "1851050182uyen@ou.edu.vn", "TEST SEND MAIL", "Xin chào Uyên Nguyễn");
                    await context.Response.WriteAsync(await message);
                });

                endpoints.MapGet("/TestGmail", async context =>
                {
                    var message = MailUtils.MailUtils.SendGmail("uyennguyen0721@gmail.com", "uyennguyen0721@gmail.com", "TEST GMAIL", "Xin chào Uyên Nguyễn", "uyennguyen0721@gmail.com", "xxxxx");
                    await context.Response.WriteAsync(await message);
                });

                endpoints.MapGet("/TestSendMailServices", async context =>
                {
                    var sendMailService = context.RequestServices.GetService<SendMailServices>();

                    var mailContent = new MailContent();

                    mailContent.To = "1851050182uyen@ou.edu.vn";
                    mailContent.Subject = "KIỂM TRA THỬ EMAIL";
                    mailContent.Body = "<h1>TEST</h1><i>Xin chào Uyên Nguyễn</i>";

                    var kq = sendMailService.SendMail(mailContent);

                    await context.Response.WriteAsync(await kq);
                });
            });
        }
    }
}
