using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class PreferenceController : Controller
{
    private readonly MyDbContext _context;

    public PreferenceController(MyDbContext context)
    {
        _context = context;
    }

/// <summary>
/// Gets all preferences.
/// </summary>
[HttpGet]
public async Task<ActionResult<IEnumerable<Preference>>> GetPreferences()
{
    return Ok(await _context.Preferences.ToListAsync());
}
}
