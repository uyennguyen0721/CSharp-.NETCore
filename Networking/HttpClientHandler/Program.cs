using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientHandler
{
    class Program
    {
        // Http Request - HttpClient (GET/POST)

        // Hiển thị các Header
        static void ShowHeader(HttpResponseHeaders headers)
        {
            Console.WriteLine("CÁC HEADER");
            foreach (var header in headers)
            {
                Console.WriteLine($"{header.Key} : {header.Value}");
            }
        }

        // Trả về nội dung của trang web
        public static async Task<string> GetWebContent(string url)
        {
            // Để đối tượng tự hủy khi thoát ra khỏi phương thức ta sử dụng từ khóa using
            using var httpClient = new HttpClient();

            try
            {
                //Thiết lập các header gửi đi
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                //Thực hiện truy vấn đến địa chỉ URL
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

                ShowHeader(httpResponseMessage.Headers);

                // Đọc nội dung kết quả trả về
                string html = await httpResponseMessage.Content.ReadAsStringAsync();

                return html;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Lỗi";
            }
        }

        // download file

        public static async Task<byte[]> DownloadDataBytes(string url)
        {
            // Để đối tượng tự hủy khi thoát ra khỏi phương thức ta sử dụng từ khóa using
            using var httpClient = new HttpClient();

            try
            {
                //Thiết lập các header gửi đi
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                //Thực hiện truy vấn đến địa chỉ URL
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

                ShowHeader(httpResponseMessage.Headers);

                // Đọc nmảng bytes trả về 
                var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();

                return bytes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task DownloadStream(string url, string filename)
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);

                using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
                using var streamwrite = File.OpenWrite(filename);

                int SIZEBUFFER = 500;
                var buffer = new byte[SIZEBUFFER];

                bool endread = false;
                do
                {
                    int numBytes = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
                    if (numBytes == 0)
                    {
                        endread = true;
                    }
                    else
                    {
                        await streamwrite.WriteAsync(buffer, 0, numBytes);
                    }

                } while (!endread);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /*
        public class MyHttpClientHandler : HttpClientHandler
        {
            public MyHttpClientHandler(CookieContainer cookie_container)
            {

                CookieContainer = cookie_container;     // Thay thế CookieContainer mặc định
                AllowAutoRedirect = false;                // không cho tự động Redirect
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                UseCookies = true;
            }
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                         CancellationToken cancellationToken)
            {
                Console.WriteLine("Bất đầu kết nối " + request.RequestUri.ToString());
                // Thực hiện truy vấn đến Server
                var response = await base.SendAsync(request, cancellationToken);
                Console.WriteLine("Hoàn thành tải dữ liệu");
                return response;
            }
        }

        public class ChangeUri : DelegatingHandler
        {
            public ChangeUri(HttpMessageHandler innerHandler) : base(innerHandler) { }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                   CancellationToken cancellationToken)
            {
                var host = request.RequestUri.Host.ToLower();
                Console.WriteLine($"Check in  ChangeUri - {host}");
                if (host.Contains("google.com"))
                {
                    // Đổi địa chỉ truy cập từ google.com sang github
                    request.RequestUri = new Uri("https://github.com/");
                }
                // Chuyển truy vấn cho base (thi hành InnerHandler)
                return base.SendAsync(request, cancellationToken);
            }
        }


        public class DenyAccessFacebook : DelegatingHandler
        {
            public DenyAccessFacebook(HttpMessageHandler innerHandler) : base(innerHandler) { }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                         CancellationToken cancellationToken)
            {

                var host = request.RequestUri.Host.ToLower();
                Console.WriteLine($"Check in DenyAccessFacebook - {host}");
                if (host.Contains("facebook.com"))
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Không được truy cập"));
                    return await Task.FromResult<HttpResponseMessage>(response);
                }
                // Chuyển truy vấn cho base (thi hành InnerHandler)
                return await base.SendAsync(request, cancellationToken);
            }
        }
        */
        static async Task Main(string[] args)
        {
            var url = "https://postman-echo.com/post";
            using var handler = new SocketsHttpHandler();
            var cookies = new CookieContainer();

            handler.AllowAutoRedirect = true; // cho phép tự động chuyển hướng khi mã trả về là 30120 tức là nó chuyển hướng sang một URL mới 
            handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip; // thiết lập hỗ trợ giải nén html định dạng Deflate hoặc GZip
            handler.UseCookies = true; // cho phép lưu cookies
            // lưu cookies ở dạng đối tượng tập hợp
            handler.CookieContainer = cookies;

            using var httpClient = new HttpClient(handler);
            using var httpRequestMessage = new HttpRequestMessage();

            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri(url);
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
            parameters.Add(new KeyValuePair<string, string>("key2", "value2"));

            httpRequestMessage.Content = new FormUrlEncodedContent(parameters);
            var response = await httpClient.SendAsync(httpRequestMessage);

            cookies.GetCookies(new Uri(url)).ToList().ForEach(c =>
            {
                Console.WriteLine($"{c.Name} : {c.Value}");
            });

            var html = await response.Content.ReadAsStringAsync();
            Console.WriteLine(html);


            //---------------
/*
            string url1 = "https://www.facebook.com/xuanthulab";

            CookieContainer cookies1 = new CookieContainer();

            // TẠO CHUỖI HANDLER
            var bottomHandler = new MyHttpClientHandler(cookies);              // handler đáy (cuối)
            var changeUriHandler = new ChangeUri(bottomHandler);
            var denyAccessFacebook = new DenyAccessFacebook(changeUriHandler); // handler đỉnh

            // Khởi tạo HttpCliet với hander đỉnh chuỗi hander
            var httpClient1 = new HttpClient(denyAccessFacebook);

            // Thực hiện truy vấn
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            HttpResponseMessage response1 = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string htmltext = await response.Content.ReadAsStringAsync();

            Console.WriteLine(htmltext); */

        }
    }
}
