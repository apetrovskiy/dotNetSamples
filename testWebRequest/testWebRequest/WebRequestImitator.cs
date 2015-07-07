/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 06/07/2015
 * Time: 09:30 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testWebRequest
{
    using System;
    using System.IO;
    using System.Net;
    
    /// <summary>
    /// Description of WebRequestImitator.
    /// </summary>
    public class WebRequestImitator
    {
        Uri _uri;
        string _url;
        string _domain;
        string _username;
        string _password;
        
        public WebRequestImitator(string url, string domain, string username, string password)
        {
            _uri = new Uri(url);
            _url = url;
            _domain = domain;
            _username = domain + "\\" + username; // username;
            _password = password;
        }
        
        public void InvokeOwaRequest()
        {
            bool result = false;
            int statusCode = 0;
            int latency = 0;
            
            CookieContainer cookies = new CookieContainer();
            
            // var url = "https://192.168.129.3/owa/report_reader@spalab.at.local/";
            var url = "https://192.168.129.3/owa/";
            
            try{
                // #########################
                // Work around to Trust All Certificates is is from this post
                
//                add-type @"
//                    using System.Net;
//                    using System.Security.Cryptography.X509Certificates;
//                    public class TrustAllCertsPolicy : ICertificatePolicy {
//                        public bool CheckValidationResult(
//                            ServicePoint srvPoint, X509Certificate certificate,
//                            WebRequest request, int certificateProblem) {
//                            return true;
//                       }
//                   }
//                "@
                // [System.Net.ServicePointManager]::CertificatePolicy = New-Object TrustAllCertsPolicy
                ServicePointManager.CertificatePolicy = new TrustAllCertsPolicy();
                // ServicePointManager.ServerCertificateValidationCallback = new TrustAllCertsPolicy();
                // Initialize Stop Watch to calculate the latency.
                
                CredentialCache cache = new CredentialCache();
                // cache.Add(new Uri("https://splab-exchange.spalab.at.local"), "Negotiate", new NetworkCredential("suite_admin", "Lock12Lock", "spanew"));
                // cache.Add(new Uri("https://splab-exchange.spalab.at.local/owa"), "Negotiate", new NetworkCredential("suite_admin", "Lock12Lock", "spanew"));
                cache.Add(new Uri(url), "Negotiate", new NetworkCredential("suite_admin", "Lock12Lock", "spanew"));
                // cache.Add(new Uri(url), "Negotiate", new WebCredentials);
                
                
                // $StopWatch = [system.diagnostics.stopwatch]::startNew()
                var stopWatch = System.Diagnostics.Stopwatch.StartNew();
                
                // Invoke the login page
                // $Response = Invoke-WebRequest -Uri $URL -SessionVariable owa
                var webRequest = (HttpWebRequest)WebRequest.Create(_url);
                webRequest.CookieContainer = cookies;
                
                webRequest.UseDefaultCredentials = false;
                // webRequest.RequestUri = _uri;
                webRequest.PreAuthenticate = true;
                webRequest.Method = WebRequestMethods.Http.Get;
                // webRequest.AuthenticationLevel = AuthenticationLevel
                // webRequest.Credentials = new NetworkCredential("suite_admin", "Lock12Lock", "spanew");
                webRequest.Credentials = cache;
                
                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse()) {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    Console.WriteLine(reader.ReadToEnd());
                }
                
                
                // htmlwebresponse
                // webRequest.
                // var response = webRequest.GetResponse();
                int i = 1;
                // Login Page - Fill Logon Form
                
//                if ($Response.forms[0].id -eq "logonform") {
//                $Form = $Response.Forms[0]
//                $Form.fields.username= $Username
//                $form.Fields.password= $Password
//                $authpath = "$URL/auth/owaauth.dll"
//                #Login to OWA
//                $Response = Invoke-WebRequest -Uri $authpath -WebSession $owa -Method POST -Body $Form.Fields
//                #SuccessfulLogin 
//                if ($Response.forms[0].id -eq "frm") {
//                  #Retrieve Status Code
//                  $StatusCode = $Response.StatusCode
//                  # Logoff Session
//                  $logoff = "$URL/auth/logoff.aspx?Cmd=logoff&src=exch"
//                  $Response = Invoke-WebRequest -Uri $logoff -WebSession $owa
//                  #Calculate Latency
//                  $StopWatch.stop()
//                  $Latency = $StopWatch.Elapsed.TotalSeconds
//                  $Result = $True
//                }
//                #Fill Out Language Form, if it is first login
//                elseif ($Response.forms[0].id -eq "lngfrm") {
//                  $Form = $Response.Forms[0]
//                
//                  #Set Default Values
//                  $Form.Fields.add("lcid",$Response.ParsedHtml.getElementById("selLng").value)
//                  $Form.Fields.add("tzid",$Response.ParsedHtml.getElementById("selTZ").value)
//                
//                  $langpath = "$URL/lang.owa"
//                  $Response = Invoke-WebRequest -Uri $langpath -WebSession $owa -Method $form.Method -Body $form.fields
//                  #Retrieve Status Code
//                  $StatusCode = $Response.StatusCode
//                  # Logoff Session
//                  $logoff = "$URL/auth/logoff.aspx?Cmd=logoff&src=exch"
//                  $Response = Invoke-WebRequest -Uri $logoff -WebSession $owa
//                  #Calculate Latency
//                  $StopWatch.stop()
//                  $Latency = $StopWatch.Elapsed.TotalSeconds
//                  $Result = $True
//                }
//                elseif ($Response.forms[0].id -eq "logonform") {
//                  #We are still in LogonPage
//                  #Retrieve Status Code
//                  $StatusCode = $Response.StatusCode
//                  #Calculate Latency
//                  $StopWatch.stop()
//                  $Latency = $StopWatch.Elapsed.TotalSeconds
//                  $Result = "Failed to logon $username. Check the password or account."
//                }
//                }
                
            }
                
                // Catch Exception, If any
                catch (Exception eSomeWebException)
            {
                    Console.WriteLine(eSomeWebException.Message);
//                #Retrieve Status Code
//                $StatusCode = $Response.StatusCode
//                if ($StatusCode -notmatch '\d\d\d') {$StatusCode = 0}
//                #Calculate Latency
//                $StopWatch.stop()
//                $Latency = $StopWatch.Elapsed.TotalSeconds
//                $Result = $_.Exception.Message
            }
        }
    }
}
