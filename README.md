# CSharp-.NETCore
- Archive projects during your studies to see your progress through them
- Pretty simple projects for beginners to learn .NET Core

* Các lệnh bên dưới đều được thực hiện trong Terminal: 
     
        - Thêm packet Newtonsoft.Json (Không nhập version thì nó sex lấy version mới nhất): 
            dotnet add package Newtonsoft.Json --version 13.0.1
            
        - Xóa packet Newtonsoft.Json: 
            dotnet remove packet Newtonsoft.Json 
     
        - Để kiểm tra và phục hồi các packet (Thực hiện khi các thư viện trong dự án bị lỗi), ta thực hiện lệnh: 
            dotnet restore
        
        - Để chạy project, ta thực hiện lệnh: dotnet run

* Delegate là một kiểu được dùng để khia báo tạo ra cac biến và các biến này tham chiếu được đến các phương thức 
hay nói cách khác là nó được gán bằng các phương thức. Sau đó ta có thể dùng biến kiểu Delegate để thi hành những 
phương thức đang được lưu ở trong biến đó:
                    delegate (Type) <biến> = <phương thức>*/
