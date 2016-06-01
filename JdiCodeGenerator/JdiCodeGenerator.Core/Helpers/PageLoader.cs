namespace JdiCodeGenerator.Core.Helpers
{
    using System;
    using System.Linq;
    using Epam.JDI.Commons;
    using HtmlAgilityPack;
    using ObjectModel.Abstract;

    public class PageLoader
    {
        HtmlNode _docNode;

        void LoadPage(string url)
        {
            var web = new HtmlWeb();
            _docNode = web.Load(url).DocumentNode;
        }

        public void DisplayTypesFromPage(string url)
        {
            LoadPage(url);

            var convertor = new ElementToMemberConvertor();
            var objtypeDefinitions = _docNode.Descendants().Select(node => convertor.ConvertToCodeEntry(node));

            var listNotToDisplay = new[] {"html", "head", "body", "#comment", "#text", "div", "meta", "p", "h1", "h2", "h3", "h4", "h5", "h6", "small", "font", "script", "i", "br", "hr", "style", "title", "li", "ul", "img", "span", "noscript", "label"};

            objtypeDefinitions.ForEach(def =>
            {
                //if (ElementTypes.Unknown != def.HtmlMemberType)
                //{
                //    Console.WriteLine((string) def.GenerateCodeEntry());
                //}
                if (!listNotToDisplay.Contains(def.Type))
                    Console.WriteLine(def.GenerateCodeEntry());
            });
        }
    }
}