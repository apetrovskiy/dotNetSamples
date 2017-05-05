namespace testLinq1001
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var result = new Test001().Test();

            var list = result.ToList();

            int i = 1;
        }
    }
}
