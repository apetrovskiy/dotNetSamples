namespace MyWebService.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyWebService.Controllers;
using MyWebService.Repositories;
using MyWebService.Models;
using MyWebService.Data;

public class Customer
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    public int PreferenceId { get; set; }
    public ICollection<CustomerPreference> CustomerPreferences { get; set; } = new List<CustomerPreference>();
    public PromoCode PromoCode { get; set; }
}
