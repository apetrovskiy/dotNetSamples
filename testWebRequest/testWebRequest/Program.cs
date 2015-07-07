/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 06/07/2015
 * Time: 09:23 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testWebRequest
{
    using System;
    using System.IO;
    using System.Net;
    
    class Program
    {
        public static void Main(string[] args)
        {
//            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
//            
//            
//            Uri uri = new Uri(@"https://splab-exchange.spalab.at.local/owa");
//            WebRequest webRequest = WebRequest.Create(uri);
//            WebResponse webResponse = webRequest.GetResponse();
//            // Stream ReadFrom(webResponse.GetResponseStream());
            
            var requester = new Requester();
            requester.Test();
            
            var imitator = new WebRequestImitator(@"https://splab-exchange.spalab.at.local/owa", "spanew", "suite_admin", "Lock12Lock");
            imitator.InvokeOwaRequest();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        
        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}