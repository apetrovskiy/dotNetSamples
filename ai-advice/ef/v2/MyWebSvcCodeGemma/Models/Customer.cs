using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Customer
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public List<CustomerPreference> Preferences { get; set; }
    public PromoCode PromoCode { get; set; }
}
