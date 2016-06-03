namespace JdiCodeGenerator.Core.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using Epam.JDI.Commons;
    using ObjectModel.Abstract;

    public static class ExtensionMethodsForCodeEntries
    {
        static readonly List<char> WrongCharacters = new List<char> {
            ' ',
            '-',
            '.',
            '/',
            '#',
            ',',
            '\\',
            '*',
            ':',
            '@',
            '(',
            ')',
            '[',
            ']',
            '?',
            '=',
            '&',
            '+'
            };
        internal static string ToPascalCase(this string wronglyFormattedString)
        {
            if (string.IsNullOrEmpty(wronglyFormattedString))
                return NoName;

            const int lowerA = 97;
            const int lowerZ = 122;
            const int differenceBetweenUpperAndLower = 32;

            WrongCharacters.ForEach(character =>
            {
                if (0 == wronglyFormattedString.Length) return;
                var firstCharacter = (int) wronglyFormattedString[0];
                if (firstCharacter >= lowerA && firstCharacter <= lowerZ)
                    wronglyFormattedString = ((char) firstCharacter).ToString().ToUpper() +
                                             wronglyFormattedString.Substring(1);

                var charPosition = wronglyFormattedString.IndexOf(character);

                if (charPosition == wronglyFormattedString.Length - 1)
                    wronglyFormattedString = wronglyFormattedString.Replace(character.ToString(), string.Empty);

                while (charPosition >= 0)
                {
                    if (charPosition < wronglyFormattedString.Length - 1)
                    {
                        var charToCapitalize = (int) wronglyFormattedString.ElementAt(charPosition + 1);
                        if (charToCapitalize >= lowerA && charToCapitalize <= lowerZ)
                            charToCapitalize -= differenceBetweenUpperAndLower;
                        wronglyFormattedString = wronglyFormattedString.Substring(0, charPosition) +
                                                 (char) charToCapitalize +
                                                 wronglyFormattedString.Substring(charPosition + 2);
                    }
                    charPosition = wronglyFormattedString.IndexOf(character);
                    if (charPosition == wronglyFormattedString.Length - 1)
                    {
                        wronglyFormattedString = wronglyFormattedString.Replace(character.ToString(), string.Empty);
                    }

                    charPosition = wronglyFormattedString.IndexOf(character);
                }
            });

            if (string.IsNullOrEmpty(wronglyFormattedString))
                return NoName;

            return wronglyFormattedString;
        }

        public static IEnumerable<ICodeEntry> SetBestChoice(this IEnumerable<ICodeEntry> codeEntries)
        {
            var entries = codeEntries as ICodeEntry[] ?? codeEntries.ToArray();
            entries.ForEach(codeEntry => codeEntry.Locators.ForEach(locator => locator.IsBestChoice = false));
            entries.ForEach(codeEntry => codeEntry.Locators.OrderBy(locator => (int)locator.SearchTypePreference).First().IsBestChoice = true);
            return entries;
        }

        public static IEnumerable<ICodeEntry> SetDistinguishNamesForMembers(this IEnumerable<ICodeEntry> codeEntries)
        {
            var distinguishNamesForMembers = codeEntries as ICodeEntry[] ?? codeEntries.ToArray();
            distinguishNamesForMembers.ForEach(codeEntry => codeEntry.MemberName = codeEntry.GenerateNameBasedOnNamingPreferences());
            distinguishNamesForMembers
                .GroupBy(codeEntryName => codeEntryName.MemberName)
                .Select(grouping =>
                {
                    int i = 0;
                    grouping.ToList().Skip(1).ForEach(item => { item.MemberName += ++i; });
                    return grouping;
                }).SelectMany(grouping => grouping.Select(item => item)).ToList();
            return distinguishNamesForMembers;
        }

        /*
        title,
        name,
        id,
        tagName,
        linkText,
        className,
        */

        internal const string NoName = "NoName";
        internal const string NoTypeDetected = "noTypeDetected";
        internal static string GenerateNameBasedOnNamingPreferences(this ICodeEntry codeEntry)
        {
            if (string.IsNullOrEmpty(codeEntry.MemberType))
                codeEntry.MemberType = NoTypeDetected;
            if (!codeEntry.Locators.Any())
                return codeEntry.MemberType + NoName;
            if (codeEntry.Locators.Any(locator => locator.SearchTypePreference == SearchTypePreferences.name))
                return codeEntry.MemberType + codeEntry.Locators.First(locator => locator.SearchTypePreference == SearchTypePreferences.name).SearchString.ToPascalCase();

            if (codeEntry.Locators.Any(locator => locator.SearchTypePreference == SearchTypePreferences.id))
                return codeEntry.MemberType + codeEntry.Locators.First(locator => locator.SearchTypePreference == SearchTypePreferences.id).SearchString.ToPascalCase();

            if (codeEntry.Locators.Any(locator => locator.SearchTypePreference == SearchTypePreferences.tagName))
                return codeEntry.MemberType + codeEntry.Locators.First(locator => locator.SearchTypePreference == SearchTypePreferences.tagName).SearchString.ToPascalCase();

            if (codeEntry.Locators.Any(locator => locator.SearchTypePreference == SearchTypePreferences.linkText))
                return codeEntry.MemberType + codeEntry.Locators.First(locator => locator.SearchTypePreference == SearchTypePreferences.linkText).SearchString.ToPascalCase();

            if (codeEntry.Locators.Any(locator => locator.SearchTypePreference == SearchTypePreferences.className))
                return codeEntry.MemberType + codeEntry.Locators.First(locator => locator.SearchTypePreference == SearchTypePreferences.className).SearchString.ToPascalCase();

            return codeEntry.MemberType + NoName;
        }
    }
}