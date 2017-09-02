using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet
{
	class Program
	{
		static void Main(string[] args)
		{
			var inChuckDataLoader = new InChunkDataLoader();

			while (!inChuckDataLoader.EndOfData)
			{
				// var data = inChuckDataLoader.Load<DataType>(new InChunkLinesLoader(@"Selenium_questions.txt", @"..\\"));
				// var data = inChuckDataLoader.Load<DataType>(new InChunkLinesLoader(@"Selenium_questions_2.txt", @"..\\"));
				var data = inChuckDataLoader.Load<DataType>(new InChunkLinesLoader(@"Selenium_questions_3.txt", @"..\\"));
				// var data = inChuckDataLoader.Load<DataType>(new InChunkLinesLoader(@"5lines.txt", @"\\"));
				data.ToList().ForEach(item => Console.WriteLine(item));
			}

			Console.ReadKey();
		}
	}
}