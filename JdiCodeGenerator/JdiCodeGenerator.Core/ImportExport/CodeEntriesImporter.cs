namespace JdiCodeGenerator.Core.ImportExport
{
    using System.Collections.Generic;
    using System.IO;
    using Helpers;
    using ObjectModel.Abstract;

    public class CodeEntriesImporter
    {
        public IEnumerable<ICodeEntry> LoadFromFile(string path)
        {
            var serializedCodeEntries = new List<string>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                    serializedCodeEntries.Add(reader.ReadLine());
            }
            return serializedCodeEntries.ImportCodeEntriesFromJson();
        }
    }
}