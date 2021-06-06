using System;

namespace Static
{
    //Lớp VD về phương thức tĩnh static
    //Tính số lần
    class CountNumber
    {
        public static int number = 0; //biến trường dữ liệu
        public static void Info()
        {
            Console.WriteLine("Số lần truy cập " + number);
        }
        public void Count()
        {
            CountNumber.number++;
        }
    }

    class Student
    {
        public readonly string name; // trường dữ liệu này chỉ đọc

        // Trường dữ liệu chỉ đọc này ko được phép gán giá trị cho nó. Tuy nhiên ở trong phương thức khởi tạo nó lại được phép gán
        public Student(string name)
        {
            this.name = name;
        }
    }

    //Quá tải toán tử tro ng C# (operator overloading)

    class Vector
    {
        double x, y;

        public Vector(double _x, double _y)
        {
            x = _x;
            y = _y;
        }


        //In thông tin tọa độ của vector
        public void Info()
        {
            Console.WriteLine($"Tọa độ của vector là: ({x}, {y})");
        }

        // tạo ra toán tử cộng có kí hiệu là '+' giữa hai vector v1 + v2 = v3
        public static Vector operator+(Vector v1, Vector v2) // nếu phép trừ thì operator-
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        // tạo ra toán tử cộng có kí hiệu là '+' giữa vevto và một số hạng bất kỳ
        public static Vector operator +(Vector v1, double value) // nếu phép trừ thì operator-
        {
            return new Vector(v1.x + value, v1.y + value);
        }

        // Tạo Indexer trong C# [chỉ số]
        public double this[int i]
        {
            set
            {
                switch (i)
                {
                    case 0: //x
                        x = value;
                        break;
                    case 1: //y
                        y = value;
                        break;
                    default: // còn lại
                        throw new Exception("Chỉ số bị sai");
                }

            }
            get
            {
                switch (i)
                {
                    case 0: //x
                        return x;
                    case 1: //y
                        return y;
                    default: // còn lại
                        throw new Exception("Chỉ số bị sai");
                }
            }
        }

        public double this[string s]
        {
            set
            {
                switch (s)
                {
                    case "toadox": //x
                        x = value;
                        break;
                    case "toadoy": //y
                        y = value;
                        break;
                    default: // còn lại
                        throw new Exception("Chỉ số bị sai");
                }

            }
            get
            {
                switch (s)
                {
                    case "toadox": //x
                        return x;
                    case "toadoy": //y
                        return y;
                    default: // còn lại
                        throw new Exception("Chỉ số bị sai");
                }
            }
        }
    }

    

// Indexer là cách chúng ta truy cập vào các trường dữ liệu của lớp, nó tương tự như biến mảng




class Program
    {
        static void Main(string[] args)
        {
            //Static
            CountNumber c1 = new CountNumber();
            CountNumber c2 = new CountNumber();
            c1.Count();
            c2.Count();
            CountNumber.Info();

            Student student = new Student("Nguyễn Thị Thu Uyên");
            Console.WriteLine(student.name);

            //Quá tải toán tử tro ng C# (operator overloading)
            Vector v1 = new Vector(2, 3);
            Vector v2 = new Vector(1, 1);
            var v3 = v1 + v2;
            v3.Info();

            var v4 = v1 + 10;
            v4.Info();

            // Tạo Indexer trong C#
            Vector v5 = new Vector(2, 3);
            v5[0] = 5;
            v5[1] = 6;
            v5.Info();

            Vector v6 = new Vector(3, 5);
            v6["toadox"] = 4;
            v6["toadoy"] = 7;
            v6.Info();

        }
    }
}
