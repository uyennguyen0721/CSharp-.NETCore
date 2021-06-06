using System;

namespace CS_Event
{
    public delegate void SuKienNhapSo(int x);

    //publisher

    class DuLieuNhap : EventArgs //Lớp DuLieuNhap kế thừa lớp EventArgs
    {
        public int data { set; get; } // Thuộc tính
        public DuLieuNhap(int x) => data = x;

    }
  
    class UserInput
    {
        // Phải thêm từ khóa event vô vì khi ko có event, nếu có 2 sự kiện cùng đki thì nó sẽ hủy các sự kiện đki trước đó và giữ lại sự kiện đăng ký sau cùng.
        // Khi thêm từ khóa event vào biến delegate thì nó là một trường dữ liệu nên ko thể có { set; get; } ở cuối được 
        public event SuKienNhapSo suKienNhapSo;

        public event EventHandler sukiennhapso; // ~ delegate void KIEU(object? sender, EventArgs args);

        public void Input()
        {
            do
            {
                Console.WriteLine("Nhập vào một số nguyên: ");
                string s = Console.ReadLine();
                int i = Int32.Parse(s); // Chuyển chuỗi nhập vào thành số nguyên
                // Phát sự kiện
                suKienNhapSo?.Invoke(i);

                sukiennhapso?.Invoke(this, new DuLieuNhap(i));
            }
            while (true); // Trong lặp vô tận, muốn dừng chương trình chỉ cần nhấn Ctrl + C
        }
    }

    //Subscriber
    class TinhCan
    {
        public void Sub(UserInput userInput) // Đăng ký nhận sự kiện nhập số
        {
            // Khi thêm từ khóa event vào biến delegate thì nó chỉ có thể thực hiện được các phép toán +=, -=, không thể thực hiện được phép toán gán
            userInput.suKienNhapSo += Can1; // -= là hủy đăng ký
            userInput.sukiennhapso += Can2;
        }
        public void Can1(int x)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Căn bậc 2 của {x} là {Math.Sqrt(x)}");
            Console.ResetColor();
        }

        public void Can2(Object sender, EventArgs e)
        {
            DuLieuNhap duLieuNhap = (DuLieuNhap)e;
            int i = duLieuNhap.data;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Căn bậc 2 của {i} là {Math.Sqrt(i)}");
            Console.ResetColor();
        }
    }

    class BinhPhuong
    {
        public void Sub(UserInput userInput) // Đăng ký nhận sự kiện nhập số
        {
            // Khi thêm từ khóa event vào biến delegate thì nó chỉ có thể thực hiện được các phép toán +=, -=, không thể thực hiện được phép toán gán
            userInput.suKienNhapSo += TinhBinhPhuong1; // -= là hủy đăng ký
            userInput.sukiennhapso += TinhBinhPhuong2;
        }
        public void TinhBinhPhuong1(int x)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Bình phương của {x} là {Math.Pow(x, 2)}");
            Console.ResetColor();
        }
        public void TinhBinhPhuong2(Object sender, EventArgs e)
        {
            DuLieuNhap duLieuNhap = (DuLieuNhap)e;
            int i = duLieuNhap.data;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Bình phương của {i} là {Math.Pow(i, 2)}");
            Console.ResetColor();
        }
    }


    class Program
    {
        /* Lập trình hướng sự kiện (Event) là một kĩ thuật lập trình có thể lý giải vắn tắt như sau: 
         Chúng ta xây dựng ra những lớp mà nó có thể phát đi những sự kiện nghĩa là nó thông báo có một sự kiện
        nào đó xảy ra. Những lớp đó ta gọi là Publisher. Khi sự kiện do Publisher phát đi thì sẽ có những lớp đăng ký
        nếu có sự kiện đó xảy ra thì sẽ nhận được thông tin. Những lớp nhận được thông tin khi có sự kiện Publisher
        xảy ra được gọi là Subsriber. */

        static void Main(string[] args)
        {
            // Bắt sự kiện CancelKeyPress
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine();
                Console.WriteLine("Thoát ứng dụng");
            };

            //publisher
            UserInput userInput = new UserInput();
            // Có thể gán bằng một biểu thức lamda và bt lamda này phải phù hợp với biến delegate
            userInput.suKienNhapSo += x =>
            {
                Console.WriteLine("Bạn vừa nhập số: " + x);
            };

            userInput.sukiennhapso += (sender, e) =>
            {
                DuLieuNhap duLieuNhap = (DuLieuNhap)e;
                Console.WriteLine("Bạn vừa nhập số: " + duLieuNhap.data);
            };

            //subscriber
            TinhCan tinhCan = new TinhCan();
            tinhCan.Sub(userInput);

            BinhPhuong binhPhuong = new BinhPhuong();
            binhPhuong.Sub(userInput);

            userInput.Input();
        }
    }
}
