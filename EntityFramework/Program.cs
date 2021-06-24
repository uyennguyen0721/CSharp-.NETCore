using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MySql.Data.MySqlClient;
using System;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ProductDbContext();

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
            using var dbcontext = new ProductDbContext();

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

        static void InsertProduct()
        {
            using var dbcontext = new ProductDbContext();
            var products = new object[]
            {
                new Product(){ ProductName="Sản phẩm 1", Provider="Công ty 1"},
                new Product(){ ProductName="Sản phẩm 2", Provider="Công ty 2"},
                new Product(){ ProductName="Sản phẩm 3", Provider="Công ty 3"}
            };

            dbcontext.AddRange(products);
            int numberRows = dbcontext.SaveChanges();
            Console.WriteLine($"Đã chèn {numberRows} dữ liệu");
        }

        static void ReadProduct()
        {
            using var dbcontext = new ProductDbContext();

            //Linq
            var products = dbcontext.products.ToList();
            products.ForEach(product => product.PrintInfo());

            var qr = from product in dbcontext.products
                     where product.Provider.Contains("Công ty")
                     orderby product.ProductID descending
                     select product;

            qr.ToList().ForEach(product => product.PrintInfo());

            Product product1 = (Product)(from p in dbcontext.products
                               where p.ProductID == 4
                               select p).FirstOrDefault();

            if(product1 != null)
            {
                product1.PrintInfo();
            } 
        }

        static void RenameProduct(int id, string newName)
        {
            using var dbcontext = new ProductDbContext();

            Product product = (Product)(from p in dbcontext.products
                                         where p.ProductID == id
                                         select p).FirstOrDefault();

            if (product != null)
            {
                EntityEntry<Product> entry = dbcontext.Entry(product); // theo dõi sự cập nhật của product
                entry.State = EntityState.Detached; // tách ra không bị theo dõi bởi dbcontext nữa nên khi gọi SaveChanges thì nó ko cập nhật
                product.ProductName = newName;
                int numberRows = dbcontext.SaveChanges();
                Console.WriteLine($"Đã cập nhật {numberRows} dữ liệu");
            }
        }

        static void DeleteProduct(int id)
        {
            using var dbcontext = new ProductDbContext();

            Product product = (Product)(from p in dbcontext.products
                                         where p.ProductID == id
                                         select p).FirstOrDefault();
            if (product != null)
            {
                dbcontext.Remove(product);
                int numberRows = dbcontext.SaveChanges();
                Console.WriteLine($"Đã xóa {numberRows} dữ liệu");
            }

        }

        static void Main(string[] args)
        {
            InsertProduct();
            ReadProduct();
        }
}
}
