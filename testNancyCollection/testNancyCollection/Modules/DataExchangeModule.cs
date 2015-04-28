/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 14/04/2015
 * Time: 08:39 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNancyCollection.Modules
{
    using System;
    using Nancy;
    using Nancy.ModelBinding;
    using test.Interfaces;
    
    /// <summary>
    /// Description of DataExchangeModule.
    /// </summary>
    public class DataExchangeModule : NancyModule
    {
        static DataExchange _dataExchange;
        
        public DataExchangeModule() : base()
        {
            Post[Constants.OutputDataUrl] = data => {
                Console.WriteLine("POST");
                _dataExchange = this.Bind<DataExchange>();
                _dataExchange.PrintOut();
                return HttpStatusCode.Created;
            };
            
            Get[Constants.InputDataUrl] = _ => {
                Console.WriteLine("GET");
                _dataExchange.PrintOut();
                return _dataExchange;
            };
        }
    }
}
