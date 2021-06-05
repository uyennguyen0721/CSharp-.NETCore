using System;

namespace CS_Delegate
{
    class Program
    {
        public delegate void ShowLog(string message);

        // Hai phương thúc tương đồng với kiểu ShowLog: Info, Warning

        static void Info(string s)
        {
            // Thiết lập màu chữ của chuỗi
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(s);

            // Thiết lập về màu mặc định
            Console.ResetColor();
        }

        static void Warning(string s)
        {
            // Thiết lập màu chữ của chuỗi
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(s);

            // Thiết lập về màu mặc định
            Console.ResetColor();
        }

        //Phương thức để minh họa cho Func

        static int Tong(int x, int y) => x + y;

        static int Hieu(int x, int y) => x - y;

        static void Main(string[] args)
        {
            ShowLog log = null;
            log = Info;

            // Nếu log = null thì khi run sẽ báo lỗi nên ta có thể kiểm tra trước khi thực hiện phương thức

            // Cách 1: dùng IF
            if (log != null)
            {
                log("Xin chào"); // Cách viết 1
                log.Invoke("Xin chào ABC"); // Cách viết 2
            }
            else
                Console.WriteLine("Không có phương thức nào được thực hiện vì log = null");

            // Cách 2:
            log?.Invoke("Xin chào");

            log = Warning;
            log("Học về delegate");

            /* Một biến delegate có thể một lúc tham chiếu đến nhiều phương thức 
             có nghĩa là nó có thể tạo ra một chuỗi các tham chiếu bằng toán tử += */

            log = null;
            log += Info;
            log += Warning;

            log?.Invoke("Hello Uyen");

            /* Action, Func: đây là hai kiểu delegate mà thư viện .NET định nghĩa sẵn,
             nó sử dụng tham số gereric để khai báo. Khi khai báo để tạo ra một biến delegate, 
            thay vì ta phải định nghĩa kiểu delegate đó trước, trong một số trường hợp ta có thể khai báo
            bằng kiểu Action, Func. Nếu khai báo một biến thuộc kiểu delegate với kiểu dữ liệu trả về là void 
            hoặc không có kiểu dữ liệu trả về thì ta có thể: */

            Action action;                  // ~ delegate void KIEU();
            Action<string, int> action1;    // ~ delegate void KIEU(string s, int i);
            Action<string> action2;          // ~ delegate void KIEU(string s);

            action2 = Warning;
            action2 += Info;
            action2?.Invoke("Thông báo từ Action");

            /* Sử dụng Func cũng giống như Action nhưng nó phải có kiểu trả về*/

            Func<int> f1; // ~ delegate int KIEU();
            Func<string, double, string> f2; // ~ delegate string KIEU(string s, double d);

            // Ví dụ minh họa cho 2 phương thức Tong, Hieu

            Func<int, int, int> tinhToan; // ~ delegate int KIEU(int x, int y);

            int a = 10, b = 6;

            tinhToan = Tong;
            Console.WriteLine($"Tổng là: {tinhToan(a, b)}");

            tinhToan = Hieu;
            Console.WriteLine($"Hiệu là: {tinhToan(a, b)}");
        }
    }
}
