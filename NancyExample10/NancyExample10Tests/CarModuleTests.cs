/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/1/2014
 * Time: 5:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExample10Tests
{
	using System;
	using Nancy;
	using Nancy.Testing;
	using Xunit;
	using NancyExample10;
	
	/// <summary>
	/// Description of CarModuleTests.
	/// </summary>
	public class CarModuleTests
	{
		[Fact]
		public void Should_answer_200_on_root_path_default_bootstrapper()
		{
			var sut = new Browser(new DefaultNancyBootstrapper());
			
			var actual = sut.Get("/");
			
			Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
		}
		
		[Fact]
		public void Should_answer_200_on_root_path_structureMap_bootstrapper()
		{
			var sut = new Browser(new NancyBootstrapper());
			
			var actual = sut.Get("/");
			
			Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
		}
		
		[Fact]
		public void Should_answer_HelloWorld_on_status_path()
		{
			var sut = new Browser(new NancyBootstrapper());
			
			var actual = sut.Get("/status");
			
			Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
		}
		
		[Fact]
		public void Should_answer_car123_on_status_path()
		{
			var sut = new Browser(new NancyBootstrapper());
			
			var actual = sut.Get("/car/123");
			
			Assert.Equal(HttpStatusCode.InternalServerError, actual.StatusCode);
		}
		
		[Fact]
		public void Should_answer_car321_on_status_path()
		{
			var sut = new Browser(new NancyBootstrapper());
			
			var actual = sut.Get("/car/321");
			
			Assert.Equal(HttpStatusCode.NotFound, actual.StatusCode);
		}
		
		[Fact]
		public void Should_answer_ford_on_status_path()
		{
			var sut = new Browser(new NancyBootstrapper());
			
			var actual = sut.Get("/ford/mondeo");
			
			Assert.Equal(HttpStatusCode.InternalServerError, actual.StatusCode);
		}
		
		[Fact]
		public void Should_answer_tesla_on_status_path()
		{
			var sut = new Browser(new NancyBootstrapper());
			
			var actual = sut.Get("/tesla/model%20s");
			
			Assert.Equal(HttpStatusCode.InternalServerError, actual.StatusCode);
		}
	}
}