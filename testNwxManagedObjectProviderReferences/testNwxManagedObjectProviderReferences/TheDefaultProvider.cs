/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/3/2014
 * Time: 2:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using NetWrix.ChangeReporterProviderInterfaces;


namespace testNwxManagedObjectProviderReferences
{
    /// <summary>
    /// Description of TheDefaultProvider.
    /// </summary>
    public class TheDefaultProvider : IChangeReporterProviderType
    {
        public string ProviderName { get; internal set; }
        public string ProviderDescription { get; internal set; }
        public string ProviderDisplayName { get; internal set; }
        public Icon ProviderIcon { get; internal set; }
    }
}
