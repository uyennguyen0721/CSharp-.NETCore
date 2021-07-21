using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestAdapter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table = new DataTable("Nhanvien");
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataSet dataSet = new DataSet();

        public MainWindow()
        {
            InitAdapter();
            InitializeComponent();
        }

        void InitAdapter()
        {
            var sqlStringBuilder1 = new MySqlConnectionStringBuilder();
            sqlStringBuilder1["Server"] = "localhost";
            sqlStringBuilder1["Database"] = "learnnet";
            sqlStringBuilder1["UID"] = "root";
            sqlStringBuilder1["PWD"] = "123456789";
            sqlStringBuilder1["Port"] = "3306";

            using var conn1 = new MySqlConnection(sqlStringBuilder1.ToString());
            conn1.Open();


            using DbCommand command1 = new MySqlCommand();
            command1.Connection = conn1;

            adapter = new MySqlDataAdapter();
            adapter.TableMappings.Add("Table", "NhanVien"); // thiết lập một ánh xạ một bảng Table tương ứng với bảng NhanVien trong CSDL

            dataSet = new DataSet();

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

            dataSet.Tables.Add(table);
        }

        void LoadDataTable()
        {
            table.Rows.Clear();
            adapter.Fill(dataSet);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataTable();
            datagrid.DataContext = table.DefaultView;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadDataTable();
            datagrid.DataContext = table.DefaultView;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            adapter.Update(dataSet);
            table.Rows.Clear();
            adapter.Fill(dataSet);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedItem = (DataRowView)datagrid.SelectedItem;
            if(selectedItem != null)
            {
                selectedItem.Delete();
            }
        }
    }
}
