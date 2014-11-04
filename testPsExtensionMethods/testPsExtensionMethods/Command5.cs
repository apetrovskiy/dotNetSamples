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
    /// Description of Command5.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Command5")]
    [OutputType(typeof(IUpper))]
    public class Command5 : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            IUpper mix = new Mix();
            mix.Number();
        }
    }
}