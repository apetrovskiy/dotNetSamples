using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class PromoCode
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Code { get; set; }
    // [ForeignKey("Customer")]
    public Customer Customer { get; set; }
}
