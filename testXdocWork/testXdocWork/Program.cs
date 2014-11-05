/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/5/2014
 * Time: 8:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testXdocWork
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var suites = @"<suites>
  <suite id=\"100\" name=\"test suite 01\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
    <scenarios>
      <scenario id=\"1\" name=\"scenario 01\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"16\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"16\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"1\" name=\"scenario 01\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"16\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"16\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
    </scenarios>
  </suite>
  <suite id=\"100\" name=\"test suite 01\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
    <scenarios>
      <scenario id=\"1\" name=\"scenario 01\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"16\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"16\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"1\" name=\"scenario 01\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"16\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"16\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
    </scenarios>
  </suite>
  <suite id=\"1000\" name=\"test suite 02\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
    <scenarios>
      <scenario id=\"1\" name=\"scenario 01\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"1\" name=\"scenario 01\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"2\" name=\"scenario 02\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0002\" status=\"FAILED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0002\" status=\"FAILED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"2\" name=\"scenario 02\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0002\" status=\"FAILED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0002\" status=\"FAILED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"3\" name=\"scenario 03\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0003\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0003\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"2\" name=\"test 0004\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"2\" name=\"test 0004\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"3\" name=\"scenario 03\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0003\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0003\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"2\" name=\"test 0004\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"2\" name=\"test 0004\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
    </scenarios>
  </suite>
  <suite id=\"1000\" name=\"test suite 02\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
    <scenarios>
      <scenario id=\"1\" name=\"scenario 01\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"1\" name=\"scenario 01\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0001\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"2\" name=\"scenario 02\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0002\" status=\"FAILED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0002\" status=\"FAILED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"2\" name=\"scenario 02\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0002\" status=\"FAILED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0002\" status=\"FAILED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"3\" name=\"scenario 03\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0003\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0003\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"2\" name=\"test 0004\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"2\" name=\"test 0004\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"3\" name=\"scenario 03\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 0003\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 0003\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"2\" name=\"test 0004\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"2\" name=\"test 0004\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
    </scenarios>
  </suite>
  <suite id=\"10000\" name=\"test suite 0100\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
    <scenarios>
      <scenario id=\"1\" name=\"scenario 0100\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 00100\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 00100\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"1\" name=\"scenario 0100\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 00100\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 00100\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
    </scenarios>
  </suite>
  <suite id=\"10000\" name=\"test suite 0100\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
    <scenarios>
      <scenario id=\"1\" name=\"scenario 0100\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 00100\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 00100\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
      <scenario id=\"1\" name=\"scenario 0100\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 00100\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
          <testResult id=\"1\" name=\"test 00100\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
    </scenarios>
  </suite>
  <suite id=\"100000\" name=\"test suite 01000\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
    <scenarios>
      <scenario id=\"1\" name=\"scenario 01000\" status=\"NOT TESTED\" timeSpent=\"0\" all=\"0\" passed=\"0\" failed=\"0\" notTested=\"0\" knownIssue=\"0\" description=\"\" platformId=\"2\">
        <testResults>
          <testResult id=\"1\" name=\"test 001000\" status=\"PASSED\" origin=\"Logical\" timeSpent=\"0\" timestamp=\"0001-01-01T00:00:00\" description=\"\" platformId=\"2\" />
        </testResults>
      </scenario>
    </scenarios>
  </suite>
</suites>";
            var xDoc = XDocument.Parse(suites);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}