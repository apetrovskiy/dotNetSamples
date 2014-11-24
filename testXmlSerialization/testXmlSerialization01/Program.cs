/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/6/2014
 * Time: 2:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testXmlSerialization
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using Tmx.Core;
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    using System.Management.Automation;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            SerialiseInterface.SerialiseAnimals();
            Program2.Main2(new string[]{});
            
            var testSuite = new TestSuite {
                Id = "1",
                Name = "s01",
                PlatformId = "p1"
            };
            var testScenario = new TestScenario {
                Id = "1",
                Name = "sc01",
                PlatformId = "p1",
                SuiteId = "1"
            };
            testScenario.TestResults.Add(
                new TestResult {
                    Id = "1",
                    Name = "tr01",
                    PlatformId = "p1",
                    ScenarioId = "1",
                    SuiteId = "1",
                    enStatus = TestResultStatuses.Passed
                });
            testScenario.TestResults.Add(
                new TestResult {
                    Id = "2",
                    Name = "tr02",
                    PlatformId = "p1",
                    ScenarioId = "1",
                    SuiteId = "1",
                    enStatus = TestResultStatuses.Passed
                });
            testScenario.TestResults.Add(
                new TestResult {
                    Id = "3",
                    Name = "tr03",
                    PlatformId = "p1",
                    ScenarioId = "1",
                    SuiteId = "1",
                    enStatus = TestResultStatuses.Passed
                });
            testSuite.TestScenarios.Add(testScenario);
            var list = new List<ITestSuite>();
            list.Add(testSuite);
            
            var testResultsImportExport = new TestResultsImportExport();
            var xDoc = testResultsImportExport.GetTestResultsAsXdocument(new SearchCmdletBaseDataObject { FilterAll = true }, list);
            
            var xmlCode = @"
            <suites>
                <suite id=""1"" name=""s01"" platformId=""1"" />
            </suites>";
            xDoc = XDocument.Parse(xmlCode);
            
            var newSerializedString = xDoc.ToString().Replace("\"", @"""");
            
            var result = xDoc.SerializeToString();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}