namespace testHtmlAgilityPack
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            // const string pageUrl = "http://localhost:1234/bootstrap";
            // const string pageUrl = "http://newsweek.com";
            //const string pageUrl = "http://presentation.creative-tim.com/";
            
            //var docNode = loader.LoadPage(pageUrl);
            //loader.DisplayTypesFromPage(docNode);

            //docNode = loader.LoadPage("http://www.crit-research.it/");
            //loader.DisplayTypesFromPage(docNode);

            //docNode = loader.LoadPage("http://www.blackbox.cool/");
            //loader.DisplayTypesFromPage(docNode);

            //docNode = loader.LoadPage("http://indicius.com/");
            //loader.DisplayTypesFromPage(docNode);

            //docNode = loader.LoadPage("http://www.spotify-thedrop.com/#/");
            //loader.DisplayTypesFromPage(docNode);

            //docNode = loader.LoadPage("https://trakt.tv/");
            //loader.DisplayTypesFromPage(docNode);

            //docNode = loader.LoadPage("http://www.jdcdesignstudio.com/");
            //loader.DisplayTypesFromPage(docNode);

            //docNode = loader.LoadPage("http://www.europarc-deutschland.de/marktplatz-natur/");
            //loader.DisplayTypesFromPage(docNode);

            //docNode = loader.LoadPage("https://www.playosmo.com/en/");
            //loader.DisplayTypesFromPage(docNode);

            //docNode = loader.LoadPage("http://www.anakin.co/en");
            //loader.DisplayTypesFromPage(docNode);

            //var loader = new PageLoader();
            var list = new List<string>
            {
                "http://presentation.creative-tim.com/",
                "http://www.crit-research.it/",
                "http://www.blackbox.cool/",
                "http://indicius.com/",
                "http://www.spotify-thedrop.com/#/",
                "https://trakt.tv/",
                "http://www.jdcdesignstudio.com/",
                "http://www.europarc-deutschland.de/marktplatz-natur/",
                "https://www.playosmo.com/en/",
                "http://www.anakin.co/en",

                "http://shadowwarrior.com/",
                "http://calhoun.ca/",
                "https://onreplaytv.com/",
                "http://www.empor.cc/",
                "https://www.mongodb.com/cloud",
                "http://threedaysgrace.com/",
                "https://www.nasa.gov/",
                "https://overv.io/",
                "http://liveramp.com/",
                "https://www.aceandtate.com/",
                "http://www.washington.edu/",
                "http://www.fifa.com/",
                "http://www.placemeter.com/",
                "http://www.littlehj.com/",
                "http://thefounderspledge.org/",

                "http://www.folchstudio.com/",
                "https://maple.com/",
                "http://www.racefurniture.com.au/",
                "http://www1.nyc.gov/html/onenyc/",
                "http://goranfactory.com/",

                "http://ronagam.com/",
                "http://www.clusta.com/",
                "http://thespaces.com/",
                "http://www.creanet.es/",
                "https://www.youworkforthem.com/",
                "http://colofts.ca/",
                "http://visualsoldiers.com/",
                "http://scottieandrussell.co.uk/",
                "http://themewich.com/struck/",
                "http://olafurarnalds.com/",

                "http://www.vibrantcomposites.com/",
                "https://modsquad.com/",
                "https://www.fromparcel.com/",
                "http://www.winshipwealth.com/",
                "http://magnet.co/",
                "https://webtask.io/",
                "http://spikenode.com/",
                "http://guizion.com/",
                "https://www.glaz-displayschutz.de/"

            };
            var loader = new PageLoader();
            list.ForEach(url =>
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("================{0}================", url);
                Console.WriteLine("===============================================================================");
                loader.DisplayTypesFromPage(loader.LoadPage(url));
            });

            Console.WriteLine("Completed!");
            Console.ReadKey();
        }
    }
}
