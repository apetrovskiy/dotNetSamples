/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/7/2013
 * Time: 12:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation;

namespace testPsExtensionMethods
{
    /// <summary>
    /// Description of Command2.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Command2")]
    [OutputType(typeof(Upper))]
    public class Command2 : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            Upper upper = new Upper();
            upper.Number();
        }
    }
}
