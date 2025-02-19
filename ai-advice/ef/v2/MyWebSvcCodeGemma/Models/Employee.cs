using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public Role Role { get; set; }
}
