/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/11/2014
 * Time: 6:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Security;
using System.ServiceModel;

namespace svcPointManagerTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            // ServicePointManager.ServerCertificateValidationCallback.
            // RemoteCertificateValidationCallback.CreateDelegate(
//            var factory =
//                new System.ServiceModel.ChannelFactory<System.ServiceModel.Channels.IRequestChannel>(
//            var factory =
//                new System.ServiceModel.ChannelFactory();
            
            // var endpointAddress =
            //     new System.ServiceModel.EndpointAddress(
            
            const string url = "net.pipe:HbmV0LnBpcGU6Ly8rL0JCQUJERDNCLTYyOUMtNDYwRi1CNzI0LTVFNTA2OTZCNzkxQS9JVEFTS1NFUlZJQ0Uv";
            
            var binding = new System.ServiceModel.NetNamedPipeBinding(NetNamedPipeSecurityMode.Transport);
            // binding.MaxBufferSize
            // binding.MaxReceivedMessageSize
            binding.max
            
            try {
                var endpoint = new System.ServiceModel.EndpointAddress(url);
            }
            catch (Exception eEndpoint) {
                Console.WriteLine(eEndpoint.Message);
            }
            
            try {
                var uri1 = new System.Uri(url, UriKind.Absolute);
                Console.WriteLine(uri1);
            }
            catch (Exception eUri1) {
                Console.WriteLine(eUri1.Message);
            }
//            var uri2 = new System.Uri(url, true);
//            Console.WriteLine(uri2);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}