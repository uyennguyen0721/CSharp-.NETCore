using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HelloWorld
{
    public class Program
    {
        /* Để thiêt lập và khởi chạy một ứng dụng ASP.NET, cơ bản ta phải làm các việc như sau:
           Tạo ra một đối tượng Host, đối tượng này được triển khai từ interface Host (IHost) và chứa các thành phần:
                - Các đối tượng liên quan đến kỹ thuật Dependence Injection (DI): điều này có nghĩa là trong đối tượng Host
        này chứa đối tượng IServiceProvider để lấy ra các dịch vụ (ServiceCollection)
                - Các đối tượng trong Host chứa các dịch vụ liên quan đến Logging (ILogging)
                - Configuration: Toàn bộ cấu hình của ứng dụng
                - Có lớp được triển khai từ IHostedService => đối tượng được triển khai từ IHostedService có phương thức StartAsync,
        Khi phương thức này khởi chạy, nó sẽ chạy một máy chủ HTTP (HTTP Server) được tích hợp sẵn trong thư viện .NET (máy chủ có tên Kestrel Http).
        Khi máy chủ trong Host này chạy, thì nó bắt đầu nhận các yêu cầu HTTP từ Client gửi đến, cái máy chủ này chạy và lắng nghe đến khi chúng ta ra 
        lệnh kết thúc ứng dụng
        ===> Cấu trúc cơ bản của đối tượng Host trong ứng dụng ASP.NET

        * Để chạy đối tượng Host thì ta cần phải
            1) Tạo IHostBuilder
            2) Dùng IHostBuilder để thiết lập các cấu hình, đăng ký các dịch vụ, bằng cách gọi phương thức ConfigureWebHostDefaults của IHostBuilder
            3) IHostBuilder.Build() => tạo ra đối tượng Host (IHost)
            4) Host.Run() để chạy Host

        * Trong ứng dụng ASP.NET, khi nhận được các request thì các request đó phải được chuyên xử lý và đi qua các đoạn code và cuối cùng trả về các Respond
        * Các thành phần mà Resquest phải đi qua được gọi là pipeline (là một chuỗi những cái gọi là Middleware)
         */


        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>  // Cấu hình mặc định cho HOST tạo ra
                {
                    //Tùy biến thêm về Host

                    //Thay đổi  thư mục chứa các file tĩnh (mặc định là wwwroot) thành thư mục có tên là public
                    //webBuilder.UseWebRoot("public")
                    
                    webBuilder.UseStartup<Startup>();
                });
    }
}
