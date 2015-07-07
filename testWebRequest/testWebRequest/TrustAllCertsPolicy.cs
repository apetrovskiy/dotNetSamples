/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 06/07/2015
 * Time: 09:34 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testWebRequest
{
    using System;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    
    /// <summary>
    /// Description of TrustAllCertsPolicy.
    /// </summary>
    public class TrustAllCertsPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(
            ServicePoint srvPoint, X509Certificate certificate,
            WebRequest request, int certificateProblem) {
            return true;
        }
    }
}
