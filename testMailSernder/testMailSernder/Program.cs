/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 1/13/2015
 * Time: 5:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testMailSernder
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var client = new System.Net.Mail.SmtpClient();
            client.EnableSsl
            
            // TODO: Implement Functionality Here
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}