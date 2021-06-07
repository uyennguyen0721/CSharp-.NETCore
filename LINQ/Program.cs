using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    /* LINQ (Language Integrated Query - ngôn ngữ truy vấn tích hợp) có các câu lệnh khá giống với câu truy vấn của SQL
     nó truy vấn trên các nguồn dữ liệu (thường là các tập hợp phần tử triển khai trên những giao diện IEnumerable, Enumerable<T>
                                            - Array, List, Stack, Queue.../ File XML, SQL)
    Các nguồn dữ liệu này sẽ được nạp vào chương trình và được thể hiện qua các lớp và đối tượng sau đó truy vấn LINQ sẽ
    thực hiện trên các nguồn dữ liệu đó */

    // Nguồn dữ liệu
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // cá màu
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

    }

    // Biểu diễn thương hiệu
    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Danh sách các thương hiệu
            var brands = new List<Brand>()
            {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"}
            };

            // Danh sách sản phẩm
            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };

            // Lấy ra những sản phầm có giá bằng 400
            var query = from p in products
                        where p.Price == 400
                        select p;
            foreach(var q in query)
            {
                Console.WriteLine(q);
            }

            Console.WriteLine("---------------------------------------------------");

            // lấy tên sản phẩm bằng Select => kết quả là tập hợp các mảng chuỗi
            var kq = products.Select(p => p.Name + " - " + p.Price); 
            foreach(var k in kq)
            {
                Console.WriteLine(k);
            }

            Console.WriteLine("---------------------------------------------------");

            // lấy ra những sản phẩm có tên chứa "tr" bằng Where
            var a = products.Where((p) =>
            {
                return p.Name.Contains("tr");
            });
            foreach(var i in a)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("---------------------------------------------------");

            //SelectMany: phương thức này khá giống với Select => kết quả là tập hợp các chuỗi
            var x = products.SelectMany((p) =>
            {
                return p.Colors;
            });
            foreach(var i in x)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("---------------------------------------------------");

            //Min, Max, Sum, Average
            int[] numbers = { 2, 1, 6, 4, 5, 7, 9, 3 };
            Console.WriteLine($"Số lớn nhất trong mảng: {numbers.Max()}");
            Console.WriteLine($"Số nhỏ nhất trong mảng: {numbers.Min()}");
            Console.WriteLine($"Tổng của mảng: {numbers.Sum()}");
            Console.WriteLine($"Trung bình cộng của mảng: {numbers.Average()}");
            Console.WriteLine($"Số chẵn lớn nhất trong mảng {numbers.Where(n => n % 2 == 0).Max()}");

            Console.WriteLine("---------------------------------------------------");

            //Join
            var h = products.Join(brands, i => i.Brand, b => b.ID, (i, b) =>
            {
                return new
                {
                    Ten = i.Name, 
                    ThuongHieu = b.Name
                };
            });
            foreach(var i in h)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("---------------------------------------------------");

            //GroupJoin: dữ liệu trả về được nhóm lại theo nguồn dữ liệu ban đầu
            var m = brands.GroupJoin(products, i => i.ID, b => b.Brand, (brand, pros) =>
            {
                return new
                {
                    ThuongHieu = brand.Name,
                    CacSP = pros
                };
            });
            foreach(var i in m)
            {
                Console.WriteLine($"Thương hiệu: {i.ThuongHieu}");
                foreach(var j in i.CacSP)
                {
                    Console.WriteLine($"- {j}");
                }
            }

            Console.WriteLine("---------------------------------------------------");

            //Take: lấy ra một số sản phẩm đầu tiên
            //lấy 4 sp đầu tiên
            Console.WriteLine("Bốn sản phẩm đầu tiên là: ");
            products.Take(4).ToList().ForEach(i => Console.WriteLine(i));

            Console.WriteLine("---------------------------------------------------");

            //Skip: bỏ qua những phần tử đầu tiên và lấy ra những phần tử còn lại
            //bỏ qua 2 sp đầu tiên và lấy các sp còn lại
            Console.WriteLine("Các sản phẩm còn lại sau khi bỏ qua 2 sp đầu tiên là: ");
            products.Skip(2).ToList().ForEach(i => Console.WriteLine(i));

            Console.WriteLine("---------------------------------------------------");

            //OrderBy (sắp xếp theo thứ tự tăng dần) / OrderByDecending (sắp xếp theo thứ tự giảm dần)
            Console.WriteLine("Sắp xếp theo thứ tự tăng dần: ");
            products.OrderBy(p => p.Price).ToList().ForEach(i => Console.WriteLine(i));

            Console.WriteLine("Sắp xếp theo thứ tự giảm dần: ");
            products.OrderByDescending(p => p.Price).ToList().ForEach(i => Console.WriteLine(i));

            Console.WriteLine("---------------------------------------------------");

            //Reverse: đảo ngược thứ tự các phần tử trong tập hợp
            Console.WriteLine("Khi chưa đảo ngươc: ");
            numbers.ToList().ForEach(i => Console.WriteLine(i));

            Console.WriteLine("Sau khi đảo ngươc: ");
            numbers.Reverse().ToList().ForEach(i => Console.WriteLine(i));

            Console.WriteLine("---------------------------------------------------");

            //GroupBy: Trả về một tập hợp, mỗi phần tử là một nhóm theo một dữ liệu nào đó
            var n = products.GroupBy(p => p.Price);
            foreach(var group in n)
            {
                Console.WriteLine($"Nhóm các sp giá {group.Key}:");
                foreach(var j in group)
                {
                    Console.WriteLine(j);
                }
            }

            Console.WriteLine("---------------------------------------------------");

            //Distinct: loại bỏ các phần tử có cùng giá trị
            products.SelectMany(p => p.Colors).Distinct().ToList().ForEach(mau => Console.WriteLine(mau));

            Console.WriteLine("---------------------------------------------------");

            /*Single (kiểm tra phần tử thỏa mãn ĐK logic nào đó, nếu trong KQ có 1 phần tử thỏa mãn thì trả về phần tử đó,
             nếu ko có phần tử nào hay nhiều hơn 1 phần tử thỏa mãn thì sẽ phát sinh lỗi.
             * SingleOrDefault: tương tự như Single nhưng chỉ khác ở chỗ nếu không có phần tử nào thì sẽ trả giá trị là null*/

            var y = products.Single(p => p.Price == 600);
            Console.WriteLine(y);

            var z = products.SingleOrDefault(p => p.Price == 1000);
            if(z != null)
            {
                Console.WriteLine(z);
            }
            else
            {
                Console.WriteLine("Không có sản phẩm nào");
            }

            Console.WriteLine("---------------------------------------------------");

            //Any: trả về True nếu thỏa mãn ĐK, ngược lại trả về False
            //Kiểm tra có sp nào có giá bằng 400 không
            Console.WriteLine(products.Any(p => p.Price == 400)); //True

            Console.WriteLine("---------------------------------------------------");

            //All: tất cả các phần tử phải thỏa mãn các ĐK logic, trả về True/ False
            //Kiểm tra tất cả các sp này có giá từ 200 trở lên không
            Console.WriteLine(products.All(p => p.Price >= 200)); //True

            Console.WriteLine("---------------------------------------------------");

            //Count: phương thức đếm tất cả các phần tử trong tập hợp
            Console.WriteLine(products.Count()); //đếm có bao nhiêu sp
            Console.WriteLine(products.Count(p => p.Price >= 300)); //đếm các sp có giá >= 300 

            Console.WriteLine("---------------------------------------------------");

            //In ra tên sản phẩm, tên thương hiệu, có giá (300 - 400), sắp xếp giá giảm dần
            products.Where(p => p.Price >= 300 && p.Price <= 400) 
                    .OrderByDescending(p => p.Price)
                    .Join(brands, p => p.Brand, b => b.ID, (sp, th) =>
                    {
                        return new
                        {
                            Ten = sp.Name,
                            ThuongHieu = th.Name,
                            Gia = sp.Price
                        };
                    }).ToList().ForEach(info =>
                    {
                        Console.WriteLine($"{info.Ten,15} - {info.ThuongHieu,15} - {info.Gia, 5}"); //15, 5 lần lượt là số các kí tự
                    });

            Console.WriteLine("---------------------------------------------------");

            //sử dùng linq
            /* 1. Xác định nguồn dữ liệu: from <tên phần tử> in IEnumerables
                  ... join, where, order by ...
               2. Lấy dữ liệu: select, group by,...
             */

            var qr1 = from q in products 
                      where q.Price >= 400
                      select new 
                      { 
                          Ten = q.Name,
                          Gia = q.Price
                      };
            qr1.ToList().ForEach(name => Console.WriteLine(name));

            Console.WriteLine("---------------------------------------------------");

            //Lấy ra các sản phẩm có giá <= 500, màu xanh
            var qr2 = from q in products
                      from color in q.Colors
                      where q.Price <= 500 && color == "Xanh"
                      orderby q.Price descending //sắp xếp giảm dần, nếu tăng dần thì bỏ 'descending'
                      select new
                      {
                          Ten = q.Name,
                          Gia = q.Price,
                          CacMau = q.Colors
                      };
            qr2.ToList().ForEach(name => 
            {
                Console.WriteLine($"{name.Ten} - {name.Gia} - {string.Join(',', name.CacMau)}");
                // string.Join(',', name.CacMau) nối các màu trong mảng thành 1 chuỗi
            });

            Console.WriteLine("---------------------------------------------------");

            //nhóm sản phẩm theo giá
            var qr3 = from p in products
                      group p by p.Price into gr // lưu vào một biến tạm có tên là 'gr'
                      orderby gr.Key //sắp xếp tăng dần theo giá với giá là key
                      let soluong = "Số lượng là " + gr.Count() // khai báo biến soluong
                      select new
                      {
                          Gia = gr.Key,
                          CacSP = gr.ToList(),
                          SoLuong = soluong
                      };
            qr3.ToList().ForEach(i =>
            {
                Console.WriteLine($"Giá: {i.Gia} - Số lượng: {i.SoLuong} - Các sản phẩm: ");
                i.CacSP.ForEach(p => Console.WriteLine(p));
            });

            Console.WriteLine("---------------------------------------------------");

            // liệt kê danh sách sp gồm tên sp, thương hiệu, giá
            // chỉ lấy các sp có thương hiệu được lưu trong brands
            var qr4 = from p in products
                      join b in brands on p.Brand equals b.ID // sau on là câu lệnh ĐK: p.Brand == b.ID nhưng ko dùng dấu '==' để thể hiện mà dùng từ khoá equals
                      select new
                      {
                          Ten = p.Name,
                          Gia = p.Price,
                          ThuongHieu = b.Name
                      };
            qr4.ToList().ForEach(o =>
            {
                Console.WriteLine($"{o.Ten, 10} - {o.Gia, 5} - {o.ThuongHieu, 15}");
            });

            Console.WriteLine("---------------------------------------------------");

            //lấy hết tất cả sp kể cả ko có trong brands
            var qr5 = from p in products
                      join b in brands on p.Brand equals b.ID into t // sau on là câu lệnh ĐK: p.Brand == b.ID nhưng ko dùng dấu '==' để thể hiện mà dùng từ khoá equals
                      from b in t.DefaultIfEmpty() // với mỗi sp có 1 nhãn hiệu lưu trong 't', nếu sp đó ko lưu được nhãn hiệu trong 't' thì trả về null, nếu có thì trả về giá trị đó
                      select new
                      {
                          Ten = p.Name,
                          Gia = p.Price,
                          ThuongHieu = (b != null) ? b.Name : "Không có thương hiệu"
                      };
            qr5.ToList().ForEach(o =>
            {
                Console.WriteLine($"{o.Ten,10} - {o.Gia,5} - {o.ThuongHieu,15}");
            });
        }
    }
}
