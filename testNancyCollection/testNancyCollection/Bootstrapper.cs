/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 14/04/2015
 * Time: 09:42 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNancyCollection
{
    using System;
    using Nancy;
    using Nancy.Diagnostics;
    using Nancy.Diagnostics.Modules;
    
    /// <summary>
    /// Description of Bootstrapper.
    /// </summary>
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override DiagnosticsConfiguration DiagnosticsConfiguration {
            get {
                return new DiagnosticsConfiguration { Password = @"Tmx=admin" };
            }
        }
    }
}
