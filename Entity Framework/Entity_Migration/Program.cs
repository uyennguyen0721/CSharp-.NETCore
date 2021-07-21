using System;

namespace Entity_Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            //Migration: thực hiện code => cập nhật lên database ---> Thiết kế CSDL từ đầu, chưa có CSDL
            /* dotnet ef migrations add <MigrationName> 
             VD ta tạo một migration có tên V0: dotnet ef migrations add V0 

            => trong dự án sẽ xuất hiện thư mục Migration, trong đó nó phát sinh ra các file .cs

            File WebContextModelSnapshot.cs chứa cấu trúc của CSDL tại thời điểm chúng ta tạo Migration V0
            File .Designer.cs chứa cấu trúc thiết kế của CSDL tại thời điểm chúng ta tạo Migration V0
            File _V0.cs có chứa 2 phương thức Up và Down:
            - Up: phương thức này được thực thi khi ta sử dụng EF (Entity Framework) để cập nhật cấu trúc ở thời điểm V0 lên database
            - Down: phương thức này được thực thi khi chũng ta muốn phục hồi hay muôn shuyr bỏ cập nhật của một phiên bản
            
             * Để biết được trong dự án có những Migration nào ta sử dụng lệnh:
                dotnet ef migrations list 
            => khi đó nó sẽ kiểm tra code của chúng ta đồng thời nó kết nối đến sql server và nó sẽ cho biết code của chúng ta có những migration nào
            
             * Để xóa một Migration cuối cùng ta tạo ra, ta sử dụng lệnh:
                dotnet ef migrations remove
            
             * Để cập nhật tất cả các Migration trong dự án (cập nhật tới phiên bản cuối cùng), ta sử dụng lệnh:
                dotnet ef database update
               Nếu chỉ update một Migration, ta chỉ cần chỉ tên Migration đó (hoặc muốn quay về version đó):
                dotnet ef database update <MigrationName>
             
             * Để xóa database ta thực hiện các bước sau:
                dotnet ef database drop -f
            
             * Để hiển thị tất cả các câu truy vấn sql mà nó thực hiện từ migration đầu đến migration cuối:
                dotnet ef migrations script
            
             * Để hiển thị tất cả các câu truy vấn sql mà nó cập nhật từ migration 1 sang migration 2:
                dotnet ef migrations script <Migration1_Name> <Migration2_Name>
            
             * Để lưu tất cả các truy vấn tạo migration ra file script sql:
                dotnet ef migrations script -o <FileName.sql>
            
             
             // Scafford: sinh ra Models từ database có sẵn
                dotnet ef dbcontext scaffold -o Models -f -d <Chuỗi kết nối>

                * Trong các tham số trên thì:
                    -o Models thư mục lưu các entity được sinh ra
                    -f cho phép ghi đè file
                    -d ưu tiên sử dụng kỹ thuật Data Annotation nếu có thể - nếu không thể thì dùng FLuent API
            
             Ví dụ: 
                Chuỗi kết nối: "Server=DESKTOP-3VODAHR\SQLEXPRESS;Database=shopdata;Trusted_Connection=True;"
                Hay: "Data Source=localhost,1433;Initial Catalog=shopdata;User ID=SA;Password=Password123"*/

        }
    }
}
