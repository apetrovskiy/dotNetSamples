namespace MyWebService.Models;

using MyWebService.Controllers;
using MyWebService.Repositories;
using MyWebService.Models;
using MyWebService.Data;

using System.ComponentModel.DataAnnotations;

public class PromoCode
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Code { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}
