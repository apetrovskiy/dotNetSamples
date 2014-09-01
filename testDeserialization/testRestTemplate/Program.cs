/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 8/29/2014
 * Time: 12:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testRestTemplate
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using Spring.Http;
    using Spring.Http.Converters;
    using Spring.Http.Converters.Json;
    using Spring.Http.Converters.Xml;
	using Spring.Rest.Client;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            try {
                
                var reader = new StreamReader(@"E:\20140828\imported_rdp_SPLab-2008R2.SPALab.at.local_170.xml");
                var data = reader.ReadToEnd();
                
                var restTemplate01 = new RestTemplate(); // FormHttpMessageConverter is configured by default
                var parts = new Dictionary<string, object>();
                // var entity = new HttpEntity(new FileInfo(@"E:\20140828\imported_rdp_SPLab-2008R2.SPALab.at.local_170.xml"));
                var entity = new HttpEntity(data);
                // entity.Headers["Content-Type"] = "application/xml";
                // entity.Headers["Content-Type"] = "text/xml";
                entity.Headers["Content-Type"] = "text/plain";
                parts.Add("data", entity);
                restTemplate01.PostForLocation("http://localhost:12340/probe3/", parts);
            }
            catch (Exception e03) {
                Console.WriteLine(e03.Message);
            }
            
            // TODO: Implement Functionality Here
            
//            String fileToUpload = dir.getPath() + File.separator + fileName;
//            MultiValueMap<String, Object> parts = new LinkedMultiValueMap<String, Object>();
//            parts.add("file", new FileSystemResource(fileToUpload));
//            String response = rest.postForObject(uploadUri, parts, String.class, authToken, folderId);

//            messageConverters.add(new FormHttpMessageConverter());
//            messageConverters.add(new SourceHttpMessageConverter<Source>());
//            messageConverters.add(new StringHttpMessageConverter());
//            messageConverters.add(new MappingJacksonHttpMessageConverter());
            
            try {
                /*
                var fileToUpload = @"E:\20140828\imported_rdp_SPLab-2008R2.SPALab.at.local_170.xml";
                // var reader = new XmlTextReader(fileToUpload);
                var reader = new StreamReader(fileToUpload);
                if (null == reader) {
                    Console.WriteLine("null == reader");
                } else {
                    Console.WriteLine("null != reader");
                }
                // var fileContent = reader.ReadInnerXml();
                var fileContent = reader.ReadToEnd();
                if (null == fileContent) {
                    Console.WriteLine("null == fileContent");
                } else {
                    Console.WriteLine("null != fileContent");
                    Console.WriteLine(fileContent.Length);
                }
                Console.WriteLine(fileContent);
                
                
                var rest = new RestTemplate(); // @"http://localhost:12340/");
                // rest.MessageConverters.Add(new FileInfoHttpMessageConverter());
                rest.MessageConverters.Add(new StringHttpMessageConverter());
//                rest.MessageConverters.Add(new FormHttpMessageConverter());
//                rest.MessageConverters.Add(new DataContractJsonHttpMessageConverter());
//                rest.MessageConverters.Add(new XmlDocumentHttpMessageConverter());
                // rest.PostForObject<string>("probe2/", fileContent);
                rest.PostForObject<string>("http://localhost:12340/probe2/", fileContent);
                */
                
//                RestTemplate template = new RestTemplate(); // FormHttpMessageConverter is configured by default
//                IDictionary<string, object> parts = new Dictionary<string, object>();
//                HttpEntity entity = new HttpEntity(new FileInfo(@"C:\myFile.xls"));
//                entity.Headers["Content-Type"] = "application/vnd.ms-excel";
//                parts.Add("file", entity);
//                template.PostForLocation("http://example.com/myFileUpload", parts);
                
                var restTemplate = new RestTemplate(); // FormHttpMessageConverter is configured by default
                var parts = new Dictionary<string, object>();
                var entity = new HttpEntity(new FileInfo(@"E:\20140828\imported_rdp_SPLab-2008R2.SPALab.at.local_170.xml"));
                // entity.Headers["Content-Type"] = "application/xml";
                // entity.Headers["Content-Type"] = "text/xml";
                entity.Headers["Content-Type"] = "text/plain";
                parts.Add("file", entity);
                restTemplate.PostForLocation("http://localhost:12340/probe2/", parts);
            }
            catch (Exception eeeeeeeeeee) {
                Console.WriteLine(eeeeeeeeeee.Message);
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}