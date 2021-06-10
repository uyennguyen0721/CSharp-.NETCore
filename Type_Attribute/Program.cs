using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Type_Attribute

// Attribute

/*ObsoleteAttribute: đánh dấu trong code thành phần đó đã lỗi thời, không được sử dụng nữa cần thay thế bằng một cái gì đó 
=> được sử dụng bởi trình biên dịch, đưa ra cảnh báo */
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] // Lớp MoTa này được sử dụng ở đâu (class, property, menthod ...)
    class MoTaAttribute : Attribute
    {
        public string ThongTinChiTiet { set; get; }

        public MoTaAttribute(string thongTin)
        {
            ThongTinChiTiet = thongTin;
        }
    }


    [MoTa("Lớp chứa thông tin về User trên hệ thống")]
    class User
    {
        //[MoTa("Tên người dùng")]
        [Required(ErrorMessage = "Name phải thiết lập")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên phải từ 3 đến 50 kí tự")]
        public string Name { set; get; }

        //[MoTa("Dữ liệu tuổi")]
        [Range(18, 80, ErrorMessage = "Tuổi phải từ 18 đến 80")]
        public int Age { set; get; }

        //[MoTa("Số điện thoại cá nhân")]
        [Phone(ErrorMessage = "Số điện thoại sai cấu trúc")]
        public string PhoneNumber { set; get; }

        //[MoTa("Email cá nhân")]
        [EmailAddress(ErrorMessage = "Email sai cấu trúc")]
        public string Email { set; get; }

        //đánh dấu phương thúc PrintInfo đã lỗi thời và đưa ra cảnh báo
        [Obsolete("Phương thức này đã lỗi thời, vui lòng sử dụng phương thức ShowInfo()")]
        public void PrintInfo() => Console.WriteLine(Name);
    }

    class Program
    {
        /*Type là lớp chứa thông tin về một kiểu dữ liệu nào đó vd như class, struct,..., int, bool,... Lớp Type là một thành phần cơ
bản trong .NET, được dùng cho kĩ thuật Reflection (lấy thông tin của kiểu dữ liệu tại thời điểm thực thi)*/

        /* Attribute (thuộc tính bổ sung) là một phần của share dữ liệu, nó cung cấp thông tin, bổ sung cho một lớp hoặc bổ sung thông
         tin cho thành viên của một lớp. Các thông tin được bổ sung bới Attribute sẽ được sử dụng bởi thư viện, bởi các Framework,
         thậm chí là bởi các trình biên dịch. Các thông tin này sẽ được lấy ra và sử dụng ở thời điểm thực thi. 
         * Để bổ sung Attribute cho một thuộc tính nào của lớp, ta thực hiện như sau:
                   [<AttributeName>(tham số)]*/
        [Obsolete]
        static void Main(string[] args)
        {
            //Type

            //Khi không có đối tượng cụ thể
            Type t1 = typeof(int); //lấy thông tin của kiểu dữ liệu int
            Type t2 = typeof(string); 
            Type t3 = typeof(Array);

            // Khi có một đối tượng cụ thể 
            int[] a = {1, 2, 3, 7, 3, 5, 9 };
            Type t = a.GetType(); // lấy kiểu dữ liệu 

            Console.WriteLine(t.FullName);

            Console.WriteLine("-----Các thuộc tính-----");
            t.GetProperties().ToList().ForEach(
               (PropertyInfo o) =>
               {
                   Console.WriteLine(o.Name); // lấy tên của thuộc tính
                }
            ); // lấy các thuộc tính

            Console.WriteLine("-----Các trường dữ liệu-----");
            t.GetFields().ToList().ForEach(
               (FieldInfo o) =>
               {
                   Console.WriteLine(o.Name); // lấy tên của thuộc tính
               }
            ); // lấy các trường dữ liệu

            Console.WriteLine("-----Các phương thức-----");
            t.GetMethods().ToList().ForEach(
               (MethodInfo o) =>
               {
                   Console.WriteLine(o.Name); // lấy tên của phương thức
               }
            ); // lấy các phương thức

            User user = new User()
            {
                Name = "Uyên",
                Age = 21,
                PhoneNumber = "0123456789",
                Email = "123@gamil.com"
            };

            ValidationContext context = new ValidationContext(user);
            var result = new List<ValidationResult>();

            // kiểm tra tất cả các thuộc tính của đối tượng user
            // nếu trả về true thì tất cả các giá trị của các thuộc tính này phù hợp, ngược lại thì ko phù hợp, giá trị các lỗi được lưu ở biến result
            bool kq = Validator.TryValidateObject(user, context, result, true); 

            if(kq == false)
            {
                result.ToList().ForEach((er) =>
                {
                    Console.WriteLine(er.MemberNames.First());
                    Console.WriteLine(er.ErrorMessage);
                });
            }

            var properties = user.GetType().GetProperties();
            foreach(PropertyInfo property in properties)
            {
                string name = property.Name; // lấy tên thuộc tính
                var value = property.GetValue(user); // lấy giá trị thuộc tính của đối tượng user
                Console.WriteLine($"{name} : {value}");
            }

            foreach (PropertyInfo property in properties)
            {
                foreach(var attri in property.GetCustomAttributes(false))
                {
                    MoTaAttribute moTa = attri as MoTaAttribute;
                    if (moTa != null)
                    {
                        Console.WriteLine(moTa.ThongTinChiTiet);
                        string name = property.Name;
                        var value = property.GetValue(user); // lấy giá trị thuộc tính của đối tượng user
                        Console.WriteLine($"({name}) - {moTa.ThongTinChiTiet} : {value}");
                    }
                }
            }





        }
    }
}
