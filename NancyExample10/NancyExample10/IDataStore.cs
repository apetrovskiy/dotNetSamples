/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/1/2014
 * Time: 8:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExample10
{
	using System;
	using System.Collections.Generic;
	
	/// <summary>
	/// Description of IDataStore.
	/// </summary>
	public interface IDataStore
	{
		IEnumerable<Todo> GetAll();
		long Count { get; }
		bool TryAdd(Todo todo);
		bool TryRemove(int id);
		bool TryUpdate(Todo todo);
	}
}
