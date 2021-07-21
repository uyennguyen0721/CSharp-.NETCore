using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register_Login_Logout
{
    /*
      Lệnh dotnet aspnet-codegenerator identity sẽ phát sinh các code (các Model, trang Razor Page, Controller, View) sẵn cho chúng ta, 
    qua đó chỉ việc tùy biến lại, bạn thực hiện lệnh như sau (nhớ cài đặt đầy đủ công cụ và các gói ở trên):
            dotnet aspnet-codegenerator identity -dc Register_Login_Logout.Data.AppDbContext
      Tham số -dc Register_Login_Logout.Data.AppDbContext để chỉ ra là Identity sử dụng DbContext là Album.Data.AppDbContext của chúng ta xây dựng ở trên
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
