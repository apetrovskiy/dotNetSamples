/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 5/13/2014
 * Time: 9:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSpec
{
	using System;
	using NSpec;
	
	/// <summary>
	/// Description of NspecTest1.
	/// </summary>
	public class NspecTest1 : nspec
	{
		void before_each() { name = "NSpec"; }
		
		void it_works()
		{
		    name.should_be("NSpec");
		}
		
		void describe_nesting()
		{
		    before = () => name += " BDD";
		
		    it["works here"] = () => name.should_be("NSpec BDD");
		
		    it["and here"] = () => name.should_be("NSpec BDD");
		}
		string name;
	}
}
