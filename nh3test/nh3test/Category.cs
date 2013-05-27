/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/8/2013
 * Time: 10:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nh3test
{
	/// <summary>
	/// Description of Category.
	/// </summary>
	public class Category
	{
//		public Category()
//		{
//		}
		
		public virtual int Id { get; protected set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
	}
}
