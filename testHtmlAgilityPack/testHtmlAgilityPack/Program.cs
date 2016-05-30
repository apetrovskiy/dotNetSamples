namespace testHtmlAgilityPack
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // const string pageUrl = "http://localhost:1234/bootstrap";
            // const string pageUrl = "http://newsweek.com";
            const string pageUrl = "http://presentation.creative-tim.com/";
            var loader = new PageLoader();
            var docNode = loader.LoadPage(pageUrl);
            loader.DisplayTypesFromPage(docNode);

            docNode = loader.LoadPage("http://www.crit-research.it/");
            loader.DisplayTypesFromPage(docNode);

            docNode = loader.LoadPage("http://www.blackbox.cool/");
            loader.DisplayTypesFromPage(docNode);

            docNode = loader.LoadPage("http://indicius.com/");
            loader.DisplayTypesFromPage(docNode);

            docNode = loader.LoadPage("http://www.spotify-thedrop.com/#/");
            loader.DisplayTypesFromPage(docNode);

            docNode = loader.LoadPage("https://trakt.tv/");
            loader.DisplayTypesFromPage(docNode);

            docNode = loader.LoadPage("http://www.jdcdesignstudio.com/");
            loader.DisplayTypesFromPage(docNode);

            docNode = loader.LoadPage("http://www.europarc-deutschland.de/marktplatz-natur/");
            loader.DisplayTypesFromPage(docNode);

            docNode = loader.LoadPage("https://www.playosmo.com/en/");
            loader.DisplayTypesFromPage(docNode);

            docNode = loader.LoadPage("http://www.anakin.co/en");
            loader.DisplayTypesFromPage(docNode);

            Console.ReadKey();
        }
    }
}
