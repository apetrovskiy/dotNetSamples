namespace MyWebService.Models;

using MyWebService.Controllers;
using MyWebService.Repositories;
using MyWebService.Models;
using MyWebService.Data;

using System.ComponentModel.DataAnnotations;

public class Role
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Title { get; set; }
}
