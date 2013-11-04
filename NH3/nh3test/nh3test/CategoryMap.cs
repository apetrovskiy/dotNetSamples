/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/8/2013
 * Time: 10:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace nh3test
{
    using System;
    using FluentNHibernate.Mapping;
    
	/// <summary>
	/// Description of CategoryMap.
	/// </summary>
	public class CategoryMap : ClassMap<Category>
	{
		public CategoryMap()
		{
			Id(x => x.Id);
			Map(x => x.Name);
			Map(x => x.Description);
		}
	}
}
