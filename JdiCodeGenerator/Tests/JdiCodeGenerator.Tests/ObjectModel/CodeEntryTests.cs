namespace JdiCodeGenerator.Tests.ObjectModel
{
    using Core.ObjectModel.Abstract;
    using Xunit;

    public class CodeEntryTests
    {
        ICodeEntry _entry;

        public CodeEntryTests()
        {
            
        }

        [Fact]
        public void GeneratesEntryTitle()
        {
            GivenCodeEntry();
            WhenGeneratingTitle();
            ThenTitleIs();
        }

        void GivenCodeEntry()
        {
            
        }

        void WhenGeneratingTitle()
        {
            
        }

        void ThenTitleIs()
        {
            
        }
    }
}