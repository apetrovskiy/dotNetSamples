/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/9/2013
 * Time: 11:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace nh3test
{
    using System;
    using FluentNHibernate.Mapping;
    
	/// <summary>
	/// Description of ProductMap.
	/// </summary>
	public class ProductMap : ClassMap<Product>
	{
		public ProductMap()
		{
			Id(x => x.Id);
			Map(x => x.Name);
			Map(x => x.Description);
			Map(x => x.UnitPrice);
			Map(x => x.ReorderLevel);
			Map(x => x.Discontinued);
			References(x => x.Category);
		}
	}
}
