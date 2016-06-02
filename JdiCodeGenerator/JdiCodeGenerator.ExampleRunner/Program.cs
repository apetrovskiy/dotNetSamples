namespace JdiCodeGenerator.ExampleRunner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Helpers;
    using Core.ImportExport;
    using Core.ObjectModel.Abstract;

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>
            {
                "http://localhost:1234/bootstrap/users",
                "http://localhost:1234/bootstrap/users/user",
                
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

                // "http://www.folchstudio.com/",
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
            var listNotToDisplay = new[] { "html", "head", "body", "#comment", "#text", "div", "meta", "p", "h1", "h2", "h3", "h4", "h5", "h6", "small", "font", "script", "i", "br", "hr", "style", "title", "li", "ul", "img", "span", "noscript" };
            // const string FolderForExportFiles = ".";
            const string FolderForExportFiles = @"D:\333";
            var loader = new PageLoader();
            var exporter = new CodeEntriesExporter();
            var importer = new CodeEntriesImporter();
            int fileNumber = 0;
            list.ForEach(url =>
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("================{0}================", url);
                Console.WriteLine("===============================================================================");
                var codeEntries = loader.GetCodeEntries(url, listNotToDisplay);
                var entries = codeEntries as IList<ICodeEntry> ?? codeEntries.ToList();
                entries.ToList().ForEach(elementDefinition => Console.WriteLine(elementDefinition.GenerateCodeForEntry(SupportedLanguages.Java)));

                exporter.WriteToFile(entries, FolderForExportFiles + @"\" + ++fileNumber);
                var importedEntries = importer.LoadFromFile(FolderForExportFiles + @"\" + fileNumber);
                exporter.WriteToFile(importedEntries, FolderForExportFiles + @"\" + (100 + fileNumber));

            });

            Console.WriteLine("Completed!");
            Console.ReadKey();
        }
    }
}
