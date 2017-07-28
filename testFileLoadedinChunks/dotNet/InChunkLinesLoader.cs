namespace dotNet
{
	using System;
	using System.Collections.Generic;
	using System.IO;

	public class InChunkLinesLoader
	{
		private const string BasePath = @"D:\tests\";
		private int LastPosition { get; set; }
		private string FilePath { get; set; }
		public bool EndOfData { get; set; }

		public InChunkLinesLoader(string fileName, string subFolder)
		{
			this.FilePath = BasePath + subFolder + fileName;
			if (!File.Exists(this.FilePath))
				throw new FileNotFoundException(this.FilePath);
			this.LastPosition = 0;
			this.EndOfData = false;
		}

		public IEnumerable<string> GetChunkOfLines(int numberInChunk)
		{
			var lines = new List<string>();
			using (var reader = new StreamReader(this.FilePath))
			{
				for (var i = 0; i < this.LastPosition; i++)
					reader.ReadLine();

				for (var i = 0; i < numberInChunk; i++)
				{
					if (reader.EndOfStream)
					{
						this.EndOfData = true;
						return lines;
					}
					lines.Add(reader.ReadLine());
				}

				this.LastPosition += numberInChunk;
			}
			return lines;
		}
	}
}