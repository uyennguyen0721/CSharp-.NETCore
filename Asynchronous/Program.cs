using System;
using System.Threading;
using System.Threading.Tasks;

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

        //Task

        /*Cách 1: Task task = new Task(Action); 
           tương ứng với một delegate không có tham số và không cần trả về giá trị

           Task task1 = new Task(
               () =>
               {
                   DoSomeThing(3, "Task 1", ConsoleColor.Green);
               }
           ); */

        /*Cách 2: Task task1 = new Task(Action<Object>, Object);
         tham số thứ 1 tương đương với cả một biểu thức lamda có nhân một tham số kiểu Object và không cần có kiểu trả về
         tham số thứ 2 được dùng để truyền vào cái Action, nó được dùng làm tham số của Action

        Task task2 = new Task(
            (object obj) =>
            {
                DoSomeThing(4, (string)obj, ConsoleColor.Blue);
            }, "Task 2"
        ); */

        /* async/ await : hai từ khóa được thêm vào các phương thức để tạo ra phương thức bất đồng bộ 
         Khi khai báo một phương thức trở thành một phương thức bất đồng bộ, ta thực hiện:
            VD: static async Task task1(){ 
                    ....
                }*/

        static async Task Task1()
        {
            Task task1 = new Task(
                () =>
                {
                    DoSomeThing(3, "Task 1", ConsoleColor.Green);
                }
            );
            task1.Start();
            await task1; // tương đương với lệnh task1.Wait();
            // task1.Wait();
            Console.WriteLine("Task 1 đã hoàn thành");
            // return task1; vì có await nên ko cần return, do đó ko khóa các thread chính khác
        }

        static async Task Task2()
        {
            Task task2 = new Task(
                (object obj) =>
                {
                    DoSomeThing(4, (string)obj, ConsoleColor.Blue);
                }, "Task 2"
            );
            task2.Start();
            await task2;
            // task2.Wait();
            Console.WriteLine("Task 2 đã hoàn thành");
            // return task2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-----");

            //Task

            //Khởi chạy các tác vụ, các tác vụ này sẽ chạy trên các thread khác nhau
            /* Vì mỗi phương thức đều gọi Wait nên khi t1 chạy xong t2 mới chạy, t2 chạy xong mới đến DoSomeThing*/
            Task t1 = Task1(), t2 = Task2();

            DoSomeThing(5, "fdg", ConsoleColor.Yellow); // 5 lần sleep, mỗi lần 1000 ms (1s)

            // Task.WaitAll(t1, t2); //Chờ 2 tác vụ task1, task2 xong
            /*t1.Wait();
            t2.Wait(); // sau khi t2 hoàn thành thì mới thực hiện các tác vụ phía sau Wait */

            Console.WriteLine("Hello World!");
            Console.ReadKey(); //Khi nhấn 1 phím bất kì thì hàm main dừng lại
        }
    }
}
