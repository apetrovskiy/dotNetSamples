﻿/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 2/9/2015
 * Time: 2:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace restWinServ
{
    public class restWinServ : ServiceBase
    {
        public const string MyServiceName = "restWinServ";
        
        public restWinServ()
        {
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            this.ServiceName = MyServiceName;
        }
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            // TODO: Add cleanup code here (if required)
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// Start this service.
        /// </summary>
        protected override void OnStart(string[] args)
        {
            // TODO: Add start code here (if required) to start your service.
        }
        
        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            // TODO: Add tear-down code here (if required) to stop your service.
        }
    }
}
