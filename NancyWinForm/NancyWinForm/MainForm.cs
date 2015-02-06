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
            
            const string URL = "http://localhost:8080";
            host = new NancyHost(new Uri(URL));
            host.Start();
        }
    }
}
