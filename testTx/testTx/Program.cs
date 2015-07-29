/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 26/07/2015
 * Time: 09:27 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testTx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tx.Windows;
    
    class Program
    {
        public static void Main(string[] args)
        {
            EvtxObservable.FromLog("system").Subscribe(Console.WriteLine);
            var eventLogObservableSys = EvtxObservable.FromLog("System");
            Console.WriteLine(eventLogObservableSys.Subscribe(evt => Console.WriteLine(evt.Id + ", " + evt.Properties[0].Value)));
            var eventLogObservableApp = EvtxObservable.FromLog("Application");
            Console.WriteLine(eventLogObservableApp.Subscribe(Console.WriteLine));
//            var eventLogObservableSec = EvtxObservable.FromLog("Security");
//            Console.WriteLine(eventLogObservableSec.Subscribe(Console.WriteLine));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}