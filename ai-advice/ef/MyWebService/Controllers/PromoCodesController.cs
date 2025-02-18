namespace MyWebService.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MyWebService.Repositories;
using MyWebService.Models;
using MyWebService.Data;

[ApiController]
[Route("[controller]")]
public class PromoCodesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PromoCodesController(AppDbContext context)
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
