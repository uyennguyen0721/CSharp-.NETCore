using System;
using Microsoft.Extensions.DependencyInjection;

namespace Dependence_Injection
{
    /* Dependency injection (DI)* là một nguyên tắc nó được triển khai từ nguyên tắc Dependency, là triển khai cụ thể của nguyên 
     tắc Inversion of Control (IoC) / Dependency inversion */

    // Thiết kế truyền thống - tham chiếu trực tiếp đến Dependency

    class ClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB
    {
        // Phụ thuộc của ClassB là ClassC
        ClassC c_dependency;

        public ClassB(ClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        // Phụ thuộc của ClassA là ClassB
        ClassB b_dependency;

        public ClassA(ClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }

    // Thiết kế theo cách đảo ngược phụ thuộc Inverse Dependency

    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }

    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC() => Console.WriteLine("Action in ClassC1");
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB1");
            c_dependency.ActionC();
        }
    }


    class ClassA1
    {
        IClassB b_dependency;
        public ClassA1(IClassB classb)
        {
            b_dependency = classb;
            Console.WriteLine("ClassA1 is created");
        }
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA1");
            b_dependency.ActionB();
        }
    }

    // Code dễ dàng thay các phụ thuộc

    class ClassC2 : IClassC
    {
        public ClassC2() => Console.WriteLine("ClassC2 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in C2");
        }
    }

    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        public ClassB2(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB2 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in B2");
            c_dependency.ActionC();
        }
    }

    /* Giả sử có lớp Car có chức năng (phương thức) Beep() - để phát ra tiếng còi xe, mà để phát ra tiếng còi - nó lại dựa vào
lớp Horn chuyên tạo ra tiếng còi - lúc đó ta nói lớp Car có một phụ thuộc (dependency Horn) là lớp Horn, Horn là 
dependency của Car.

Muốn lớp Car hoạt động thì nó phải có đối tượng (dịch vụ) từ Horn. Vậy khi thiết kế, thường có hai cách:

- Trong lớp Car thiết kế code mà nó phụ thuộc cứng vào lớp Horn - tự khởi tạo Horn, cách thiết kế này không có khả năng áp dụng kỹ thuật DI
- Trong lớp Car, dependency Horn không do Car trực tiếp khởi tạo mà nó được đưa vào qua phương thức khởi tạo, qua setter, qua gán property. 
Các thiết kế này linh hoạt và có KHẢ NĂNG để áp dụng DI*/

    // Code mà không có khả năng áp dụng DI

    public class Horn
    {
        public void Beep() => Console.WriteLine("Beep - beep - beep ...");
    }

    public class Car
    {
        public void Beep()
        {
            // chức năng Beep xây dựng có định với Horn
            // tự tạo đối tượng horn (new) và dùng nó
            Horn horn = new Horn();
            horn.Beep();
        }
    }

    /* Nhưng code trên có một vấn đề là tính linh hoạt khi sử dụng. Chức năng Beep() của Car nó tự tạo ra đối tượng Horn 
và sử dụng nó - làm cho Car gắn cứng vào Horn với cấu trúc khởi tạo hiện thời.

Nếu lớp Horn sửa lại, ví dụ muốn khởi tạo Horn phải chỉ ra một tham số nào đó, ví dụ như độ lớn tiêng còi level*/

    public class Horn1
    {
        int level; // độ lớn của còi xe
        public Horn1(int level) => this.level = level; // thêm khởi tạo level
        public void Beep() => Console.WriteLine($"(level {level}) Beep - beep - beep ...");
    }

    /* Việc thay đổi Horn làm cho Car không còn dùng được nữa, nếu muốn Car hoạt động cần sửa lại code của Car*/


    // Code có KHẢ NĂNG áp dụng DI: Xây dựng lại ví dụ trên sao cho phụ thuộc của Car có thể đưa vào nó từ bên ngoài.

    public class Horn2
    {
        public void Beep() => Console.WriteLine("Beep - beep - beep ...");
    }

    public class Car2
    {
        // horn là một Dependecy của Car
        Horn horn;

        // dependency Horn được đưa vào Car qua hàm khởi tạo
        public Car2(Horn horn) => this.horn = horn;

        public void Beep()
        {
            // Sử dụng Dependecy đã được Inject
            horn.Beep();
        }
    }

    // Sử dụng Delegate / Factory đăng ký dịch vụ

    /* Sử dụng Delegate đăng ký
        services.AddSingleton<ServiceType>((IServiceProvider provider) => {
            // các chỉ thị
            // ...
        return (đối tượng kiểu ImplementationType);
        }); */

    class ClassB3 : IClassB
    {
        IClassC c_dependency;
        string message;
        public ClassB3(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB3 is created");
        }
        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.ActionC();
        }

        /* Sử dụng Factory đăng ký: Factory nhận tham số là IServiceProvider và trả về đối tượng địch vụ cần tạo */

        public static ClassB3 CreateB3Factory(IServiceProvider serviceprovider)
        {
            var service_c = serviceprovider.GetService<IClassC>();
            var sv = new ClassB3(service_c, "Thực hiện trong ClassB3");
            return sv;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ClassC objectC = new ClassC();
            ClassB objectB = new ClassB(objectC);
            ClassA objectA = new ClassA(objectB);

            objectA.ActionA();

            Console.WriteLine("-------------------------------");

            IClassC objectC1 = new ClassC1();
            IClassB objectB1 = new ClassB1(objectC1);
            ClassA1 objectA1 = new ClassA1(objectB1);

            objectA1.ActionA();

            Console.WriteLine("-------------------------------");

            IClassC objectC2 = new ClassC2();            // new ClassC();
            IClassB objectB2 = new ClassB2(objectC2);     // new ClassB();
            ClassA1 objectA2 = new ClassA1(objectB2);

            objectA2.ActionA();

            Console.WriteLine("-------------------------------");

            var car = new Car();
            car.Beep();

            Console.WriteLine("-------------------------------");

            /* Kết quả gọi car1.Beep(); có vẻ kết quả vẫn như trên, nhưng code mới này có một số lợi ích. 
        Ví dụ, nếu sửa cập nhật lại Horn bằng cách sửa phương thức khởi tạo của nó, thì lớp Car không phải sửa gì!*/

            Horn horn = new Horn();

            var car1 = new Car2(horn); // horn inject vào car
            car1.Beep(); // Beep - beep - beep ...

            /* Như vậy, viết code mà các dependency có thể đưa vào từ bên ngoài (chủ yếu qua phương thức khởi tạo), giúp cho các dịch vụ tương đối độc lập nhau. 
        Nó là cơ sở để có thể dùng các Framework hỗ trợ DI (tự động phân tích tạo dịch vụ, dependency)*/

            Console.WriteLine("-------------------------------");

            /* Thư viện Dependency Indection:
             - DI Container: cho phép đăng ký các dịch vụ (lớp) vào trong nó, sau đó hỗ trợ lấy ra các đối tượng (dịch vụ) - Get Service - khi lấy ra thì nó sẽ 
            khởi tạo đối tượng đó nếu đối tượng đó cần DI, nếu DI chưa có thì nó sẽ tự động khởi tạo ra các DI và tự động inject vào dịch vụ của chúng ta
             - Ví dụ:   + DI Container: ServiceCollection
                        + Đăng ký các dịch vụ (lớp)
                        + ServiceProvider -> Get Service */

            var services = new ServiceCollection();
            var serviceprovider = services.BuildServiceProvider();

            // Dịch vụ được đăng ký là Singleton

            // Đăng ký dịch vụ IClassC tương ứng với đối tượng ClassC
            services.AddSingleton<IClassC, ClassC1>();

            var provider = services.BuildServiceProvider();

            for (int i = 0; i < 5; i++)
            {
                var service = provider.GetService<IClassC>();
                Console.WriteLine(service.GetHashCode());
            }
            // ClassC is created
            // 32854180
            // 32854180
            // 32854180
            // 32854180
            // 32854180
            // Gọi 5 lần chỉ 1 dịch vụ (đối tượng) được tạo ra

            Console.WriteLine("-------------------------------");

            // Dịch vụ được đăng ký là Transient

            services.AddTransient<IClassC, ClassC1>();

            var provider1 = services.BuildServiceProvider();

            for (int i = 0; i < 5; i++)
            {
                var service = provider1.GetService<IClassC>();
                Console.WriteLine(service.GetHashCode());
            }
            // ClassC is created
            // 32854180
            // ClassC is created
            // 27252167
            // ClassC is created
            // 43942917
            // ClassC is created
            // 59941933
            // ClassC is created
            // 2606490
            // Gọi 5 lần có 5 dịch vụ được tạo ra

            Console.WriteLine("-------------------------------");

            // Dịch vụ được đăng ký là Scoped

            ServiceCollection services1 = new ServiceCollection();

            // Đăng ký dịch vụ IClassC tương ứng với đối tượng ClassC
            services1.AddScoped<IClassC, ClassC1>();

            var provider2 = services.BuildServiceProvider();

            // Lấy dịch vụ trong scope toàn cục
            for (int i = 0; i < 5; i++)
            {
                var service = provider2.GetService<IClassC>();
                Console.WriteLine(service.GetHashCode());
            }

            // Tạo ra scope mới
            using (var scope = provider.CreateScope()) // dùng using để cho biết biến scope chỉ được dùng trong khối lệnh này thôi
            {
                // Lấy dịch vụ trong scope
                for (int i = 0; i < 5; i++)
                {
                    var service = scope.ServiceProvider.GetService<IClassC>();
                    Console.WriteLine(service.GetHashCode());
                }
            }
            // ClassC is created
            // 32854180
            // 32854180
            // 32854180
            // 32854180
            // 32854180
            // ClassC is created
            // 27252167
            // 27252167
            // 27252167
            // 27252167
            // 27252167
            // Mỗi scope tạo ra một loại dịch vụ

            Console.WriteLine("-------------------------------");   

            // Kiểm tra tạo và inject các dịch vụ đăng ký trong ServiceCollection

            // ClassA
            // IClassB -> ClassB1,  ClassB2
            // IClassC -> ClassC1,  ClassC2

            ServiceCollection services2 = new ServiceCollection();

            services2.AddSingleton<ClassA1, ClassA1>();
            services2.AddSingleton<IClassC, ClassC1>();
            services2.AddSingleton<IClassB, ClassB1>();

            var provider3 = services2.BuildServiceProvider();

            ClassA1 a = provider3.GetService<ClassA1>();

            a.ActionA();

            // ClassC is created
            // ClassB is created
            // ClassA is created
            // Action in ClassA
            // Action in ClassB
            // Action in ClassC

            Console.WriteLine("-------------------------------");

            services.AddSingleton<IClassB, ClassB3>();

            services.AddSingleton<IClassB>((IServiceProvider serviceprovider) => {
                var service_c = serviceprovider.GetService<IClassC>();
                var sv = new ClassB3(service_c, "Thực hiện trong ClassB3");
                return sv;
            });

            Console.WriteLine("-------------------------------");

            //services.AddSingleton<IClassB>(CreateB3Factory);
        }
    }
}
