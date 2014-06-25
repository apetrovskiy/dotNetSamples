/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 6/20/2014
 * Time: 8:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testAppium
{
	using System;
	using OpenQA.Selenium.Appium;
	using OpenQA.Selenium.Appium.Interfaces;
	using OpenQA.Selenium.Appium.MultiTouch;
	using OpenQA.Selenium.Remote;
	
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			// var commandExecutor = new AppiumDriverCommand();
			// var commandExecutor = new FirefoxDriverCommandExecutor(
			ICommandExecutor commandExecutor = null;
			var capabilities = new DesiredCapabilities();
			var driver = new AppiumDriver(commandExecutor, capabilities);
			driver.
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}