

namespace testIntersect
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            var Default = new List<MyClass>
            {
                new MyClass {MyString1 = "A", MyString2 = "A", MyString3 = "-"},
                new MyClass {MyString1 = "B", MyString2 = "B", MyString3 = "-"},
                new MyClass {MyString1 = "X", MyString2 = "X", MyString3 = "-"},
                new MyClass {MyString1 = "Y", MyString2 = "Y", MyString3 = "-"},
                new MyClass {MyString1 = "Z", MyString2 = "Z", MyString3 = "-"},
            };
            var Good = new List<MyClass>
            {
                new MyClass {MyString1 = "A", MyString2 = "A", MyString3 = "+"},
                new MyClass {MyString1 = "B", MyString2 = "B", MyString3 = "+"},
                new MyClass {MyString1 = "C", MyString2 = "C", MyString3 = "+"},
                new MyClass {MyString1 = "D", MyString2 = "D", MyString3 = "+"},
                new MyClass {MyString1 = "E", MyString2 = "E", MyString3 = "+"},
            };
            var wantedResult = Good.Intersect(Default, new MyEqualityComparer())
                .Union(Default, new MyEqualityComparer());

            var intersection = Good.Intersect(Default, new MyEqualityComparer());

            int i = 1;
        }
    }
}
