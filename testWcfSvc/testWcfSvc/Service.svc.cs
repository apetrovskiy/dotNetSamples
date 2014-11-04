/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 11/27/2013
 * Time: 7:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ServiceModel;

namespace testWcfSvc
{
    [ServiceContract]
    public interface IService
    {
       [OperationContract]
       void MyOperation();
    }
    
    public class Service : IService
    {
       public void MyOperation()
       {
          // implement the operation
       }
    } 
}
