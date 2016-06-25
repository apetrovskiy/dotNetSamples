/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 6/25/2016
 * Time: 10:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testRegExpGroup0001
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class TestClass
    {
       public void Test()
       {
          string pattern = @"\B[A-Z]"; // "[^0-9a-zA-Z]+(?<letter>[a-z])"; // @"\p{Sc}*(?<amount>\s?\d+[.,]?\d*)\p{Sc}*";
          string replacement = @"\U(${letter})"; // string.IsNullOrEmpty("${letter}") ? string.Empty : "${letter}".Substring("${letter}".Length - 1).ToUpper(); // "${amount}";
          string input = "#bbb#c#"; // "NotImplementedException"; // "#bbb#c#"; // "$16.32 12.19 £16.29 €18.29  €18,29";
          
          // var regex = new Regex(@"\b[A-Z]", RegexOptions.IgnoreCase);
          // a = regex.Replace(a, m=>m.ToString().ToUpper());
          var regex = new Regex(@"[^0-9a-zA-Z]+(?<letter>[a-z])", RegexOptions.IgnoreCase);
          input = regex.Replace(input, m=>m.ToString().ToUpper());
          
          bool res = Regex.IsMatch(input, pattern);
          Regex.Matches(input, pattern).Cast<Match>().ToList().ForEach(i => Console.WriteLine(i.Value)); //.ToList().ForEach(i => Console.WriteLine(i));
          string result = Regex.Replace(input, pattern, replacement);
          Console.WriteLine(result);
       }
    }
    // The example displays the following output:
    //       16.32 12.19 16.29 18.29  18,29
}
