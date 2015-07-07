/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 06/07/2015
 * Time: 10:52 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testWebRequest
{
    using System;
    using Microsoft.Exchange.WebServices.Data;
    
    /// <summary>
    /// Description of Requester.
    /// </summary>
    public class Requester
    {
        public Requester()
        {
        }
        
        public void Test()
        {
            var service = new ExchangeService(ExchangeVersion.Exchange2010);
            service.Credentials = new WebCredentials("suite_admin", "Lock12Lock", "spanew");
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            service.Url = new Uri("https://splab-exchange.spalab.at.local/EWS/Exchange.asmx");
            
            
        }
    }
}
