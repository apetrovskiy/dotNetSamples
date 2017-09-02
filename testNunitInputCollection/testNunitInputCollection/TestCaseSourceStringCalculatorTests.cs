namespace testNunitInputCollection
{
	using System.Collections.Generic;
	using System.Configuration;
	using System.IO;
	using System.Linq;
	using NUnit.Framework;

	[TestFixture]
	public class TestCaseSourceStringCalculatorTests
	{

		private static IEnumerable<TestCaseData> AddFilesFromFolder()
		{
			var folderPath = ConfigurationManager.AppSettings["TestDataFolderPath"] ?? throw new FileNotFoundException("Unable to open a folder with test data");
			var files = Directory.GetFiles(folderPath).ToList();
			return files.Select(file => new TestCaseData(file));
		}

		[Test, TestCaseSource(nameof(AddFilesFromFolder))]
		public void Add_SimpleInputs_AddsNumbers(string filePath)
		{
			using (var reader = new StreamReader(filePath))
			{
				var content = reader.ReadToEnd();
				Assert.AreNotEqual(0, content.Length);
			}
		}
	}
}
