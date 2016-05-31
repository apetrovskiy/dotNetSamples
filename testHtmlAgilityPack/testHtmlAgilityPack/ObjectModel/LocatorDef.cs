namespace testHtmlAgilityPack.ObjectModel
{
    using Abstract;
    public class LocatorDef : ILocatorDefinition
    {
        public bool IsActive { get; set; }
        public FindTypes Attribute { get; set; }
        public SearchTypes SearchType { get; set; }
        public string SearchString { get; set; }
    }
}