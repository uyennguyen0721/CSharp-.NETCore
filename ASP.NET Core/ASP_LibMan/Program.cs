using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_LibMan
{
    /*
     * LibMan (Library Manager) là công cụ giúp lấy về các thư viện client-side (JS, CSS, Image) về dự án, bạn có thể nhanh chóng lấy về các thư viện phổ biến từ 
    các CDN (content delivery network) như CDNJS, jsDelivr, unpkg. Ví dụ bạn vào cdnjs (https://cdnjs.com/), tìm thư viện muốn tải về, sau đó dùng LibMan để lấy về dự án.
    * Cài đặt và sử dụng LibMan trong ASP.NET Core
    - Hãy thực hiện lệnh sau để cài đặt LibMan
        dotnet tool install -g Microsoft.Web.LibraryManager.Cli
    - Sau khi cài đặt, kiểm tra bằng lệnh
        libman --version
    - Hướng dẫn về các lệnh bạn đọc được bằng cách nhập vào
        libman --help
    - Các thư viện client-side muốn lấy về, quản lý bằng LibMan được khai báo trong một file json có tên libman.json, để khởi tạo ra file này hãy thực hiện lệnh
        libman init
    - Để đưa một thư viện vào, bạn có thể khai báo nó trong libraries một cách thủ công hoặc thực hiện lệnh. Ví dụ muốn lấy về dự án thư viện CSS Bootstrap, vào CDN cdnjs 
    tìm thì nó có tên là twitter-bootstrap, vậy bạn sẽ gõ lệnh sau để thêm vào:
        libman install twitter-bootstrap
    - Khi bạn có file libman.json để tải tất cả các thư viện khai báo trong nó thực hiện lệnh
        libman restore
    - Để cập nhật một thư viện nào đó, ví dụ jquery thì thực hiện lệnh update
        libman update jquery
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
