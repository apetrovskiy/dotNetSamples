namespace JdiCodeGenerator.Core.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using ObjectModel;
    using ObjectModel.Abstract;

    public static class ExtensionMethodsForImportExport
    {
        public static IEnumerable<string> ExportCodeEntriesToJson(this IEnumerable<ICodeEntry> codeEntries)
        {
            var entries = codeEntries as ICodeEntry[] ?? codeEntries.ToArray();
            if (null == codeEntries || !entries.Any())
                return new List<string>();

            return entries.ToList().Select(JsonConvert.SerializeObject);
        }

        public static IEnumerable<ICodeEntry> ImportCodeEntriesFromJson(this IEnumerable<string> serializedCodeEntries)
        {
            var entries = serializedCodeEntries as string[] ?? serializedCodeEntries.ToArray();
            if(null == serializedCodeEntries || !entries.Any())
                return new List<ICodeEntry>();

            //var settings = new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Include,
            //    MissingMemberHandling = MissingMemberHandling.Ignore
            //};
            return entries.ToList().Select(JsonConvert.DeserializeObject<CodeEntry>);
        }
    }
}