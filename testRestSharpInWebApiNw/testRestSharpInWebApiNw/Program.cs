using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testRestSharpInWebApiNw
{
    using RestSharp;
    using Spring.Http.Client;
    using Spring.Rest.Client;

    class Program
    {
        static void Main(string[] args)
        {
            const string initialUrl = "http://192.168.129.173:4013/ActivityRecords";

            var client = new RestClient(initialUrl);
            var request = new RestRequest(Method.GET);

            // var result = client.Get(request);
            var result = client.ExecuteAsGet(request, "GET");
            // result.con

            var restTemplate = new RestTemplate(initialUrl);
            // restTemplate.RequestFactory = new WebClientHttpRequestFactory();
            // restTemplate.RequestFactory.

            var resultRt = restTemplate.GetForObject<string>("/ActivityRecords");

            Console.WriteLine(resultRt);

            int i = 1;
        }
    }
}
