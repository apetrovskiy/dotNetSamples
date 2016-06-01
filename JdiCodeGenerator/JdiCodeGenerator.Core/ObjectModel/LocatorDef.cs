namespace JdiCodeGenerator.Core.ObjectModel
{
    using Abstract;

    public class LocatorDef : ILocatorDefinition
    {
        public bool IsBestChoice { get; set; }
        public bool IsUnique { get; set; }
        public FindTypes Attribute { get; set; }
        public SearchTypes SearchType { get; set; }
        public string SearchString { get; set; }
    }
}