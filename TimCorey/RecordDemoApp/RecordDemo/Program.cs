using RecordDemo;

Console.WriteLine("Hello, World!");

static void SomeTest()
{
    Console.WriteLine("SomeTest");
    Console.WriteLine("=======================================================");
    Console.WriteLine();
}
SomeTest();
SomeClass.SomeMethod();

Record1 r1a = new("Tim", "Corey");
Record1 r1b = new("Tim", "Corey");
Record1 r1c = new("Sue", "Storm");

Class1 c1a = new("Tim", "Corey");
Class1 c1b = new("Tim", "Corey");
Class1 c1c = new("Sue", "Storm");

Console.WriteLine("Record Type:");
Console.WriteLine($"To String: {r1a}");
Console.WriteLine($"Are the two objects equal: {Equals(r1a, r1b)}");
Console.WriteLine($"Are the two objects reference equal: {ReferenceEquals(r1a, r1b)}");
Console.WriteLine($"Are the two objects ==: {r1a == r1b}");
Console.WriteLine($"Are the two objects !=: {r1a != r1c}");
Console.WriteLine($"Hash code of object A: {r1a.GetHashCode()}");
Console.WriteLine($"Hash code of object B: {r1b.GetHashCode()}");
Console.WriteLine($"Hash code of object C: {r1c.GetHashCode()}");

Console.WriteLine();
Console.WriteLine("***************************");
Console.WriteLine();

Console.WriteLine("Class Type:");
Console.WriteLine($"To String: {c1a}");
Console.WriteLine($"Are the two objects equal: {Equals(c1a, c1b)}");
Console.WriteLine($"Are the two objects reference equal: {ReferenceEquals(c1a, c1b)}");
Console.WriteLine($"Are the two objects ==: {c1a == c1b}");
Console.WriteLine($"Are the two objects !=: {c1a != c1c}");
Console.WriteLine($"Hash code of object A: {c1a.GetHashCode()}");
Console.WriteLine($"Hash code of object B: {c1b.GetHashCode()}");
Console.WriteLine($"Hash code of object C: {c1c.GetHashCode()}");


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