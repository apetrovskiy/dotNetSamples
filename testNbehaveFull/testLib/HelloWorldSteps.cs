/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 6/25/2014
 * Time: 3:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using NBehave.Narrator.Framework;
using NBehave.Spec.NUnit;

namespace testLib
{
    [ActionSteps]
    public class HelloWorldSteps
    {
        [Given("I am not logged in")]
        public void LogOut()
        {
            // put code here.
        }
    
        [When("I log in as $username with a password $password")]
        public void LogIn(string username, string password)
        {
            // put code here.
        }
    
        [Then("I should see a message, \"$message\"")]
        public void CheckMessage(string message)
        {
            // put code here.
        }
    }
}