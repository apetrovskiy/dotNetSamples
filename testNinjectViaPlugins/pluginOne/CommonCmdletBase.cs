/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/10/2014
 * Time: 11:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace pluginOne
{
    using System;
	using centralLib;
    
    /// <summary>
    /// Description of CommonCmdletBase.
    /// </summary>
    public class CommonCmdletBase : PSCmdletBase
    {
        internal bool Loaded { get; set; }
        
        public CommonCmdletBase()
        {
            if (!Loaded) {
                centralLib.ObjectsFactory.Init(new ModuleOne());
                Loaded = true;
            }
        }
    }
}
