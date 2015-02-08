/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/6/2015
 * Time: 10:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyWinForm
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Nancy;
    using Nancy.Hosting.Self;
    using System.Net.Sockets;
    using System.Net;
    
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        NancyHost host;
        
        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //

            StaticConfiguration.DisableErrorTraces = false;
            /*
            const string URL = "http://localhost:8080";
            host = new NancyHost(new Uri(URL));
            host.Start();
            */
            int port = 8080;
            var hostConfiguration = new HostConfiguration {
                UrlReservations = new UrlReservations { CreateAutomatically = true }
            };
            host = new NancyHost (hostConfiguration, GetUriParams (port));
            //
            host = new NancyHost(new Uri("http://localhost:8080"));
            //
            host.Start ();
        }

        Uri[] GetUriParams(int port)
        {
            var uriParams = new List<Uri> ();
            string hostName = Dns.GetHostName ();
            string hostNameUri = string.Format ("http://{0}:{1}", Dns.GetHostName (), port);
            uriParams.Add (new Uri (hostNameUri));
            var hostEntry = Dns.GetHostEntry (hostName);
            foreach (var ipAddress in hostEntry.AddressList) {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork) {
                    var addrBytes = ipAddress.GetAddressBytes ();
                    string hostAddressUri = string.Format ("http://{0}.{1}.{2}.{3}:{4}", addrBytes [0], addrBytes [1], addrBytes [2], addrBytes [3], port);
                    uriParams.Add (new Uri (hostAddressUri));
                }
            }
            uriParams.Add (new Uri (string.Format ("http://localhost:{0}", port)));
            return uriParams.ToArray ();
        }
    }
}
