using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class Customer
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public List<CustomerPreference> Preferences { get; set; }
    // [ForeignKey("PromoCode")]
    public PromoCode PromoCode { get; set; }
}
