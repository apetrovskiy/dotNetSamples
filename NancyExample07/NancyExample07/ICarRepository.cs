/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 6/30/2014
 * Time: 7:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NancyExample07
{
	/// <summary>
	/// Description of ICarRepository.
	/// </summary>
	public interface ICarRepository
	{
		Car GetById(int id);
	}
}
