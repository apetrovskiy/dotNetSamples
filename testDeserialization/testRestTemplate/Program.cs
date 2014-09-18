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
	using System.Xml.Linq;
    using Spring.Http;
    using Spring.Http.Converters;
    using Spring.Http.Converters.Json;
    using Spring.Http.Converters.Xml;
	using Spring.Rest.Client;
	using testInterfaces;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            try {
                
                var reader = new StreamReader(@"E:\20140828\imported_rdp_SPLab-2008R2.SPALab.at.local_170.xml");
                // var reader = new StreamReader(@"E:\20140828\_tempo_.xml");
                var originalData = reader.ReadToEnd();
                var xDoc = XDocument.Parse(originalData);
                // var data = xDoc.Root.ToString();
                var data = xDoc.FirstNode.ToString();
                
                var restTemplate01 = new RestTemplate(); // FormHttpMessageConverter is configured by default
                // var restTemplate01 = new RestTemplate("http://localhost:12340/");
                //
                //
                // restTemplate01.MessageConverters.Clear();
                // restTemplate01.MessageConverters.Add(new NJsonHttpMessageConverter());
//                restTemplate01.MessageConverters.Add(new DataContractJsonHttpMessageConverter());
//                restTemplate01.MessageConverters.Add(new ResourceHttpMessageConverter());
//                restTemplate01.MessageConverters.Add(new XmlSerializableHttpMessageConverter());
                //
                //
                // data = "<?xml version='1.0' encoding='UTF-8' ?><Root><TestElement testAttribute='value'/><TestElement testAttribute='novalue'/></Root>";
                //
                //
                restTemplate01.MessageConverters.Add(new XElementHttpMessageConverter());
                //
                //
//                foreach (var messageConverter in restTemplate01.MessageConverters) {
//                    Console.WriteLine(messageConverter.GetType().Name);
//                }
//                var parts = new Dictionary<string, object>();
//                // var entity = new HttpEntity(new FileInfo(@"E:\20140828\imported_rdp_SPLab-2008R2.SPALab.at.local_170.xml"));
//                // var entity = new HttpEntity(data);
//                var dataObject = new Class1 { Data = data };
                // var entity = new HttpEntity(dataObject);
                // entity.Headers["Content-Type"] = "application/xml";
                // entity.Headers["Content-Type"] = "text/xml";
                // entity.Headers["Content-Type"] = "text/plain";
                // entity.Headers["Content-Type"] = "application/json";
                // parts.Add("data", entity);
                // restTemplate01.PostForLocation("http://localhost:12340/probe3/", parts);
                // restTemplate01.PostForObject<Class1>("http://localhost:12340/probe3/", parts);
                // restTemplate01.PostForObject<object>("http://localhost:12340/probe3/", parts);
                // restTemplate01.PostForObject<char[]>("http://localhost:12340/probe3/", parts);
                // restTemplate01.PostForLocation("http://localhost:12340/probe3/", dataObject);
                // restTemplate01.PostForMessage<Class1>("http://localhost:12340/probe3/", dataObject);
                // restTemplate01.PostForMessage<Class1>("probe3/", dataObject);
                // restTemplate01.PostForMessage<Class1>("probe3/", parts);
                // restTemplate01.PostForMessage("probe3/", parts);
                // restTemplate01.PostForMessage<Class1>("probe3/", dataObject);
                
//                Interface1 requestBody = new Class1(); // create booking request content
//                requestBody.Data = data;
//                HttpEntity entity01 = new HttpEntity(requestBody);
//                entity01.Headers["MyRequestHeader"] = "MyValue";
//                // restTemplate01.PostForLocation("probe3/", entity01);
//                // var responseMessage = restTemplate01.PostForLocation("http://localhost:12340/probe3/", entity01);
//Console.WriteLine("======================================000000000000000001===============================");
//                // HttpResponseMessage result = restTemplate01.PostForMessage("http://localhost:12340/probe3/", xDoc.FirstNode);
//                // var entity = new HttpEntity(new FileInfo(@"E:\20140828\imported_rdp_SPLab-2008R2.SPALab.at.local_170.xml"));
//                var entity02 = new HttpEntity(xDoc.FirstNode);
//                // entity02.Headers["Content-Type"] = "text/plain";
//                // entity02.Headers["Content-Type"] = "application/json";
//                // entity02.Headers["Content-Type"] = "application/xml";
//                // entity02.Headers["Content-Type"] = "text/xml";
//                parts.Add("data", entity02);
                
//                XElement user = new XElement("User", 
//                    new XElement("Name", "Lisa Baia"));
    
                // HttpResponseMessage result = restTemplate01.PostForMessage("http://localhost:12340/probe3/", user);
                // HttpResponseMessage result01 = restTemplate01.PostForMessage("http://localhost:12340/probe3/", parts);
                HttpResponseMessage result01 = restTemplate01.PostForMessage("http://localhost:12340/probe3/", xDoc.FirstNode);
                
//                var parts = new Dictionary<string, object>();
//                var entity = new HttpEntity(new FileInfo(@"E:\20140828\imported_rdp_SPLab-2008R2.SPALab.at.local_170.xml"));
//                // entity.Headers["Content-Type"] = "application/xml";
//                // entity.Headers["Content-Type"] = "text/xml";
//                entity.Headers["Content-Type"] = "text/plain";
//                parts.Add("file", entity);
//                restTemplate.PostForLocation("http://localhost:12340/probe2/", parts);
                
                // Console.WriteLine(responseMessage);
                
                
                // ===================================================================================================================================================
                if (string.IsNullOrEmpty(args[0]))
                    throw new FileNotFoundException("Please provide the right path to the file");
                var restTemplate04 = new RestTemplate();
                var parts04 = new Dictionary<string, object>();
                var entity04 = new HttpEntity(new FileInfo(args[0]));
                parts04.Add("data", entity04);
                
                var entity041 = new HttpEntity(args[0].Substring(0, args[0].LastIndexOf('\\') + 1));
                parts04.Add("path", entity041);
                
                // HttpResponseMessage result04 = restTemplate04.PostForMessage("http://localhost:12340/probe4/", parts04);
                HttpResponseMessage result04 = restTemplate04.PostForMessage("http://localhost:12340/probe4/", parts04);
                
                foreach (var messageConverter in restTemplate04.MessageConverters) {
                    Console.WriteLine(messageConverter.GetType().Name);
                }
                
                Console.WriteLine(result01.StatusCode);
            }
            catch (Exception e03) {
                Console.WriteLine(e03.Message);
            }
            return;
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