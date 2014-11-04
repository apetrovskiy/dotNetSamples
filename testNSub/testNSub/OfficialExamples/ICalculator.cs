/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 11/15/2013
 * Time: 2:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSub
{
    using System;
    
    /// <summary>
    /// Description of ICalculator.
    /// </summary>
    public interface ICalculator
    {
        int Add(int a, int b);
        string Mode { get; set; }
        event EventHandler PoweringUp;
    }
}
