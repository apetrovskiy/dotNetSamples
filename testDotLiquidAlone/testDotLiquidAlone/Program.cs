/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/4/2014
 * Time: 7:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExamples
{
    using System;
    using System.Dynamic;
    using System.IO;
    using DotLiquid;
    
    class Program
    {
        public static void Main(string[] args)
        {
            bool withOneMoreLevelOfAbstraction = true;
            
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            Template.RegisterSafeType(typeof(Product), new[] { "Name", "Price", "Description" });
            Template.RegisterSafeType(typeof(Product2), new[] { "Name", "Price", "Description", "Id", "Number" });
            Template.RegisterSafeType(typeof(Product3), new[] { "Name", "Price", "Description", "Id", "Number", "UniqueId" });
            Template.RegisterSafeType(typeof(ProductList), new[] { "Products" });
            Template.RegisterSafeType(typeof(Guid), member => member.ToString());
            
            Template template;
            // using (var reader = new StreamReader(@"./Views/sorted.liquid")) {
            using (var reader = new StreamReader(@"./Views/sorted1-1.liquid")) {
                var templateCode = reader.ReadToEnd();
                template = Template.Parse(templateCode);
                reader.Close();
            }
            
            // dynamic expando = new ExpandoObject();
            var list = new ProductList ();
            list.Products.AddRange (
                new [] {
                new Product { Name = "c", Price = 5, Description = "one" },
                new Product { Name = "a", Price = 10, Description = "two" },
                new Product { Name = "z", Price = 1, Description = "three" },
                new Product { Name = "b", Price = 11, Description = "four" },
                new Product { Name = "a", Price = 8, Description = "five" },
                new Product { Name = "z", Price = 9, Description = "six" },
                new Product { Name = "k", Price = 11, Description = "seven" },
                new Product { Name = "h", Price = 5, Description = "eight" }
            });
            // string result = template.Render(Hash.FromAnonymousObject(new { @Model = list }));
            string result = string.Empty;
            if (withOneMoreLevelOfAbstraction) {
                // expando.Data = list;
                // result = template.Render(Hash.FromAnonymousObject(new { @Model = expando }));
                
                // var test = new { @Model = new { Data = list } };
                
                result = template.Render(Hash.FromAnonymousObject(new { @Model = new { Data = list } }));
            } else {
                result = template.Render(Hash.FromAnonymousObject(new { @Model = list }));
            }
            Console.WriteLine(result);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}