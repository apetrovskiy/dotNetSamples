using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testAnonymousTypes001
{
    class Program
    {
        static void Main(string[] args)
        {
            var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 } };

            Console.WriteLine(anonArray.GetType().Name);

            var mapping = new Dictionary<string, Type>
            {
                //new KeyValuePair<string, Type> ( "aaa", typeof(FileStyleUriParser) ),
                //new KeyValuePair<string, Type> { "aaa", typeof(FileStyleUriParser) }
                { "aaa", typeof(FileStyleUriParser) },
                { "bbb", typeof(SystemException) }
            };

            TestData(mapping);

            Console.ReadKey();
        }

        static void TestData(Dictionary<string, Type> filesTypesMapping)
        {
            filesTypesMapping.Keys.ToList().ForEach(key =>
            {
                Console.WriteLine(key);
                Console.WriteLine(filesTypesMapping[key].Name);
            });
        }
    }
}
