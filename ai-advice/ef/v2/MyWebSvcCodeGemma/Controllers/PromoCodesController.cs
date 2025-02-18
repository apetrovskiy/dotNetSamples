using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class PromoCodesController : Controller
{
    private readonly MyDbContext _context;

    public PromoCodesController(MyDbContext context)
    {
        _context = context;
    }

/// <summary>
/// Gives a promo code to a customer.
/// </summary>
[HttpPost("give")]
public async Task<ActionResult<PromoCode>> GivePromoCodesToCustomersAsync(PromoCode promoCode)
{
    await _context.PromoCodes.AddAsync(promoCode);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GivePromoCodesToCustomersAsync), new { id = promoCode.Id }, promoCode);
}

/// <summary>
/// Gets promo codes from customers.
/// </summary>
[HttpGet("get")]
public async Task<ActionResult<IEnumerable<PromoCode>>> GetPromoCodesFromCustomersAsync()
{
    return Ok(await _context.PromoCodes.ToListAsync());
}
}
