/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 3/5/2014
 * Time: 7:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace pureX86
{
	using System;
	using System.Windows.Forms;
	using System.Linq;
//	using NetWrix.ChangeReporterConfigurator;
//	using NetWrix.ChangeReporterProviderInterfaces;
//	using NetWrix.SCChangeReporterProvider;
	
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
//			var configuration = new SCConfiguration();
//			var configurator = new SCConfigurator();
//			configurator.Load(string.Empty);
//			if (null == configurator) {
//				Console.WriteLine("null == configurator");
//			} else {
//				Console.WriteLine("null != configurator");
//			}
			
			// configurator.Configuration.
			
//			string variables = string.Empty;
//			foreach (string variable in Environment.GetEnvironmentVariables().Values) {
//				variables += variable;
//				variables += "\r\n";
//			}
//			MessageBox.Show(variables);
			
			// MessageBox.Show(sizeof(int).ToString());
			MessageBox.Show(IntPtr.Size.ToString());
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}