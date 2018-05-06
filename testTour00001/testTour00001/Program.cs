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
}
