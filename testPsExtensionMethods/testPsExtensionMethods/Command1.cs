/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/7/2013
 * Time: 12:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation;

namespace testPsExtensionMethods
{
    /// <summary>
    /// Description of Command1.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Command1")]
    [OutputType(typeof(IUpper))]
    public class Command1 : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            IUpper upper = new Upper();
            upper.Number();
        }
    }
}
