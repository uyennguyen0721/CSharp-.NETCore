using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlStringConn = "Data Source = localhost,80; Initial Catalog = xtlab; User ID = sa; Password = 123456789";  // chuối kết nối
            using var conn = new SqlConnection(sqlStringConn);
            Console.WriteLine(conn.State); //trạng thái của conn
            conn.Open();
            Console.WriteLine(conn.State); //trạng thái của conn

        }
    }
}
