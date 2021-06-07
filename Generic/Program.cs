using System;

namespace Generic
{
    /* Generic còn được gọi là kiểu đại diện. Khi ta dùng các giải thuật trong các phương thức, trong các lớp,
    việc áp dụng Generic giúp chung ta dùng lại code một các tối đa, chúng ta không phải mất công viết code lại
    nhiều lần khi các giải thuật về logic giống nhau. */

    class Product<A>
    {
        private A ID;

        public A GetID()
        {
            return this.ID;
        }

        public void SetID(A iD)
        {
            this.ID = iD;
        }
        
    }

    class Program
    {
        static void Swap<T>(ref T x, ref T y) // T là kiểu đại diện, có thể là double, string, int,... mà khi hiện thực hóa ở hàm main mới biết được
        {
            T t;
            t = x;
            x = y;
            y = t;
        }


        static void Main(string[] args)
        {
            string x = "ABC", y = "XYZ";
            Console.WriteLine($"a = {x}, b = {y}");
            Swap(ref x, ref y); // T là kiểu dữ liệu string
            Console.WriteLine($"Sau khi hoán đổi: a = {x}, b = {y}");

            int a = 5, b = 10;
            Console.WriteLine($"a = {a}, b = {b}");
            Swap(ref a, ref b); // T là kiểu dữ liệu int
            Console.WriteLine($"Sau khi hoán đổi: a = {a}, b = {b}");

            Product<int> product = new Product<int>();
            product.SetID(123);
            Console.WriteLine($"ID = {product.GetID()}");
        }
    }
}
