using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Uri_Dns_Ping
{
    class Program
    {
        // Http Request - HttpClient (GET/POST)

        // Hiển thị các Header
        static void ShowHeader(HttpResponseHeaders headers)
        {
            Console.WriteLine("CÁC HEADER");
            foreach(var header in headers)
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
            catch(Exception e)
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
                    if(numBytes == 0)
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

        static async Task Main(string[] args)
        {
            //URI (URL)

            string url = "https://www.bootstrapcdn.com/";
            var uri = new Uri(url);
            var uritype = typeof(Uri);
            uritype.GetProperties().ToList().ForEach(property => {
                Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            });
            Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");

            //DNS

            Console.WriteLine(uri.Host);
            var iphostentry = Dns.GetHostEntry(uri.Host); // Lấy thông tin của Host
            Console.WriteLine(iphostentry.HostName); // tên của Host
            iphostentry.AddressList.ToList().ForEach((ip) => Console.WriteLine($"+ {ip}")); // danh sách địa chỉ IP

            //PING: kiểm tra phản hồi của máy remote

            var ping = new Ping();
            var pingReply = ping.Send("google.com.vn");
            Console.WriteLine(pingReply.Status);
            if (pingReply.Status == IPStatus.Success)
            {
                Console.WriteLine(pingReply.RoundtripTime);
                Console.WriteLine(pingReply.Address);
            }
            // Success
            // 28
            // 142.250.204.131

            // Http Request - HttpClient (GET/POST)

            var url1 = "https://www.google.com/search?q=xuanthulab";
            var task = GetWebContent(url1);
            task.Wait();

            var html = task.Result;
            Console.WriteLine(html);

            // HttpResponseMessage

            var url2 = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
            byte[] bytes = await DownloadDataBytes(url2);

            string filepath = "anh1.png";
            using (var stream = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                stream.Write(bytes, 0, bytes.Length);
                Console.WriteLine("save " + filepath);
            }

            await DownloadStream(url2, "anh2.png");

            //SendAsync: dùng để truy vấn một đối tượng http

            /* Thực hiện truy vấn bằng cách gửi một http request là một đối tượng của lớp HttpRequestMessage*/
            using var httpClient = new HttpClient();

            // HttpRequestMessage: biểu diễn yêu cầu truy vấn
            var httpMessageRequest = new HttpRequestMessage();
            httpMessageRequest.Method = HttpMethod.Post;
            httpMessageRequest.RequestUri = new Uri("https://www.google.com.vn");
            httpMessageRequest.Headers.Add("User-Agent", "Mozilla/5.0");

            // chứa các dữ liệu mà ta gửi đi (Form HTML, File ...) 
            // httpMessageRequest.Content => Form HTML, File

            // POST dữ liệu => nó có chứa các dữ liệu giống như ta submit 1 cái Form HTML
            /* FORM HTML này gồm các giá trị mà khi nó submit mà nó sẽ gửi đi lên Server:
                - 1 phần tử HTML có tên key1 => có giá trị value1   [Input]
                - key2 => [value2-1, value2-2]                      [Multi Select]
                */

            /* Để thiết lập Content này thành một nội dung của FORM HTML thì ta gán Content này cho một đối tượng kiểu FormUrlEndcodedContent*/

            var parameters = new List<KeyValuePair<string, string>>();

            // Thêm một phần tử mới 
            parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
            parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
            parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));

            var content = new FormUrlEncodedContent(parameters);
            httpMessageRequest.Content = content;

            httpMessageRequest.RequestUri = new Uri("https://www.posman-echo.com/post");

            var httpRespontMessage = await httpClient.SendAsync(httpMessageRequest);

            ShowHeader(httpRespontMessage.Headers);

            var html1 = httpRespontMessage.Content.ReadAsStringAsync();
            Console.WriteLine(html1);   

            // với một json
            string data = @"{
                ""key1"" : ""giatri1"",
                ""key2"" : ""giatri2""
            }";

            Console.WriteLine(data);  

            var content1 = new StringContent(data, Encoding.UTF8, "application/json");
            httpMessageRequest.Content = content1;

            httpMessageRequest.RequestUri = new Uri("https://www.posman-echo.com/post");

            var httpRespontMessage1 = await httpClient.SendAsync(httpMessageRequest);

            ShowHeader(httpRespontMessage1.Headers);

            var html2 = httpRespontMessage1.Content.ReadAsStringAsync();
            Console.WriteLine(html2);

            // MultiPartForm

            var content2 = new MultipartFormDataContent();
            //upload file 1.txt

            Stream fileStream = File.OpenRead("1.txt"); // mở file ra đọc
            //tạo ra nội dung đính kèm vaod Http Request
            var fileUpload = new StreamContent(fileStream);
            content2.Add(fileUpload, "fileUpload", "abc");
            //
            content2.Add(new StringContent("value1"), "key1");
            httpMessageRequest.Content = content2;

            var httpRespontMessage2 = await httpClient.SendAsync(httpMessageRequest);

            ShowHeader(httpRespontMessage2.Headers);

            var html3 = httpRespontMessage2.Content.ReadAsStringAsync();
            Console.WriteLine(html3);
        }
    }
}
