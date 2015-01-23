/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 1/23/2015
 * Time: 4:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSshNet
{
    using System;
    
    /// <summary>
    /// Description of VirtualMachine.
    /// </summary>
    public class VirtualMachine : IEsxiVirtualMachine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string GuestOperatingSystem { get; set; }
        public string Version { get; set; }
        public string Annotation { get; set; }
    }
}
