/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 17/12/2015
 * Time: 10:47 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testHierarchyCleanUp
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of Suite.
    /// </summary>
    public class Suite
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public IEnumerable<Scenario> Scenarios { get; set; }
        
        public Suite()
        {
            Scenarios = new List<Scenario>();
        }
    }
}
