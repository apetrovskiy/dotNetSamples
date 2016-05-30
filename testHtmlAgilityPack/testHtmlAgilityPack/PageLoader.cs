namespace testHtmlAgilityPack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Epam.JDI.Commons;
    using HtmlAgilityPack;

    public class PageLoader
    {
        public HtmlNode LoadPage(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            return doc.DocumentNode;
        }

        public void DisplayTypesFromPage(HtmlNode docNode)
        {
            var convertor = new ElementToMemberConvertor();
            var typeDefinitions = docNode.Descendants().Select(node => convertor.Convert(node));
            typeDefinitions.ForEach(typeDef =>
            {
                if (!string.IsNullOrEmpty(typeDef))
                    Console.WriteLine(typeDef);
            });
        }

        void TestAttributes(HtmlNode docNode)
        {
            docNode.Descendants()
                .Where(node => node.Attributes.Any())
                .Where(node => node.Attributes.Any(attribute => attribute.Name == "class"))
                .ToList()
                .ForEach(node => Console.WriteLine(@"name = {0}, id = {1}, class = {2}", node.Name, node.Id, ConvertClassAttributeToLine(node.Attributes)));
            int i = 1;
        }

        string ConvertClassAttributeToLine(IEnumerable<HtmlAttribute> attributes)
        {
            var classAttribute = attributes.FirstOrDefault(attribute => attribute.Name == "class");
            return null == classAttribute ? string.Empty : classAttribute.Value;
        }
    }
}