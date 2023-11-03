// See https://aka.ms/new-console-template for more information
// #error version
using System.Reflection;
using static System.Console;
using System.Xml;

WriteLine(Environment.CurrentDirectory);
WriteLine(Environment.OSVersion.VersionString);

System.Data.DataSet ds;
HttpClient http;


var myApp = Assembly.GetEntryAssembly();

if (null == myApp) return;

foreach (var assmName in myApp.GetReferencedAssemblies())
{
    var assm = Assembly.Load(assmName);
    var methodCount = 0;
    foreach (var typeInfo in assm.DefinedTypes)
    {
        methodCount += typeInfo.GetMethods().Count();
    }

    WriteLine("{0:N0} types with {1:N0} methods in {2} assembly", arg0: assm.DefinedTypes.Count(), arg1: methodCount, arg2: assmName.Name);
}


var heightInMetres = 1.88;
WriteLine($"The variable {nameof(heightInMetres)} has the value {heightInMetres}.");

/*
var letter = 'A';
var digit = '1';
var symbol = '$';
var userChoice = GetSomeKeystroke();
*/

var firstName = "Bob";
var lastName = "Smith";
var phoneNumber = "(215) 555-4256";
string horizontalLine = new('-', count: 74);
// var address = GetAddressFromDatabase();
WriteLine($"{firstName}, {lastName}, {phoneNumber}, {horizontalLine}");

Console.OutputEncoding = System.Text.Encoding.UTF8;
var grinningEmoji = char.ConvertFromUtf32(0x1F600);
WriteLine(grinningEmoji);

var person = new { FirstName = "Alice", Age = 56 };
var json = $$"""
{
    "first_name":"{{person.FirstName}}",
    "age":"{{person.Age}}",
    "calculation","{{{1 + 2}}}"
}
""";
WriteLine(json);

WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}.");
WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}.");
WriteLine($"decimal uses {sizeof(decimal)} and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}.");

// PR
WriteLine($"using doubles {0.1} + {0.2} {(0.1 + 0.2 == 0.3 ? "equals" : "does not equal")} {0.3}");
WriteLine($"using decimals {0.1m} + {0.2M} {(0.1M + 0.2M == 0.3M ? "equals" : "does not equal")} {0.3M}");

dynamic something = new[] { 3, 5, 7 }; // 12; // "Ahmed";
WriteLine($"Length is {something.Length}");

var xmlDoc = new XmlDocument();
var file1 = File.CreateText("something1.txt");

class aaa { }