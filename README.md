# CSharp-.NETCore
- Archive projects during your studies to see your progress through them
- Pretty simple projects for beginners to learn .NET Core

* Các lệnh bên dưới đều được thực hiện trong Terminal: 
     
        - Thêm packet Newtonsoft.Json (Không nhập version thì nó sẽ lấy version mới nhất): 
            dotnet add package Newtonsoft.Json --version 13.0.1
            
        - Xóa packet Newtonsoft.Json: 
            dotnet remove packet Newtonsoft.Json 
     
        - Để kiểm tra và phục hồi các packet (Thực hiện khi các thư viện trong dự án bị lỗi), ta thực hiện lệnh: 
            dotnet restore
        
        - Để chạy project, ta thực hiện lệnh: dotnet run

* Delegate là một kiểu được dùng để khai báo tạo ra cac biến và các biến này tham chiếu được đến các phương thức 
hay nói cách khác là nó được gán bằng các phương thức. Sau đó ta có thể dùng biến kiểu Delegate để thi hành những 
phương thức đang được lưu ở trong biến đó:
                    delegate (Type) <biến> = <phương thức> 

* Null là từ khóa cho biết nó không tham chiếu đến đối tượng cả, từ khóa null được sử dụng cho những biến kiểu tham chiếu
Nullable dùng để khai báo biến kiểu tham trị có khả năng nhận giá trị null: VD: int? a; a = null;

* Kiểm tra biến đó có giá trị hay không (khác null hay không) ta dùng phương thức HasValue, phương thức này trả về kiểu bool
Để gọi phương thức ta thực hiện <tên biến>.HasValue

* Sử dụng Mailkit để gửi mail trong ASP.NET Core: 
	- Cài packet Mailkit: dotnet add package MailKit
	- Cài packet MimeKit: dotnet add package MimeKit
