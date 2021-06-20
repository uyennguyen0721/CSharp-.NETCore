using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //----------------------- kết nối với SQL SERVER

            // chuỗi kết nối
            var sqlStringBuilder = new SqlConnectionStringBuilder();
            sqlStringBuilder["Server"] = "DESKTOP-3VODAHR";
            sqlStringBuilder["Database"] = "xtlab";
            sqlStringBuilder["UID"] = "sa";
            sqlStringBuilder["PWD"] = "123456789";

            Console.WriteLine(sqlStringBuilder.ToString());

            
            //string sqlStringConn = "Server=127.0.0.1; Initial Catalog = xtlab; User ID = sa; Password = 123456789";  // chuối kết nối
            //using var conn = new SqlConnection(sqlStringConn);
            //Console.WriteLine(conn.State); //trạng thái của conn
            //conn.Open();
            //Console.WriteLine(conn.State); //trạng thái của conn
            

            using var conn = new SqlConnection(sqlStringBuilder.ToString());
            conn.Open();

            // truy vấn (cần sử dụng từ khóa using để có thể tự động giải phóng tài nguyên)

            using DbCommand command = new SqlCommand();
            command.Connection = conn; // Thiết lập kết nối là gì 
            command.CommandText = "SELECT TOP (5) * FROM SanPham "; // Lây s5 sản phẩm đầu tiên

            // truy vấn và lấy dữ liệu về
            command.ExecuteReader();
            var dataReader = command.ExecuteReader();
            while (dataReader.Read()) // đọc các trường dữ liệu, trả về TRUE thì đọc được, ngược lại không đọc được
            {
                Console.WriteLine($"{dataReader["Tensanpham"], 10} Gia {dataReader["Gia"], 8}");
            }

            conn.Close();
            */

            //--------------------------- KẾT NỐI VỚI MYSQL

            var sqlStringBuilder1 = new MySqlConnectionStringBuilder();
            sqlStringBuilder1["Server"] = "localhost";
            sqlStringBuilder1["Database"] = "learnnet";
            sqlStringBuilder1["UID"] = "root";
            sqlStringBuilder1["PWD"] = "123456789";
            sqlStringBuilder1["Port"] = "3306";

            Console.WriteLine(sqlStringBuilder1.ToString());

            using var conn1 = new MySqlConnection(sqlStringBuilder1.ToString());
            conn1.Open();

            
            using DbCommand command1 = new MySqlCommand();
            command1.Connection = conn1; // Thiết lập kết nối là gì 

            /*
            command1.CommandText = "SELECT * FROM SanPham LIMIT 0, 10 "; // Lây 10 sản phẩm từ 0 đến 10
            var dataReader1 = command1.ExecuteReader();

            while (dataReader1.Read()) // đọc các trường dữ liệu, trả về TRUE thì đọc được, ngược lại không đọc được
            {
                Console.WriteLine($"{dataReader1["Tensanpham"],10} Gia {dataReader1["Gia"],8}");
            }
            */

            //----------------------- SQL COMMAND

            command1.CommandText = "SELECT DanhmucID, TenDanhMuc, Mota FROM Danhmuc WHERE DanhmucID >= @DanhmucID"; // @DanhmucID là một biến

            var danhMucID = new MySqlParameter("@DanhmucID", 5); // tạo một biến Parameter và gán cho @DanhmucID = 5
            command1.Parameters.Add(danhMucID);

            danhMucID.Value = 3; // thiết lập lại danhMucID = 1000

            // command1.ExecuteReader(); => dùng khi kết quả trả về có nhiều dòng

            using var sqlReader = command1.ExecuteReader();
            if(sqlReader.HasRows) // kiểm tra có dòng dữ liệu nào trả về hay không
            {
                //sqlReader.Read(); // đọc một dòng dữ liệu, nếu gọi lần đầu tiên thì nó sẽ trả về dòng dữ liệu đầu tiên sau đó con trỏ sẽ nhảy xuống dòng dữ liệu thứ 2, 
                //nếu gọi tiệp lệnh đó nó sẽ trả về tiếp dòng dữ liệu thứ 2
                while (sqlReader.Read())    //trả về FALSE khi đến cuối tập dữ liệu
                {
                    //đọc trường dữ liệu của các dòng dữ liệu đó ra (nếu biết trước kiểu dữ liệu)
                    var id = sqlReader.GetInt32(0); // trường dữ liệu thứ nhất (ID)

                    //đọc trường dữ liệu của các dòng dữ liệu đó ra (nếu chưa biết trước kiểu dữ liệu)
                    var ten = sqlReader["TenDanhMuc"]; //dùng tên trường dữ liệu
                    var mota = sqlReader[2]; // dùng chỉ số
                    Console.WriteLine($"{id} - {ten} - {mota}");
                }
            }
            else
            {
                Console.WriteLine("Không có dòng dữ liệu trả về");
            }

            // ******* dùng Data table 

            var datatable = new DataTable();
            datatable.Load(sqlReader); // các đối tượng truy vấn ở sqlReader được lưu ở datatable
                                       //..... truy vấn lấy dữ liêu ...


            //command1.ExecuteScalar(); // trả về một giá trị (dòng 1, cột 1) mặc dù kết quả trả về là một tập dữ liệu
            //command1.ExecuteNonQuery(); // Insert, Update, Delete; nó ko trả về dữ liệu mà chỉ trả về số dòng dữ liệu bị tác động

            conn1.Close();
        }
    }
}
