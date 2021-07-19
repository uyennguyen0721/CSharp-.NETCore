using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Razor_Init
{
    public class Program
    {
        /*
            Razor Page (.cshtml) = html + C#
            ---> được Engine Razor biên dịch cshtml thành lớp C# từ đó ta được các response trả về 
            - @page
            - @biến, @(biểu thức), @phương thức
            - @{code C#}

            Tag Helper --> Hỗ trợ phát sinh ra HTML
                @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
            
            ViewData: chứa dữ liệu để truyền giữa các phương thức, được sử dụng trong cshtml, các dữ liệu được lưu trữ vào ViewData bằng key
            Viewdata["mydata"] (key có tên là mydata)
         */

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
