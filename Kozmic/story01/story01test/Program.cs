/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/16/2013
 * Time: 5:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using story01;

namespace story01test
{
    class Program
    {
        private static void Main(string[] args)
        {
            var rex = Freezable.MakeFreezable<Pet>();
            rex.Name = "Rex";
            Console.WriteLine(Freezable.IsFreezable(rex)
                                  ? "Rex is freezable!"
                                  : "Rex is not freezable. Something is not working");
            Console.WriteLine(rex.ToString());
            Console.WriteLine("Add 50 years");
            rex.Age += 50;
            Console.WriteLine("Age: {0}", rex.Age);
            rex.Deceased = true;
      
            Console.WriteLine("Deceased: {0}", rex.Deceased);
            Freezable.Freeze(rex);
            try
            {
                rex.Age++;
            }
            catch(ObjectFrozenException ex)
            {
                Console.WriteLine("Oups. it's frozen. Can't change that anymore");
            }
            Console.WriteLine("--- press enter to close");
            Console.ReadLine();
        }
    }
}