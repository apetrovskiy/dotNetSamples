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
        
        public DataExchangeModule() : base(Constants.BaseUrl)
        {
            Post[Constants.OutputDataUrl] = data => {
                Console.WriteLine("000001");
                _dataExchange = this.Bind<DataExchange>();
                Console.WriteLine("000002");
                Console.WriteLine(_dataExchange.StringData);
                return HttpStatusCode.Created;
            };
            
            Get[Constants.InputDataUrl] = _ => {
                Console.WriteLine("000003");
                Console.WriteLine(_dataExchange.StringData);
                return _dataExchange;
            };
        }
    }
}
