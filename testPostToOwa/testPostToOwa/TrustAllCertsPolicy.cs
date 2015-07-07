/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 07/07/2015
 * Time: 06:36 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testPostToOwa
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
