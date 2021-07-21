using Entity_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System;

namespace Entity_Models
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new shopdataContext();

            //lấy tên CSDL
            string dbname = dbcontext.Database.GetDbConnection().Database;

            //kiểm tra trên server, nếu CSDL đó không có thì nó sẽ tạo ra CSDL đó, nếu trong CSDL không có các bảng trong dbcontext thì nó sẽ tạo ra các bảng đó
            var kq = dbcontext.Database.EnsureCreated();
            if (kq)
            {
                Console.WriteLine($"Tạo db {dbname} thành công");
            }
            else
            {
                Console.WriteLine($"Không tạo được {dbname}");
            }

        }

        static void DropDatabase()
        {
            using var dbcontext = new shopdataContext();

            //lấy tên CSDL
            string dbname = dbcontext.Database.GetDbConnection().Database;

            var kq = dbcontext.Database.EnsureDeleted();
            if (kq)
            {
                Console.WriteLine($"Xóa {dbname} thành công");
            }
            else
            {
                Console.WriteLine($"Không xóa được {dbname}");
            }
        }

        static void InsertData()
        {
            using var dbcontext = new shopdataContext();
            //Category category1 = new Category()
            //{
            //    CategoryName = "Điện thoại",
            //    Description = "Các loại điện thoại"
            //};

            //Category category2 = new Category()
            //{
            //    CategoryName = "Laptop",
            //    Description = "Các loại laptop"
            //};

            //dbcontext.Categories.Add(category1);
            //dbcontext.Categories.Add(category2);

            Category c1 = (Category)(from c in dbcontext.Categories
                                     where c.CategoryId == 1
                                     select c).FirstOrDefault();

            Category c2 = (Category)(from c in dbcontext.Categories
                                     where c.CategoryId == 2
                                     select c).FirstOrDefault();

            dbcontext.Add(new Product()
            {
                ProductName = "Iphone 8",
                Price = 7,
                Unit = "triệu",
                Category = c1
            });

            dbcontext.Add(new Product()
            {
                ProductName = "Samsung Galaxy Note 10",
                Price = 20,
                Unit = "triệu",
                Category = c1
            });

            dbcontext.Add(new Product()
            {
                ProductName = "MacBook Pro Max",
                Price = 35,
                Unit = "triệu",
                Category = c2
            });

            dbcontext.SaveChanges();

            Console.WriteLine("Thêm dữ liệu thành công");
        }

        static void ReadProduct()
        {
            using var dbcontext = new shopdataContext();

            //Linq
            var products = dbcontext.Products.ToList();
            products.ForEach(product => product.PrintInfo());

            var qr = from product in dbcontext.Products
                     where product.Price >= 200
                     orderby product.ProductId descending
                     select product;

            qr.ToList().ForEach(product => product.PrintInfo());

            Product product1 = (Product)(from p in dbcontext.Products
                                         where p.ProductId == 4
                                         select p).FirstOrDefault();

            //var e = dbcontext.Entry(product1);
            //e.Reference(p => p.Category).Load();

            if (product1 != null)
            {
                product1.PrintInfo();
            }

            //if(product1.Category != null)
            //{
            //    Console.WriteLine($"{product1.Category.CategoryName} - {product1.Category.Description}");
            //}
            //else
            //{
            //    Console.WriteLine("Category == null");
            //}

            Console.WriteLine("------------------------------");

            //Tìm theo ID
            var pr = dbcontext.Products.Find(3);
            pr.PrintInfo();

            Console.WriteLine("------------------------------");

            //Tìm các sp có giá >= 500
            var products1 = from p in dbcontext.Products
                           where p.Price >= 10
                           select p;
            products1.ToList().ForEach(p => p.PrintInfo());

            Console.WriteLine("------------------------------");

            //In ra các sản phẩm có chứa kí tự "a" trong tên
            var products2 = from p in dbcontext.Products
                            where p.ProductName.ToLower().Contains("a")
                            orderby p.Price descending
                            select p;
            products2.Take(2).ToList().ForEach(p => p.PrintInfo()); //Take(2) : lấy ra 2 sp

            Console.WriteLine("------------------------------");

            //lấy ra tên các sp, giá, loại sp, mô tả
            var products3 = from p in dbcontext.Products
                            join c in dbcontext.Categories on p.Category.CategoryId equals c.CategoryId
                            select new
                            {
                                ten = p.ProductName,
                                gia = p.Price,
                                loai = c.CategoryName,
                                mota = c.Description
                            };
            products3.ToList().ForEach(p => Console.WriteLine($"{p.ten,25} {p.gia,10} {p.loai,15} {p.mota,25}"));
        }


        static void Main(string[] args)
        {
            //InsertData();
            ReadProduct();

        }
    }
}
