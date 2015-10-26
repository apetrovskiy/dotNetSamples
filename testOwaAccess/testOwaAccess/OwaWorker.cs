/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 18/08/2015
 * Time: 10:50 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testOwaAccess
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Description of OwaForm.
    /// </summary>
    public class OwaWorker
    {
        async public Task Connect(string serverFqdn, string mailbox, string username, string password)
        {
            using (var client = new HttpClient()) {
                var data = new Dictionary<string, string> {
                    { "destination", "https://" + serverFqdn + "/owa/" + mailbox },
                    { "flags", "0" },
                    { "username", username },
                    { "password", password },
                    { "SubmitCreds", "Connection" },
                    { "forcedownlevel", "0" },
                    { "trusted", "0" }
                };
                var content = new FormUrlEncodedContent(data);
                var response = await client.PostAsync("https://" + serverFqdn + "/owa/" + mailbox, content);
                // var responseString = await response.Content.ReadAsStringAsync();
                var responseStream = await response.Content.ReadAsStreamAsync();
                // responseStream.
            }
        }
//        
//        string GetOwaForm(string serverFqdn, string mailbox, string username, string password)
//        {
//            //Constructs the Realex HTML form and returns it
//            var strForm = new StringBuilder();
//            strForm.AppendLine("<form id=\"logonForm\" name=\"logonForm\" target=\"_blank\" action=\"https://" + serverFqdn + "/owa/auth/owaauth.dll\" method=\"post\">");
//            // strForm.AppendLine("<input type=\"hidden\" name=\"destination\" value=\"https://" + serverFqdn + "/Exchange/\"/>");
//            strForm.AppendLine("<input type=\"hidden\" name=\"destination\" value=\"https://" + serverFqdn + "/owa/" + mailbox + "\"/>");
//            strForm.AppendLine("<input type=\"hidden\" name=\"flags\" value=\"0\"/>");
//            // strForm.AppendLine("<input type=\"hidden\" name=\"username\" id=\"username\"  />");
//            strForm.AppendLine("<input type=\"hidden\" name=\"username\" id=\"username\" value=\"" + username + "\" />");
//            // strForm.AppendLine("<input type=\"hidden\" name=\"password\" id=\"password\"  />");
//            strForm.AppendLine("<input type=\"hidden\" name=\"password\" id=\"password\" value=\"" + password + "\" />");
//            strForm.AppendLine("<input type=\"hidden\" id=\"SubmitCreds\" name=\"SubmitCreds\" value=\"Connection\"/>");
//            strForm.AppendLine("<input type=\"hidden\" id=\"rdoRich\" name=\"forcedownlevel\" value=\"0\"/>");
//            strForm.AppendLine("<input type=\"hidden\" id=\"rdoPublic\" name=\"trusted\" value=\"0\"/>");
//            strForm.AppendLine("</form>");
//            return strForm.ToString();
//        }
    }
}
