namespace MyWebService.Models;

using MyWebService.Controllers;
using MyWebService.Repositories;
using MyWebService.Models;
using MyWebService.Data;

using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
}
