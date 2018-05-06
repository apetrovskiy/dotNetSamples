namespace testTour0002
{
    using System;

    public class App
    {
        static String s;
        static DateTime d;

        public static void Main()
        {
            Console.WriteLine(s == null ? "null" : s);
            Console.WriteLine(d == null ? "null" : d.ToString());
            Console.ReadKey();

            // Console.WriteLine(1**32);

        }
    }
}
