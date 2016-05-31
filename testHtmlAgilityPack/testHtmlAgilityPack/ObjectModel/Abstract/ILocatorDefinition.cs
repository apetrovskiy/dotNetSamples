namespace testHtmlAgilityPack.ObjectModel.Abstract
{
    public interface ILocatorDefinition
    {
        bool IsActive { get; set; }
        FindTypes Attribute { get; set; }
        SearchTypes SearchType { get; set; }
        string SearchString { get; set; }
    }
}