// See https://aka.ms/new-console-template for more information
// #error version
using System.Reflection;

Console.WriteLine("Hello, World!");

var myApp = Assembly.GetEntryAssembly();

if (null == myApp) return;

// Loop through the assemblies that my app references
foreach (var assemblyName in myApp.GetReferencedAssemblies())
{
    // load the assembly so we can read its details
    var assm = Assembly.Load(assemblyName);

    // declare a variable to count the number of methods
    var methodCount = 0;

    // loop through all the types in the assembly
    foreach (var typeInfo in assm.DefinedTypes)
    {
        // add up the counts of methods
        methodCount += typeInfo.GetMethods().Count();
    }

    // output the count of types and their methods
    Console.WriteLine("{0:N0} types with {1:N0} methods in {2} assembly.", arg0: assm.DefinedTypes.Count(), arg1: methodCount, arg2: assemblyName.Name);
}

System.Data.DataSet ds;
HttpClient client;

// let the heightInMetres variable bevome equal to the value 1.88
double heightInMetres = 1.88;
Console.WriteLine($"The variable {nameof(heightInMetres)} has the value {heightInMetres}");

string firstName = "Bob";
string lastName = "Smith";
string phoneNumber = "(215) 555-4256";

// assigning a string returned from the string class constructor
string horizontalLine = new('-', count: 74);

// asigning an emoji by converting from Unicode
var grinningEmoji = char.ConvertFromUtf32(0x1F600);

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine(grinningEmoji);

var filePath = @"C:\aaa\bbb\ccc.txt";

var xml = """
        <person age="50">
            <first_name>Mark</first_name>
        </person>
        """;
Console.WriteLine(xml);

var person = new { FirstName = "Alice", Age = 56 };
var json = $$"""
{
    "first_name":"{{person.FirstName}}"
    "age":{{person.Age}},
    "calculation","{{{1 + 2}}}"
}
""";
Console.WriteLine(json);