namespace testAutoMapperCollections.Types
{
	public class Type01 : IFirst, ISecond
	{
		public string StringData { get; set; }
		public int IntData { get; set; }
		public bool BoolData { get; set; }
		public double DoubleData { get; set; }
	}
}