using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTour00001
{
    class Program
    {
        static void Main(string[] args)
        {
            testExceptionSyntax();
            testStringFormats();
            MyFun2<int>.F();
            MyFan3.Run();
            Employee.Run();

            Console.ReadKey();
        }

        static void testExceptionSyntax()
        {
            try
            {
                // Foo.DoSomethingThatMightFail();
            }
            catch (Exception ex) when (ex.Message.Equals("500"))
            {
                Console.WriteLine("Bad Request");
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                Console.WriteLine("Unauthorized");
            }
            catch (Exception ex) when (ex.Message.Equals("402"))
            {
                Console.WriteLine("Payment Required");
            }
            catch (Exception ex) when (ex.Message.Equals("403"))
            {
                Console.WriteLine("Forbidden");
            }
            catch (Exception ex) when (ex.Message.Equals("404"))
            {
                Console.WriteLine("Not Found");
            }
        }

        static void testStringFormats()
        {
            Person p = new Person { Name = "John", DateOfBirth = new DateTime(1975, 6, 21) };
            string text = string.Format("{0} was born on {1:D}", p.Name, p.DateOfBirth);

            string text1 = $"{p.Name} was born on {p.DateOfBirth:D}";
            // string text2 = "{Name} was born on {DateOfBirth:D}".Format(p);
            // string text3 = p.Format("{Name} was born on {DateOfBirth:D}");
            // string text4 = StringTemplate.Format("{Name} was born on {DateOfBirth:D}", p);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class Fun1
    {
        protected int x;

        static void Funny(Fun1 a, MyFun1 b)
        {
            a.x = 1;
            b.x = 1;
        }
    }

    public class MyFun1 : Fun1
    {
        static void Funny(Fun1 a, MyFun1 b)
        {
            // a.x = 1;
            b.x = 1;
        }
    }

    class Fun2<T>
    {
        protected T x;
    }

    class MyFun2<T> : Fun2<T>
    {
        public static void F()
        {
            MyFun2<T> dt = new MyFun2<T>();
            MyFun2<int> di = new MyFun2<int>();
            MyFun2<string> ds = new MyFun2<string>();
            dt.x = default(T);
            di.x = 76;
            ds.x = "fun";
        }
    }

    class MyFan3
    {
        static void Fun()
        {
            Console.WriteLine("Fun()");
        }

        static void Fun(object x)
        {
            Console.WriteLine("Fun(object)");
        }

        static void Fun(int x)
        {
            Console.WriteLine("Fun(int)");
        }

        static void Fun(double x)
        {
            Console.WriteLine("Fun(double)");
        }

        public static void Run()
        {
            Fun("1.0");
        }
    }

    class Employee
    {
        private static int nextEmpID;
        private int empID;

        public Employee()
        {
            empID = nextEmpID++;
        }

        public static int GetNextEmpID()
        {
            return nextEmpID;
        }

        public static void SetNextEmpID(int value)
        {
            nextEmpID = value;
        }

        public static void Run()
        {
            Employee.SetNextEmpID(76);
            Employee e1 = new Employee();
            Employee e2 = new Employee();
            Console.WriteLine(Employee.GetNextEmpID());
        }
    }
}
