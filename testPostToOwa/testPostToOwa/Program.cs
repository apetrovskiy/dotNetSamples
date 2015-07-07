/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 07/07/2015
 * Time: 05:49 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testPostToOwa
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    
    class Program
    {
        public static void Main(string[] args)
        {
            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertsPolicy();
            const string url = "https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local/";
            // const string url = "https://splab-exchange.spalab.at.local/owa/";
            // const string url = "https://192.168.129.3/owa/";
            // https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local/auth/owaauth.dll
            
            /*
            var request = WebRequest.Create(@"https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local");
            request.Credentials = new NetworkCredential("suite_admin", "Lock12Lock", "spanew");
            request.Method = "POST";
            
            var postData = @"
    <form action=""https://splab-exchange.spalab.at.local/owa/auth/owaauth.dll"" method=""POST"" name=""logonForm"" ENCTYPE=""application/x-www-form-urlencoded"" id=""loginForm"">
      <input type=""hidden"" name=""destination"" value=""https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local"">
      <input type=""hidden"" name=""username""  value=""suite_admin@spalab.at.local"" >
      <input type=""hidden"" name=""password""  value=""Lock12Lock"">
      <input type=""hidden"" name=""flags"" value=""4"">
      <input type=""hidden"" name=""forcedownlevel"" value=""0"">
      <input type=""radio""  name=""trusted"" value=""4"" class=""rdo"" checked>
      <input type=""hidden"" name=""isUtf8""  value=""1"">
    </form>
            ";
            
            // request.ContentLength = byteArray.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            Stream dataStream = request.GetRequestStream();
            
            */
            for (int i = 0; i < 10; i++) {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                       { "destination", "https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local/" },
                       // { "username", @"suite_admin@spalab.at.local" },
                       { "username", @"spanew\suite_admin" },
                       { "password", "Lock12Lock" },
                        // values["flags"] = "4";
                       { "flags", "0" },
                        
                       { "forcedownlevel", "0" },
                       { "rdoPblc", "0" },
                       { "rdoPrvt", "4" },
                       { "chkBsc", "on" },
                        
                        
                        // values["trusted"] = "4";
                       { "isUtf8", "1" }
                    };
                
                    var content = new FormUrlEncodedContent(values);
                
                    // var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);
                
                    // var responseString = await response.Content.ReadAsStringAsync();
                    
                    var response01 = client.PostAsync(url + "auth/owaauth.dll", content);
                    response01.Wait();
                    // var responseString01 = response01.Content.ReadAsStringAsync();
                }
                
                // System.Threading.Thread.Sleep(10000);
            }
            return;
            
            
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                // values["destination"] = "https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local";
                values["destination"] = "https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local/";
                // values["username"] = "suite_admin@spalab.at.local";
                values["username"] = @"spanew\suite_admin";
                values["password"] = "Lock12Lock";
                // values["flags"] = "4";
                values["flags"] = "0";
                
                values["forcedownlevel"] = "0";
                values["rdoPblc"] = "0";
                values["rdoPrvt"] = "4";
                values["chkBsc"] = "on";
                
                
                // values["trusted"] = "4";
                values["isUtf8"] = "1";
                // values["thing2"] = "world";
                // values["thing2"] = "world";
                
                // client.Credentials = new NetworkCredential("suite_admin", "Lock12Lock", "spanew");
                client.BaseAddress = "https://splab-exchange.spalab.at.local/owa/auth/owaauth.dll";
                // client.QueryString
                
                // var response = client.UploadValues("http://www.example.com/recepticle.aspx", values);
                var response02 = client.UploadValues("https://splab-exchange.spalab.at.local/owa/auth/owaauth.dll", values);
                
                var responseString02 = Encoding.Default.GetString(response02);
            }
            
            // var request = (HttpWebRequest)WebRequest.Create("https://splab-exchange.spalab.at.local/owa/auth/owaauth.dll");
            // var request = (HttpWebRequest)WebRequest.Create("https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local");
            var request = (HttpWebRequest)WebRequest.Create(url + "auth/owaauth.dll");
            
            // var postData = "destination=https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local";
            // "destination=https://splab-exchange.spalab.at.local/owa/auth/owaauth.dll";
            // var postData = "username=suite_admin@spalab.at.local";
            // var postData = "username=suite_admin%040spalab.at.local";
            var postData = @"username=spanew\suite_admin";
            // var postData = @"username=suite_admin";
            postData += "&password=Lock12Lock";
            /*
            postData += "&flags=4";
            postData += "&forcedownlevel=0";
            postData += "&trusted=4";
            */
            /*
            postData += "&flags=0";
            postData += "&forcedownlevel=0";
            postData += "&trusted=0";
            */
            postData += "&flags=0";
            postData += "&forcedownlevel=0";
            postData += "&rdoPblc=0";
            postData += "&rdoPrvt=4";
            postData += "&chkBsc=on";
            // postData += "&trusted=0";
            postData += "&isUtf8=1";
            // postData += "&destination=https://splab-exchange.spalab.at.local/owa/auth/owaauth.dll";
            // postData += "&destination=https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local";
            postData += "&destination=https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local/";
            // postData += "&https://splab-exchange.spalab.at.local/owa/auth/logon.aspx?url=https://splab-exchange.spalab.at.local/owa/report_reader@spalab.at.local/&reason=0";
            // postData += "&destination=report_reader@spalab.at.local/";
            // postData += "&destination=report_reader%040spalab.at.local/";
            // postData += url;
            var data = Encoding.ASCII.GetBytes(postData);
            
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            
            request.AllowAutoRedirect = true;
            // request.UserAgent
            
            // request.Credentials = new NetworkCredential("suite_admin", "Lock12Lock", "spanew");
            
            // request.ClientCertificates
            
            Console.WriteLine(request.RequestUri);
            
            var resp = request.GetResponse();
            
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
//            try {
            var response = (HttpWebResponse)request.GetResponse();
            
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
//            }
//            catch {}
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}