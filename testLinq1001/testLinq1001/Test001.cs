namespace testLinq1001
{
    using System.Collections.Generic;
    using System.Linq;

    public class Test001
    {
        public IEnumerable<TestData> Test()
        {
            // var seq001 = new[] { new TestData { Id = 1, SomeBool = true, SomeString = "a" }, new TestData { Id = 1, SomeBool = true, SomeString = "a" }, new TestData { Id = 1, SomeBool = true, SomeString = "a" }, new TestData { Id = 1, SomeBool = true, SomeString = "a" } };
            // var seq002 = new[] { new TestData { Id = 1, SomeBool = true, SomeString = "a" }, new TestData { Id = 1, SomeBool = true, SomeString = "a" }, new TestData { Id = 1, SomeBool = true, SomeString = "a" } };
            var item01 = new TestData { Id = 1, SomeBool = true, SomeString = "a" };
            var item02 = new TestData { Id = 2, SomeBool = false, SomeString = "b" };
            var item03 = new TestData { Id = 3, SomeBool = true, SomeString = "c" };
            var item04 = new TestData { Id = 4, SomeBool = true, SomeString = "d" };
            var seq001 = new[] { item01, item02, item03, item01, item04 };
            var seq002 = new[] { item01, item03, item02 };

            var res001 = seq001.Except(seq002);
            var res002 = seq001.Except(seq002, new TestData.TestDataEqualityComparer()).ToArray();
            // var res003 = seq001.Intersect(seq002);
            var res003 = seq002.Except(seq001);
            var res004 = seq002.Except(seq001, new TestData.TestDataEqualityComparer()).ToArray();
            // res002.Dump();
            return res002;
        }

        public class TestData
        {
            public sealed class TestDataEqualityComparer : IEqualityComparer<TestData>
            {
                public bool Equals(TestData x, TestData y)
                {
                    if (ReferenceEquals(x, y)) return true;
                    if (ReferenceEquals(x, null)) return false;
                    if (ReferenceEquals(y, null)) return false;
                    if (x.GetType() != y.GetType()) return false;
                    return x.Id == y.Id && x.SomeBool == y.SomeBool && string.Equals(x.SomeString, y.SomeString);
                }

                public int GetHashCode(TestData obj)
                {
                    unchecked
                    {
                        var hashCode = obj.Id;
                        hashCode = (hashCode * 397) ^ obj.SomeBool.GetHashCode();
                        hashCode = (hashCode * 397) ^ (obj.SomeString != null ? obj.SomeString.GetHashCode() : 0);
                        return hashCode;
                    }
                }
            }

            public static IEqualityComparer<TestData> IdSomeBoolSomeStringComparer { get; } = new TestDataEqualityComparer();

            public int Id { get; set; }
            public bool? SomeBool { get; set; }
            public string SomeString { get; set; }
        }
    }
}