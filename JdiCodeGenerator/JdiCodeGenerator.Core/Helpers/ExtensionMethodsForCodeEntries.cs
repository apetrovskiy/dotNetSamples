namespace JdiCodeGenerator.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Epam.JDI.Commons;
    using ObjectModel.Abstract;

    public static class ExtensionMethodsForCodeEntries
    {
        [Obsolete("This was applicable only to the initial version")]
        public static string GenerateCodeString(this Type type, string classString)
        {
            var memberName = type.Name + PrepareClassStringToBeMemberName(classString);
            return string.Format(
                @"
@FindBy(css = '{0}')
public {1} {2};
", classString, type.Name, memberName);
        }

        [Obsolete("This was applicable only to the initial version")]
        static string PrepareClassStringToBeMemberName(string classString)
        {
            if (string.IsNullOrEmpty(classString))
                return new Random().Next().ToString();
            classString = classString.Replace(" ", string.Empty);
            classString = classString.Replace(".", string.Empty);
            classString = classString.Replace("-", string.Empty);
            return classString;
        }

        [Obsolete("This was applicable only to the initial version")]
        static string GetExactClass(this string classString)
        {
            if (classString.Contains("btn"))
                return "btn";
            if (classString.Contains("radio"))
                return "radio";
            if (classString.Contains("checkbox"))
                return "checkbox";
            return string.Empty;
        }

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
            '@'
            };
        internal static string ToPascalCase(this string wronglyFormattedString)
        {
            if (string.IsNullOrEmpty(wronglyFormattedString))
                return wronglyFormattedString;

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

            return wronglyFormattedString;
        }

        public static IEnumerable<ICodeEntry> SetBestChoice(this IEnumerable<ICodeEntry> codeEntries)
        {
            var entries = codeEntries as ICodeEntry[] ?? codeEntries.ToArray();
            entries.ForEach(codeEntry => codeEntry.Locators.ForEach(locator => locator.IsBestChoice = false));
            entries.ForEach(codeEntry => codeEntry.Locators.OrderBy(locator => (int)locator.SearchTypePreference).First().IsBestChoice = true);
            return entries;
        }

        public static IEnumerable<ICodeEntry> SetNames(this IEnumerable<ICodeEntry> codeEntries)
        {
            // TODO: write the code
            // NamingPreferences
            // return codeEntries;
            codeEntries.ForEach(codeEntry => codeEntry.MemberName = codeEntry.GenerateNameBasedOnNamingPreferences());
            return codeEntries;
        }

        /*
        title,
        name,
        id,
        tagName,
        linkText,
        className,
        */

        static string GenerateNameBasedOnNamingPreferences(this ICodeEntry codeEntry)
        {
            if (!codeEntry.Locators.Any())
                return codeEntry.MemberType + "NoName";
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

            return codeEntry.MemberType + "NoName";
        }
    }
}