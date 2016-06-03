namespace JdiCodeGenerator.Tests.Example
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    // http://stackoverflow.com/questions/22093843/pass-complex-parameters-to-theory
    public class StringTests2
    {
        [Theory, MemberData("SplitCountData")]
        [Trait("Category", "Example")]
        public void SplitCount(string input, int expectedCount)
        {
            var actualCount = input.Split(' ').Count();
            Assert.Equal(expectedCount, actualCount);
        }

        public static IEnumerable<object[]> SplitCountData
        {
            get
            {
                // Or this could read from a file. :)
                return new[]
                {
                new object[] { "xUnit", 1 },
                new object[] { "is fun", 2 },
                new object[] { "to test with", 3 }
            };
            }
        }
    }

    public class IndexOfData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
    {
        new object[] { "hello world", 'w', 6 },
        new object[] { "goodnight moon", 'w', -1 }
    };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}