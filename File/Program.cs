using System;
using System.IO;

namespace File
{
    class Program
    {
        /* Thư viện .NET cung cấp lớp DriveInfo tại namespace System.IO giúp đọc thông tin các ổ đĩa có trong hệ thống. 
         * Phương thức DriveInfo.GetDrives() trả về mảng gồm các đối tượng DriveInfo, mỗi đối tượng chứa thông tin về một ổ đĩa.
         * Lớp Directory chứa các phương thức tĩnh để làm việc với thư mục */

        //Liệt kê danh sách các file và thư mục con
        static void ListFileDirectory(string path)
        {
            String[] directories = System.IO.Directory.GetDirectories(path);
            String[] files = System.IO.Directory.GetFiles(path);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
                ListFileDirectory(directory); // Đệ quy
            }
        }

        static void Main(string[] args)
        {
            // DriveInfo
            // in các thông tin ổ đĩa trên máy
            var drives = DriveInfo.GetDrives();
            foreach(var drive in drives)
            {
                Console.WriteLine($"Drive: {drive.Name}"); //tên ổ đĩa
                Console.WriteLine($"Drive Type: {drive.DriveType}"); //kiểu ổ đĩa
                Console.WriteLine($"Label: {drive.VolumeLabel}"); //nhãn ổ đĩa
                Console.WriteLine($"Format: {drive.DriveFormat}"); //định dạng ổ đĩa
                Console.WriteLine($"Size: {drive.TotalSize}"); //kích thước ổ đĩa
                Console.WriteLine($"Available: {drive.AvailableFreeSpace}"); //kích thước có hiệu lực còn trống (byte)
                Console.WriteLine($"Free Size: {drive.TotalFreeSpace}"); //kích thuocs còn trống (byte)
                Console.WriteLine("------------------------------");
            }

            // Directory 
            string path = "D:\\QTHCSDL";
            //Directory.CreateDirectory(path); //tạo thư mục ABC
            if (Directory.Exists(path)) //kiểm tra thư mục đó có tồn tại hay không
            {
                Console.WriteLine($"Thư mục {path} tồn tại");
            }
            else
            {
                Console.WriteLine($"Thư mục {path} không tồn tại");
            }

            //Directory.Delete(path); //xóa thư mục ABC
            var files = Directory.GetFiles(path); //lấy các file trong một thư mục nào đó với đường dẫn đầy đủ
            var directories = Directory.GetDirectories(path); //lấy các thư mục con trong thư mục cho trước
            //in các file trong thư mục đó ra
            foreach(var file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine("-----------------------------");

            //in các thư mục con trong thư mục đó ra
            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
            }

            //liệt kê tất cả các file con và thư mục con
            ListFileDirectory(path);




        }
    }
}
