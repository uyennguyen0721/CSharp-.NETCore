using System;
using System.Threading;

namespace Asynchronous
{
    class Program
    {
        /* Asynchronous - lập trình bất đồng bộ - đây là kỹ thuật lập trình tạo ra những ứng dụng có khả năng chạy đa luồng
         (multi thread) */

        /* Giả sử ta có một biến tham chiếu nào đó, ví dụ như một chuỗi a:
                string a = "abc";
        Biến a này có thể sử dụng nhiều luồng (thread), đến một lúc nào đó, ta muốn biến a này khóa lại chỉ được sử dụng bởi
        luồng hiện tại , các luồng khác ko được phép truy cập vào a. Những luồng khác muốn truy cập vào a phải đợi luồng hiện
        tại mở khóa biến a này ra thì mới được truy cập, lúc đấy ta thực hiện như sau: 
                lock(a){
                    ...// chỉ thị lệnh (khối lệnh)
                }
        Khi thực hiện hết khối lệnh này thì biến a sẽ được mở khóa cho các luồng khác có thể truy cập*/

        /* Trong console việc xuất dữ liệu ra màn hình nó sử dụng một đối tượng có kiểu TextWriter, đối tượng này nằm trong Out
                Console.Out*/

        static void DoSomeThing(int seconds, string mgs, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} ... Start");
                Console.ResetColor();
            }
            for (int i = 0; i <= seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs,10} {i,2}");
                    Console.ResetColor();
                    Thread.Sleep(1000); // khi run dừng 5000 ms
                }
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} ... End");
                Console.ResetColor();
            }
        }

        /* Synchronous - Lập trình đồng bộ - là kỹ thuật lập trình cơ bản chạy đơn luồng, khi ứng dụng có nhiều tác vụ
         thì các tác vụ đấy được viết code theo một thứ tự nào đó. Khi thi hành thì các tác vụ đó cũng thi hành theo thứ
        tự đó, tác vụ phía trước trước phải hoàn thành thì tác vụ phái sau mới được thực thi
        
         * Asynchronus - lập trình bất đồng bộ 
           .NET cho phép tạo ra nhiều tác vụ, các tác vụ đó có thể chạy song song với nhau,
        chạy đồng thời với nhau và chạy trên nhiều luồng khác nhau. Lớp để biểu diễn nhiều tác vụ đó là lớp Task, Task<T>*/
        static void Main(string[] args)
        {
            Console.WriteLine("-----");
            DoSomeThing(5, "fdg", ConsoleColor.Green); // 5 lần sleep, mỗi lần 1000 ms (1s)
            Console.WriteLine("Hello World!");
        }
    }
}
