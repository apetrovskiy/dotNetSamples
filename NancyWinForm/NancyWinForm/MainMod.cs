/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/6/2015
 * Time: 10:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyWinForm
{
    using System;
    using Nancy;
    
    /// <summary>
    /// Description of MainMod.
    /// </summary>
    public class MainMod : NancyModule
    {
        public MainMod()
        {
            Get["/"] = x => "Wee hoo! - no more little green monster...";
        }
    }
}
