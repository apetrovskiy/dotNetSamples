// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Record1 r1a = new("Tim", "Corey");
Record1 r1b = new("Tim", "Corey");
Record1 r1c = new("Sue", "Storm");

Class1 c1a = new("Tim", "Corey");
Class1 c1b = new("Tim", "Corey");
Class1 c1c = new("Sue", "Storm");

Console.WriteLine("Record Type:");
Console.WriteLine($"To String: {r1a}");

Console.WriteLine();
Console.WriteLine("***************************");
Console.WriteLine();

Console.WriteLine("Class Type:");
Console.WriteLine($"To String: {c1a}");

// a Record is just a fancy class
// Immutable - The values cannot be changed
public record Record1(string FirstName, string LastName);

public class Class1
{
    public string FirstName { get; init; }
    public string Lastname { get; init; }

    public Class1(string firstName, string lastName)
    {
        FirstName = firstName;
        Lastname = lastName;
    }
}