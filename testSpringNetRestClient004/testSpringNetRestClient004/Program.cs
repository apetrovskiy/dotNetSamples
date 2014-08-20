/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 8/20/2014
 * Time: 4:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSpringNetRestClient004
{
    using System;
	using Spring.Http;
	using Spring.Http.Converters.Json;
	using Spring.Rest.Client;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Types.Remoting;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var restTemplate = new RestTemplate();
            // restTemplate.MessageConverters.Add(new SpringJsonHttpMessageConverter());
            // restTemplate.MessageConverters.Add(new DataContractJsonHttpMessageConverter());
            restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            // var result = restTemplate.GetForObject<object>("http://localhost:12340/tasks/1");
            
            
            var testClient = new TestClient {
                CustomString = "console",
                Hostname = Environment.MachineName,
                Username = Environment.UserName,
                UserDomainName = Environment.UserDomainName,
                IsInteractive = Environment.UserInteractive,
                IsAdmin = true,
                // EnvironmentVersion = Environment.Version.Major + "." + Environment.Version.MajorRevision + "." + Environment.Version.Minor + "." + Environment.Version.MinorRevision + "." + Environment.Version.Build,
                // Fqdn = Dns.GetHostName() + "." + IPGlobalProperties.GetIPGlobalProperties().DomainName,
                OsVersion = Environment.OSVersion.VersionString,
                UptimeSeconds = Environment.TickCount / 1000
            };
            
            // HttpResponseMessage<TestClient> resultRegistration = restTemplate.PostForMessage<TestClient>("http://localhost:12340/clients", testClient);
            var resultRegistration = restTemplate.PostForMessage<TestClient>("http://localhost:12340/clients", testClient);
            Console.WriteLine(resultRegistration);
            Console.WriteLine(resultRegistration.GetType().Name);
            Console.WriteLine(resultRegistration.StatusCode);
            Console.WriteLine(resultRegistration.Body.Id);
            /*
            var resultRegistration = restTemplate.PostForObject<TestClient>("http://localhost:12340/clients", testClient);
            Console.WriteLine(resultRegistration);
            Console.WriteLine(resultRegistration.GetType().Name);
            */
            Console.WriteLine("====================================================================");
            
            
            
            
            
            
            
            var result = restTemplate.GetForObject<TestTask>("http://localhost:12340/tasks/1");
            Console.WriteLine(result);
            Console.WriteLine(result.GetType().Name);
            Console.WriteLine(result.Name);
            Console.WriteLine(result.Id);
            Console.WriteLine(result.Action);
            Console.WriteLine(result.ActionParameters);
            Console.WriteLine(result.ClientId);
            Console.WriteLine(result.TaskResult);
            Console.WriteLine(result.Timeout);
            // {"id":110,"previousTaskId":0,"isActive":true,"taskFinished":false,"timeout":600,"retryCount":0,"isCritical":true,
            // "taskType":0,"rule":"","name":"MSI UPGRADE: Restoring the test lab","storyId":"1000110",
            // "action":"param($a, $b, $c, $d) New-Item -Path e:\\11223344555-110.txt -ItemType file -Force; \"aaa\" \u003e\u003e e:\\11223344555-110.txt\n            \t\t$a \u003e\u003e e:\\11223344555-110.txt\n            \t\t$b \u003e\u003e e:\\11223344555-110.txt\n            \t\t$c \u003e\u003e e:\\11223344555-110.txt\n            \t\t$d \u003e\u003e e:\\11223344555-110.txt\n            \t\tipmo C:\\Projects\\PS\\STUPS\\TMX\\TMX\\bin\\Release35\\TMX.dll\n\t\t\t\t\tSend-TmxTestTaskResult -Result \"110\",\"res1\",(Get-Date),0.01,\"aaaaaaaaa\" -ClientId 1;# ([Tmx.Client.ClientSettings]::ClientId);\n                    # Send-TmxTestTaskResult -Result \"110\",\"res1\",(Get-Date),0.01,\"aaaaaaaaa\" -ClientId ([Tmx.Client.ClientSettings]::ClientId);\n                    # Send-TmxTestTaskResult -Result \"110\",\"res1\",(Get-Date),0.01,\"aaaaaaaaa\" -ClientId ([Tmx.Client.ClientSettings]::Instance.ClientId);\n            \t","actionParameters":["1","","aaa","aaa.bbb.ccc"],"beforeAction":"","beforeActionParameters":[],"afterAction":"","afterActionParameters":[],"expectedResult":null,"taskStatus":0,"previousTaskResult":null,"taskResult":null,"clientId":1}
//            // using variable length arguments
//            string result = restTemplate.GetForObject<string>("http://example.com/hotels/{hotel}/bookings/{booking}", 42, 21);
//            
//            // using a IDictionary<string, object>
//            IDictionary<string, object> vars = new Dictionary<string, object>(1);
//            vars.Add("hotel", 42);
//            string result = restTemplate.GetForObject<string>("http://example.com/hotels/{hotel}/rooms/{hotel}", vars);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}