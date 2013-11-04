/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/3/2013
 * Time: 5:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Drawing;

//using MS.Internal.Automation;
using System;
using System.Collections;
using System.ComponentModel;
//using System.Windows.Automation.Provider;
namespace System.Windows.Automation
{
	public interface IAutomationElement
	{
		bool Equals(object obj);
		int GetHashCode();
		int[] GetRuntimeId();
		object GetCurrentPropertyValue(AutomationProperty property);
		object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue);
		object GetCurrentPattern(AutomationPattern pattern);
		bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject);
		object GetCachedPropertyValue(AutomationProperty property);
		object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue);
		object GetCachedPattern(AutomationPattern pattern);
		bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject);
		AutomationElement GetUpdatedCache(CacheRequest request);
		AutomationElement FindFirst(TreeScope scope, Condition condition);
		AutomationElementCollection FindAll(TreeScope scope, Condition condition);
		AutomationProperty[] GetSupportedProperties();
		AutomationPattern[] GetSupportedPatterns();
		void SetFocus();
		bool TryGetClickablePoint(out Point pt);
		Point GetClickablePoint();
		AutomationElement.AutomationElementInformation Cached { get; }
		AutomationElement.AutomationElementInformation Current { get; }
		AutomationElement CachedParent { get; }
		AutomationElementCollection CachedChildren { get; }
	}
}

