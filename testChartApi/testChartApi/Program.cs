/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/11/2014
 * Time: 6:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testChartApi
{
    using System;
    using System.Drawing;
    using System.Net.Mime;
    using Spring.Http.Converters;
    using Spring.Http.Converters.Json;
    using Spring.Rest.Client;

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var restTemplate = new RestTemplate("http://chart.apis.google.com");
//            restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            restTemplate.MessageConverters.Add(new ByteArrayHttpMessageConverter());
//            restTemplate.MessageConverters.Add(new ResourceHttpMessageConverter());
//            restTemplate.MessageConverters.Add(new StringHttpMessageConverter());
            
            // var result = restTemplate.GetForMessage(@"/chart?cht=p3&chs=250x100&chd=t:60,40&chl=Hello|World");
            var result = restTemplate.GetForObject<Bitmap>(@"/chart?cht=p3&chs=250x100&chd=t:60,40&chl=Hello|World");
            if (null == result)
                ;
            else 
                Console.WriteLine(result);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}