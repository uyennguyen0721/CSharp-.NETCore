using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADO.NET
{
    class Program
    {
        static void ShowDataTable(DataTable table)
        {
            Console.WriteLine($"Tên bảng: {table.TableName}");

            foreach(DataColumn c in table.Columns)
            {
                Console.Write($"{c.ColumnName,15}");
            }

            Console.WriteLine();

            foreach(DataRow r in table.Rows)
            {
                for(int i = 0; i < table.Columns.Count; i++)
                {
                    Console.Write($"{r[i],15}");
                }

                //Console.Write($"{r[0], 20}");
                //Console.Write($"{r["Họ tên"],20}");
                //Console.Write($"{r["Tuổi"],20}");
                Console.WriteLine();
            }
        }

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

            /*
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

            */

            // ********** StoredProcedure

            /*
            command1.CommandText = "getProductInfo";
            command1.CommandType = CommandType.StoredProcedure; // thiết lập kiểu truy vấn

            var id = new MySqlParameter("@id", 0);
            command1.Parameters.Add(id);

            id.Value = 3;

            var reader = command1.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                var tensp = reader["TenSanPham"];
                var tendm = reader["TenDanhMuc"];

                Console.WriteLine($"{tensp} - {tendm}");
            }
            */

            //------------------------- DATA TABLE

            var dataset = new DataSet();
            var table = new DataTable();
            dataset.Tables.Add(table);

            table.Columns.Add("STT");
            table.Columns.Add("Họ tên");
            table.Columns.Add("Tuổi");

            table.Rows.Add(1, "Nguyễn Văn A", 25);
            table.Rows.Add(2, "Nguyễn Thị B", 23);
            table.Rows.Add(3, "Nguyễn Văn C", 26);

            ShowDataTable(table);

            //-------------------------- DATA ADAPTER

            var adapter = new MySqlDataAdapter();
            adapter.TableMappings.Add("Table", "NhanVien"); // thiết lập một ánh xạ một bảng Table tương ứng với bảng NhanVien trong CSDL

            var dataSet = new DataSet();

            // select command
            adapter.SelectCommand = new MySqlCommand("SELECT NhanviennID, Ten, Ho FROM Nhanvien", conn1);

            // insert command
            adapter.InsertCommand = new MySqlCommand("INSERT INTO Nhanvien (Ho, Ten) values (@Ho, @Ten)", conn1);
            adapter.InsertCommand.Parameters.Add("@Ho", MySqlDbType.VarChar, 255, "Ho"); // lấy từ cột Ho
            adapter.InsertCommand.Parameters.Add("@Ten", MySqlDbType.VarChar, 255, "Ten"); // lấy từ cột Ten

            // delete command
            adapter.DeleteCommand = new MySqlCommand("DELETE FROM Nhanvien WHERE NhanviennID = @id", conn1);
            var pr1 = adapter.DeleteCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
            pr1.SourceColumn = "NhanviennID"; // lấy từ cột NhanvienID của bảng Nhanvien
            pr1.SourceVersion = DataRowVersion.Original; // lấy phiên bản nào của dữ liệu cập nhật (vd lấy dữ liệu gốc)

            //update command
            adapter.UpdateCommand = new MySqlCommand("UPDATE Nhanvien SET Ho = @Ho, Ten = @Ten WHERE NhanviennID = @id", conn1);
            var pr2 = adapter.UpdateCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
            pr2.SourceColumn = "NhanviennID"; // lấy từ cột NhanvienID của bảng Nhanvien
            pr2.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@Ho", MySqlDbType.VarChar, 255, "Ho"); // lấy từ cột Ho
            adapter.UpdateCommand.Parameters.Add("@Ten", MySqlDbType.VarChar, 255, "Ten"); // lấy từ cột Ten


            adapter.Fill(dataSet); // đổ dữ liệu vào dataSet

            DataTable table1 = dataSet.Tables["NhanVien"];
            ShowDataTable(table1);

            /* thêm một dòng dữ liệu mới
            var row = table1.Rows.Add();
            row["Ten"] = "A";
            row["Ho"] = "Nguyễn Văn"; */

            /* xóa (xóa xong phải cập nhật lại)
            table1.Rows[10].Delete(); // tính từ 0 */

            /* cập nhật
            var r = table1.Rows[9];
            r["Ten"] = "Lan Anh"; */

            // cập nhật lại CSDL trong MySQL từ dataSet
            adapter.Update(dataSet);

            conn1.Close();
        }
    }
}
