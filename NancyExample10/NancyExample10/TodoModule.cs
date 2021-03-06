﻿/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/1/2014
 * Time: 6:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExample10
{
	using System;
	using System.Collections.Generic;
	using Nancy;
	using Nancy.ModelBinding;
	
	/// <summary>
	/// Description of TodoModule.
	/// </summary>
	public class TodoModule : NancyModule
	{
		public static Dictionary<long, Todo> store = new Dictionary<long, Todo>();
		
//		public TodoModule() : base("todos")
//		{
//			Get["/"] = _ => Response.AsJson(store.Values);
//			
//			Post["/"] = _ =>
//			{
//				var newTodo = this.Bind<Todo>();
//				if (newTodo.id == 0)
//					newTodo.id = store.Count + 1;
//				
//				if (store.ContainsKey(newTodo.id))
//					return HttpStatusCode.NotAcceptable;
//				
//				store.Add(newTodo.id, newTodo);
//				return Response.AsJson(newTodo)
//					.WithStatusCode(HttpStatusCode.Created);
//			};
//			
//			Put["/{id}"] = p =>
//			{
//				if (!store.ContainsKey(p.id))
//					return HttpStatusCode.NotFound;
//				
//				var updatedTodo = this.Bind<Todo>();
//				store[p.id] = updatedTodo;
//				return Response.AsJson(updatedTodo);
//			};
//			
//			Delete["/{id}"] = p =>
//			{
//				if (!store.ContainsKey(p.id))
//					return HttpStatusCode.NotFound;
//				
//				store.Remove(p.id);
//				return HttpStatusCode.OK;
//			};
//		}
		
		public TodoModule(IDataStore todoStore) : base("todos")
		{
			Get["/"] = _ => Response.AsJson(todoStore.GetAll());
			
			Post["/"] = _ =>
			{
				var newTodo = this.Bind<Todo>();
				if (newTodo.id == 0)
					newTodo.id = store.Count + 1;
				
				if (!todoStore.TryAdd(newTodo))
					return HttpStatusCode.NotAcceptable;
				
				return Response.AsJson(newTodo).WithStatusCode(HttpStatusCode.Created);
			};
			
			Put["/{id}"] = p =>
			{
				var updatedTodo = this.Bind<Todo>();
				if (!todoStore.TryUpdate(updatedTodo))
					return HttpStatusCode.NotFound;
				
				return Response.AsJson(updatedTodo);
			};
			
			Delete["/{id}"] = p =>
			{
				if (!todoStore.TryRemove(p.id))
					return HttpStatusCode.NotFound;
				
				return HttpStatusCode.OK;
			};
		}
	}
}
