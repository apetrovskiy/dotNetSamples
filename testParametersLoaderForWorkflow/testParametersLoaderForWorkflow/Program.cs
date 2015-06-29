/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 15/06/2015
 * Time: 08:21 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testParametersLoaderForWorkflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        public static void Main(string[] args)
        {
            const string pathToWorkflow = @"E:\1111111111111111\Workflow.xml";
            var xDocWfl = XDocument.Load(pathToWorkflow);
            
            var defaultData = from defaultDataItem in xDocWfl.Descendants("defaults")
                        select defaultDataItem;
            var defaultParameterValue = new XAttribute("value", string.Empty);
            foreach (XElement element in defaultData.Elements("param")) {
                var key = element.Attribute("name").Value;
                var val = (element.Attribute("value") ?? defaultParameterValue).Value;
                Console.WriteLine(key + "; " + val);
            }
            
            const string pathToDefaults = @"E:\1111111111111111\defaults.xml";
            var xDocDef = XDocument.Load(pathToDefaults);
            var workflowElement = xDocDef.Descendants("workflow").First();
            
            if (null == workflowElement)
                Console.WriteLine("NULL!");
            
            var defaultAttributeValue = new XAttribute("name", string.Empty);
            string result = string.Empty;
            if (null != workflowElement)
                result = (workflowElement.Attribute("name") ?? defaultAttributeValue).Value;
            Console.WriteLine(result);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}