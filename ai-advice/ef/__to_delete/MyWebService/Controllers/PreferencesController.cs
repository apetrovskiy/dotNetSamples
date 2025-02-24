using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class PreferencesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PreferencesController(AppDbContext context)
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
