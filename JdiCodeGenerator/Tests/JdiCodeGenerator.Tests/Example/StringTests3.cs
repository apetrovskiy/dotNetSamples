namespace JdiCodeGenerator.Tests.Example
{
    using Xunit;

    public class StringTests3
    {
        [Theory, ClassData(typeof(IndexOfData))]
        [Trait("Category", "Example")]
        public void IndexOf(string input, char letter, int expected)
        {
            var actual = input.IndexOf(letter);
            Assert.Equal(expected, actual);
        }
    }
}