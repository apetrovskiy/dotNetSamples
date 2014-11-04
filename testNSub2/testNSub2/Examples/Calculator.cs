/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 11/15/2013
 * Time: 2:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSub2
{
    using System;
    
    /// <summary>
    /// Description of Calculator.
    /// </summary>
    public class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            //PoweringUpEventHandler handler = new PoweringUpEventHandler(poweringUp);
            //handler(a.ToString() + " + " + b.ToString());
            return (a + b);
        }
        public string Mode { get; set; }
        public event EventHandler PoweringUp;
        
//        private void poweringUp(string s)
//        {
//            //Console.WriteLine(s);
//        }
    }
    
    //public delegate void PoweringUpEventHandler(string msg);
}
