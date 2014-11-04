﻿/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/5/2013
 * Time: 12:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSub
{
    using System;
    using System.Windows.Automation;
    //using System.Drawing;

    /// <summary>
    /// Description of AutomationElementAdapter.
    /// </summary>
    public class AutomationElementAdapter : IAutomationElementAdapter
	{
        private AutomationElement elementHolder;
        
        public AutomationElementAdapter()
        {
        }
        
        public AutomationElementAdapter(AutomationElement element)
        {
            this.elementHolder = element;
        }
        
		public bool Equals(object obj)
		{
		    return this.elementHolder.Equals(obj);
		}
		
		public int GetHashCode()
		{
		    return this.elementHolder.GetHashCode();
		}
		
		public int[] GetRuntimeId()
		{
		    return this.elementHolder.GetRuntimeId();
		}
		
		public object GetCurrentPropertyValue(AutomationProperty property)
		{
		    return this.elementHolder.GetCurrentPropertyValue(property);
		}
		
		public object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
		    return this.elementHolder.GetCurrentPropertyValue(property, ignoreDefaultValue);
		}
		
		public object GetCurrentPattern(AutomationPattern pattern)
		{
		    return this.elementHolder.GetCurrentPattern(pattern);
		}
		
		public bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
		{
		    return this.elementHolder.TryGetCurrentPattern(pattern, out patternObject);
		}
		
		public object GetCachedPropertyValue(AutomationProperty property)
		{
		    return this.elementHolder.GetCachedPropertyValue(property);
		}
		
		public object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
		    return this.elementHolder.GetCachedPropertyValue(property, ignoreDefaultValue);
		}
		
		public object GetCachedPattern(AutomationPattern pattern)
		{
		    return this.elementHolder.GetCachedPattern(pattern);
		}
		
		public bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject)
		{
		    return this.elementHolder.TryGetCachedPattern(pattern, out patternObject);
		}
		
		public AutomationElement GetUpdatedCache(CacheRequest request)
		{
		    return this.elementHolder.GetUpdatedCache(request);
		}
		
		//public AutomationElement FindFirst(TreeScope scope, Condition condition)
		public IAutomationElementAdapter FindFirst(TreeScope scope, Condition condition)
		{
		    IAutomationElementAdapter adapterElement =
		        new AutomationElementAdapter(this.elementHolder.FindFirst(scope, condition));
		    return adapterElement;
		}
		
		//public AutomationElementCollection FindAll(TreeScope scope, Condition condition)
		public IAutomationElementCollection FindAll(TreeScope scope, Condition condition)
		{
		    //return this.elementHolder.FindAll(scope, condition);
		    IAutomationElementCollection adapterColleciton =
		        new AutomationElementCollectionAdapter(
		            this.elementHolder.FindAll(scope, condition));
		    return adapterColleciton;
		}
		
		public AutomationProperty[] GetSupportedProperties()
		{
		    return this.elementHolder.GetSupportedProperties();
		}
		
		public AutomationPattern[] GetSupportedPatterns()
		{
		    return this.elementHolder.GetSupportedPatterns();
		}
		
		public void SetFocus()
		{
		    this.elementHolder.SetFocus();
		}
		
		//public bool TryGetClickablePoint(out Point pt)
		public bool TryGetClickablePoint(out System.Windows.Point pt)
		{
		    return this.elementHolder.TryGetClickablePoint(out pt);
		}
		
		//public Point GetClickablePoint()
		public System.Windows.Point GetClickablePoint()
		{
		    return this.elementHolder.GetClickablePoint();
		}
		
		public AutomationElement.AutomationElementInformation Cached
		{
		    get { return this.elementHolder.Cached; }
		}
		
		public AutomationElement.AutomationElementInformation Current
		{
		    get { return this.elementHolder.Current; }
		}
		
		public AutomationElement CachedParent
		{
		    get { return this.elementHolder.CachedParent; }
		}
		
		public AutomationElementCollection CachedChildren
		{
		    get { return this.elementHolder.CachedChildren; }
		}
		
		
		public AutomationElement SourceElement
		{
		    get { return this.elementHolder; }
		    set { this.elementHolder = value; }
		}
		
		public static AutomationElement RootElement
		{
		    get { return AutomationElement.RootElement; }
		}
	}
}
