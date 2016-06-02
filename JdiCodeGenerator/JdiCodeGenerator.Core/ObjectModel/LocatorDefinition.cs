namespace JdiCodeGenerator.Core.ObjectModel
{
    using Abstract;

    public class LocatorDefinition // : ILocatorDefinition
    {
        public bool IsBestChoice { get; set; }
        public bool IsUnique { get; set; }
        public FindTypes Attribute { get; set; }
        public SearchTypePreferences SearchTypePreference { get; set; }
        public string SearchString { get; set; }
    }
}