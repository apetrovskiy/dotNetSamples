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
    /// Description of Command4.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Command4")]
    [OutputType(typeof(Lower))]
    public class Command4 : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            Lower lower = new Lower();
            lower.OutputString();
        }
    }
}
