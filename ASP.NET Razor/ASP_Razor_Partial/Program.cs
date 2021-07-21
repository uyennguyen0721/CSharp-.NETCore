using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Razor_Partial
{
    /*
        Partial View: là những file cshtml không có chỉ thị @page, dùng để chia nhỏ những file .cshtml, sử dụng lại các thành phần (tránh
    trùng lặp code)
        Component: khá tương tự với Partial View, nó có thể sử dụng lỹ thuật DI để inject các dịch vụ của hệ thống vào trong đối tượng component, sau đó các đối tượng component
    sử dụng các dịch vụ đó. Có thể nói Component tương đương với cả trang Razor Page nhỏ (Mini Razor Page)
     */


    public class Program
    {
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
