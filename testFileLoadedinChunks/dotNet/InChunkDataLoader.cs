using System.Collections.Generic;
using System.Linq;

namespace dotNet
{
	public class InChunkDataLoader
	{
		public bool EndOfData { get; set; }

		public IEnumerable<T> Load<T>(InChunkLinesLoader linesLoader) where T : new()
		{
			var dataCollection = new List<T>();

			while (!linesLoader.EndOfData)
				dataCollection.AddRange(this.Convert<T>(linesLoader.GetChunkOfLines(2)));

			this.EndOfData = true;
			return dataCollection;
		}

		private IEnumerable<T> Convert<T>(IEnumerable<string> lines) where T : new()
		{
			if (null != lines && lines.Any())
			{

				// lines.Select(line => new T()).ToList().ForEach(item => Console.WriteLine(item));

				return lines.Select(line => new T());
			}
			else
			{
				return new List<T>();
			}
		}
	}
}