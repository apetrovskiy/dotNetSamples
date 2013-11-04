/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/8/2013
 * Time: 10:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nh3test
{
	/// <summary>
	/// Description of Product.
	/// </summary>
	public class Product
	{
//		public Product()
//		{
//		}
		
		public virtual int Id { get; protected set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual Category Category { get; set; }
		public virtual decimal UnitPrice { get; set; }
		public virtual int ReorderLevel { get; set; }
		public virtual bool Discontinued { get; set; }
	}
}
