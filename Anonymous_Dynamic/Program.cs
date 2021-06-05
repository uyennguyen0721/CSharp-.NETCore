using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymous_Dynamic
{
    class Program
    {
        /* Anonymous là kiểu dữ liệu vô danh. Trong C#, nó hỗ trợ chúng ta tạo ra những đối tượng
         Những đối tượng này bên trong chứa những thuộc tính, mỗi thuộc tính này chứa giá trị mà 
        ta chỉ có thể đọc những giá trị này ra mà không có thể gán vào.
        Để tạo ra một đối tượng Anonymous, ta thực hiện sau: 
                new {<tên thuộc tính 1> = <giá trị 1>, <tên thuộc tính 2> = <giá trị 2>,...}
        
         Thuộc tính kiểu vô danh giúp ta nhanh chóng tạo ra đối tượng, đối tượng đó chỉ chứa các thuộc tính chỉ đọc,
        được sử dụng rất nhiều trong những câu truy vấn LINQ
        
         * Dynamic là kiểu dữ liệu động. Về hình thức, nó khá giống với kiểu dữ liệu ngầm định var.
         Nếu khai báo bằng kiểu dữ liệu ngầm định bắt buộc phải khởi tạo giá trị cho nó. Từ giá trị được gán,
        nó sẽ xác định được kiểu giá trị của biến ngầm định này thuộc kiểu dữ liệu gì. Nếu khai báo biến kiểu dynamic,
        ta không cần nhất thiết gán giá trị liền cho nó. 
        Biến dynamic này có thể được gán bởi bất kỳ đối tượng nào. Kiểu thực sự của dynamic được xác định ở thời điểm thực thi
        tức là thời điểm chạy chương trình, nó khác hoàn toàn với khia báo biến kiểu var.
        Tại thời điểm viết code, biến dynamic chưa xác định được kiểu giá trị của biến nên có thể thoải mái truy cập những
        phương thức, thuộc tính. Những phương thức hay thuộc tính này xác định có hay không thì nó sẽ xác định ở thời điểm thực thi.
        Ở thời điểm biên dịch sẽ không hề có lỗi gì. */


        // Anonymous
        class SinhVien
        {
            public string HoTen { set; get; }
            public int NamSinh { set; get; }
            public string NoiSinh { set; get; }
        }

        // Dynamic
        class Student
        {
            public string Name { set; get; }
            public void Hello() => Console.WriteLine(Name);
        }
        static void PrintInfo(dynamic obj) 
        {
            obj.Name = "Uyên Nguyễn";
            obj.Hello();
        }



        static void Main(string[] args)
        {
            // Kiểu dữ liệu vô danh Anonymous
            // Ví dụ 1
            // tạo ra một biến ngầm định bằng từ khóa var
            var sanpham = new
            {
                Ten = "Iphone 8",
                Gia = 1000,
                NamSX = 2018
            };

            Console.WriteLine(sanpham.Ten);
            Console.WriteLine(sanpham.Gia);

            // Ví dụ 2
            // Tạo ra danh sách tập hợp các sinh viên
            List<SinhVien> sinhViens = new List<SinhVien>()
            {
                new SinhVien(){ HoTen = "Nam", NamSinh = 2000, NoiSinh = "Bình Dương"},
                new SinhVien(){ HoTen = "Dân", NamSinh = 2002, NoiSinh = "Nam Định"},
                new SinhVien(){ HoTen = "Long", NamSinh = 2001, NoiSinh = "Vĩnh Phúc"},
                new SinhVien(){ HoTen = "Minh", NamSinh = 2000, NoiSinh = "Nam Định"}
            };

            // Thực hiện truy vấn LINQ
            var ketqua = from sv in sinhViens
                         where sv.HoTen.Contains("a")
                         select new
                         {
                             Ten = sv.HoTen,
                             NS = sv.NoiSinh
                         };
            foreach (var sv in ketqua)
            {
                Console.WriteLine(sv.Ten + " - " + sv.NS);
            }

            // Kiểu dữ liệu động Dynamic
            Student abc = new Student();
            PrintInfo(abc);
        }
    }
}
