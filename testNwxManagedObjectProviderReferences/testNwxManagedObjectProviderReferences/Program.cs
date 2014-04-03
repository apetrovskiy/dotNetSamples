/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/3/2014
 * Time: 1:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NetWrix.ChangeReporterConfigurator;
using NetWrix.ChangeReporterProviderInterfaces;
using NetWrix.ComputerCollectionCRProviderType;
using NetWrix.ManagedObjectTypes;

namespace testNwxManagedObjectProviderReferences
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var configurator = new ChangeReporterConfigurator();
            configurator.Load();
            // IChangeReporterProviderInterfaces providerInterfaces = configurator.ChangeReporterProviders.Values.First();
            var mo = new ManagedObject();
            mo.Name = "eeeee5";
            mo.UseDefaultAccount = true;
            mo.TypeGUID = ManagedObjectGUID.ComputerCollectionGuid.ToString();
            
            var sharedConfig = new ComputerCollectionConfiguration();
            string sharedConfigString = sharedConfig.SerializeToString();
            
            mo.SharedProviderConfiguration = sharedConfigString;
            
            List<string> aaa = GetSupportedProvidersNames(ManagedObjectGUID.ComputerCollectionGuid);
            
            IChangeReporterProviderInterfaces providerInterfaces =
                configurator.ChangeReporterProviders.Values.First(p => aaa.Contains(p.ProviderType.ProviderName));
//            
            
//            var providerRef = Substitute.For<ProviderReference>();
//            providerRef.ManagedObject = mo; //.Returns(mo);
//            providerRef.ManagedObjectName = mo.Name; //.Returns(mo.Name);
//            providerRef.ProviderName = providerInterfaces.ProviderType.ProviderName;
//            providerRef.IsFilledByUser = true; //.Returns(true);
            var providerRef = new ProviderReference
            {
                ManagedObject = mo,
                ManagedObjectName = mo.Name,
                ProviderName = providerInterfaces.ProviderType.ProviderName,
                IsFilledByUser = true
            };
            mo.ProviderReferences.Add(providerRef);
            
            // mo.ProviderReferences.Remove(providerRef);
            
            configurator.Configuration.ConfigurationRoot.ManagedObjects.Add(mo);
            configurator.Save();
            
            // configurator.Load();
            
            // configurator.Configuration.ConfigurationRoot.ManagedObjects.Single(m => m.Name == mo.Name).ProviderReferences.RemoveAt(0);
            configurator.Save();
            
            Console.WriteLine(mo); 
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        
        internal static List<string> GetSupportedProvidersNames(Guid guid)
        {
            var result = new List<string>();
//            switch (guid.ToString()) {
//                case ManagedObjectGUID.ComputerCollectionGuid.ToString():
//                    result.Add("File Server Change Reporter");
//                    result.Add("Windows Server Change Reporter");
//                    result.Add("Event Log Manager");
//                    result.Add("SQL Server Change Reporter");
//                    result.Add("User Activity Video Reporter");
//                    return result;
//                case ManagedObjectGUID.DomainGuid.ToString():
//                    result.Add("Active Directory Changes Reporter");
//                    result.Add("Group Policy Changes Reporter");
//                    result.Add("Exchange Changes Reporter");
//                    result.Add("Password Expiration Notifier");
//                    result.Add("Inactive Users Tracker");
//                    return result;
//                case ManagedObjectGUID.OrganizationUnitGuid.ToString():
//                    result.Add("Password Expiration Notifier");
//                    result.Add("Inactive Users Tracker");
//                    return result;
//                case ManagedObjectGUID.SharepointFarmGuid.ToString():
//                    result.Add("Netwrix Auditor for SharePoint");
//                    return result;
//                case ManagedObjectGUID.VirtualServerGuid.ToString():
//                    result.Add("Change Reporter for VI3");
//                    return result;
//            }
            
            if (ManagedObjectGUID.ComputerCollectionGuid.ToString() == guid.ToString()) {
                    result.Add("File Server Change Reporter");
                    result.Add("Windows Server Change Reporter");
                    result.Add("Event Log Manager");
                    result.Add("SQL Server Change Reporter");
                    result.Add("User Activity Video Reporter");
            }
            if (ManagedObjectGUID.DomainGuid.ToString() == guid.ToString()) {
                    result.Add("Active Directory Changes Reporter");
                    result.Add("Group Policy Changes Reporter");
                    result.Add("Exchange Changes Reporter");
                    result.Add("Password Expiration Notifier");
                    result.Add("Inactive Users Tracker");
            }
            if (ManagedObjectGUID.OrganizationUnitGuid.ToString() == guid.ToString()) {
                    result.Add("Password Expiration Notifier");
                    result.Add("Inactive Users Tracker");
            }
            if (ManagedObjectGUID.SharepointFarmGuid.ToString() == guid.ToString()) {
                    result.Add("Netwrix Auditor for SharePoint");
            }
            if (ManagedObjectGUID.VirtualServerGuid.ToString() == guid.ToString()) {
                    result.Add("Change Reporter for VI3");
            }
            return result;
        }
    }
}