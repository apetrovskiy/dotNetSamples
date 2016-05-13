/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 17/12/2015
 * Time: 10:49 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testHierarchyCleanUp
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of Scenario.
    /// </summary>
    public class Scenario
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public IEnumerable<Result> Results { get; set; }
        
        public Scenario()
        {
            Results = new List<Result>();
        }
    }
}
