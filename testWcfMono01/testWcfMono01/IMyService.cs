using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace testWcfMono01
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract, WebGet]
        String GetData();
    }
}

