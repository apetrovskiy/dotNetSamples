/*
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
using System.Configuration.Install;
using System.ServiceProcess;

namespace restWinServ
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;
        
        public ProjectInstaller()
        {
            serviceProcessInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();
            // Here you can set properties on serviceProcessInstaller or register event handlers
            serviceProcessInstaller.Account = ServiceAccount.LocalService;
            
            serviceInstaller.ServiceName = restWinServ.MyServiceName;
            this.Installers.AddRange(new Installer[] { serviceProcessInstaller, serviceInstaller });
        }
    }
}
