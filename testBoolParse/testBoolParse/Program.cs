namespace testBoolParse
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("True {0}", bool.Parse("True"));
            Console.WriteLine("False {0}", bool.Parse("False"));

            Console.WriteLine("true {0}", bool.Parse("true"));
            Console.WriteLine("false {0}", bool.Parse("false"));

            //Console.WriteLine("1 {0}", bool.Parse(int.Parse("1")));
            //Console.WriteLine("0 {0}", bool.Parse(int.Parse("0")));

            Console.Read();
        }
    }
}
