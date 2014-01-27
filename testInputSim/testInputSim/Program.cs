/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 1/17/2014
 * Time: 1:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInputSim
{
    using System;
    using WindowsInput;
    using WindowsInput.Native;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
//            WindowsInput.IMouseSimulator mouseSim =
//                new MouseSimulator(
            
            // InputSimulator
            
            var sim =
                new InputSimulator();
            sim.Mouse.LeftButtonDoubleClick();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}