/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 6/30/2014
 * Time: 7:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NancyExample10
{
	/// <summary>
	/// Description of CarRepository.
	/// </summary>
	public class CarRepository : ICarRepository
	{
		public Car GetById(int id)
		{
			if (321 == id)
				throw new CarNotFoundException();
			
			return new Car
			{
				Id = id,
				Make = "Testla",
				Model = "Model S"
			};
		}
	}
}
