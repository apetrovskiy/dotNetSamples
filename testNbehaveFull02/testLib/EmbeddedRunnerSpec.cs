/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 6/25/2014
 * Time: 4:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using NBehave.Narrator.Framework;
using NUnit.Framework;

// namespace EmbeddedRunner.Example
namespace testLib
{
    [TestFixture]
    public class EmbeddedRunnerSpec
    {
        [Test]
        public void Should_write_Feature()
        {
            @"
            Feature: x
                narrative
            Scenario: y
                Given a
                When b
                Then c"
            .ExecuteText();
        }
    }
}
