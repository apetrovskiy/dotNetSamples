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
    /// Description of Command6.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Command6")]
    [OutputType(typeof(ILower))]
    public class Command6 : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            ILower mix = new Mix();
            mix.OutputString();
        }
    }
}