using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;

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

        

        static void Main(string[] args)
        {
            CreateDatabase();
            

        }
}
}
