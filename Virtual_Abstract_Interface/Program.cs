using System;

namespace Virtual_Abstract_Interface
{
    // Virtual Menthod (Phương thức ảo) là một phương thức được định nghĩa trong lớp cơ sở, nó có thể được ghi đè bởi lớp kế thừa
    class Product
    {
        protected double Price { set; get; }

        public virtual void ProductInfo()
        {
            Console.WriteLine($"Giá sản phẩm {Price}");
        }

        public void Test() => ProductInfo();
    }

    class Iphone : Product
    {
        public Iphone() => Price = 500;

        // nạp chồng phương thức
        public override void ProductInfo()
        {
            Console.WriteLine("Điện thoại Iphone");
            base.ProductInfo();
        }
    }

    // abstract (lớp trừu tượng) không được dùng để tạo ra một đối tượng
    /* interface (giao diện) dùng làm cơ sở cho các lớp kế thừa, khác abstract ở chỗ là các phương thức trong interface 
    thì mặc định chỉ cần khai báo tên và nó là phương thức trừu tượng, miễn là lớp cơ sở định nghĩa lại phương thức đó  */


    class Program
    {
        static void Main(string[] args)
        {
            Iphone iphone = new Iphone();
            iphone.Test();
        }
    }
}
